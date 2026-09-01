Imports System.Data
Partial Class bidding_Bidding_Infra_Infra_Notices
    Inherits System.Web.UI.Page
    Dim obj As New AccessRule
    Private objDerived As New DerivedDal

    Private Property dtDeclaration() As DataTable
        Get
            Return CType(Session("dtDeclaration"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtDeclaration") = value
        End Set
    End Property
    Private Property dtResolution() As DataTable
        Get
            Return CType(Session("dtResolution"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtResolution") = value
        End Set
    End Property
    Private Property dtDeclarationBidders() As DataTable
        Get
            Return CType(Session("dtDeclarationBidders"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtDeclarationBidders") = value
        End Set
    End Property

    Private Property dtPostQua() As DataTable
        Get
            Return CType(Session("dtPostQua"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtPostQua") = value
        End Set
    End Property
    Private Property dtNOA() As DataTable
        Get
            Return CType(Session("dtNOA"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtNOA") = value
        End Set
    End Property
    Private Property dtContract() As DataTable
        Get
            Return CType(Session("dtContract"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtContract") = value
        End Set
    End Property
    Private Property dtNTP() As DataTable
        Get
            Return CType(Session("dtNTP"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtNTP") = value
        End Set
    End Property
    Public Function dtTemp_declaration(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("Infra_BidPrep_ID", GetType(Integer))
        dt.Columns.Add("ITB_No", GetType(String))
        dt.Columns.Add("PPA", GetType(String))
        dt.Columns.Add("Amount", GetType(Decimal))
        dt.Columns.Add("FundDesc", GetType(String))
        dt.Columns.Add("RC_ID", GetType(Integer))
        dt.Columns.Add("Function_ID", GetType(Integer))
        dt.Columns.Add("isVisible", GetType(Boolean))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("Infra_BidPrep_ID") = DBNull.Value
            dr("ITB_No") = DBNull.Value
            dr("PPA") = DBNull.Value
            dr("Amount") = DBNull.Value
            dr("FundDesc") = DBNull.Value
            dr("RC_ID") = DBNull.Value
            dr("Function_ID") = DBNull.Value
            dr("isVisible") = True
            dt.Rows.Add(dr)
        Next
        Return dt
    End Function
    Public Function dtTemp_DeclarationBidders(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("Infra_Bidders_ID", GetType(Integer))
        dt.Columns.Add("Supplier_ID", GetType(Integer))
        dt.Columns.Add("SuppName", GetType(String))
        dt.Columns.Add("BidAmount", GetType(Decimal))
        dt.Columns.Add("isVisible", GetType(Boolean))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("Infra_Bidders_ID") = DBNull.Value
            dr("Supplier_ID") = DBNull.Value
            dr("SuppName") = DBNull.Value
            dr("BidAmount") = DBNull.Value
            dr("isVisible") = True
            dt.Rows.Add(dr)
        Next
        Return dt
    End Function
    Public Function dtTemp_PostQua(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("Infra_BidPrep_ID", GetType(Integer))
        dt.Columns.Add("Infra_Bidders_ID", GetType(Integer))
        dt.Columns.Add("ITB_No", GetType(String))
        dt.Columns.Add("PPA", GetType(String))
        dt.Columns.Add("SuppName", GetType(String))
        dt.Columns.Add("BidAmount", GetType(Decimal))
        dt.Columns.Add("FundDesc", GetType(String))
        dt.Columns.Add("RC_ID", GetType(Integer))
        dt.Columns.Add("Function_ID", GetType(Integer))
        dt.Columns.Add("isVisible", GetType(Boolean))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("Infra_BidPrep_ID") = DBNull.Value
            dr("Infra_Bidders_ID") = DBNull.Value
            dr("ITB_No") = DBNull.Value
            dr("PPA") = DBNull.Value
            dr("SuppName") = DBNull.Value
            dr("BidAmount") = DBNull.Value
            dr("FundDesc") = DBNull.Value
            dr("RC_ID") = DBNull.Value
            dr("Function_ID") = DBNull.Value
            dr("isVisible") = True
            dt.Rows.Add(dr)
        Next
        Return dt
    End Function
    Public Function dtTemp_Reso(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("Infra_BidPrep_ID", GetType(Integer))
        dt.Columns.Add("ITB_No", GetType(String))
        dt.Columns.Add("PPA", GetType(String))
        dt.Columns.Add("BidAmount", GetType(Decimal))
        dt.Columns.Add("FundDesc", GetType(String))
        dt.Columns.Add("ResponsiveBid", GetType(String))
        dt.Columns.Add("RC_ID", GetType(Integer))
        dt.Columns.Add("Function_ID", GetType(Integer))
        dt.Columns.Add("Supplier_ID", GetType(Integer))
        dt.Columns.Add("isVisible", GetType(Boolean))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("Infra_BidPrep_ID") = DBNull.Value
            dr("ITB_No") = DBNull.Value
            dr("PPA") = DBNull.Value
            dr("BidAmount") = DBNull.Value
            dr("FundDesc") = DBNull.Value
            dr("ResponsiveBid") = DBNull.Value
            dr("RC_ID") = DBNull.Value
            dr("Function_ID") = DBNull.Value
            dr("Supplier_ID") = DBNull.Value
            dr("isVisible") = True
            dt.Rows.Add(dr)
        Next
        Return dt
    End Function

    Public Function dtTemp_ResoBidders(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("Infra_Bidders_ID", GetType(Integer))
        dt.Columns.Add("Supplier_ID", GetType(Integer))
        dt.Columns.Add("SuppName", GetType(String))
        dt.Columns.Add("BidAmount", GetType(Decimal))
        dt.Columns.Add("isVisible", GetType(Boolean))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("Infra_Bidders_ID") = DBNull.Value
            dr("Supplier_ID") = DBNull.Value
            dr("SuppName") = DBNull.Value
            dr("BidAmount") = DBNull.Value
            dr("isVisible") = True
            dt.Rows.Add(dr)
        Next
        Return dt
    End Function
    Public Function dtTemp_Notice(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("Infra_BidPrep_ID", GetType(Integer))
        dt.Columns.Add("ITB_No", GetType(String))
        dt.Columns.Add("PPA", GetType(String))
        dt.Columns.Add("SuppName", GetType(String))
        dt.Columns.Add("Supplier_ID", GetType(Integer))
        dt.Columns.Add("isVisible", GetType(Boolean))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("Infra_BidPrep_ID") = DBNull.Value
            dr("ITB_No") = DBNull.Value
            dr("PPA") = DBNull.Value
            dr("SuppName") = DBNull.Value
            dr("Supplier_ID") = DBNull.Value
            dr("isVisible") = True
            dt.Rows.Add(dr)
        Next
        Return dt
    End Function
    Public Function replaceapostrophe(ByVal str As String) As String
        Return Replace(str, "'", "''")
    End Function


    Private Sub bidding_Bidding_Infra_Infra_Notices_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            LoadTabs()

        End If

        txtDeclaration_Search.Attributes.Add("onkeypress", "return fun1(event,'" & btnDeclaration_Search.ClientID & "')")
        txtNOA_Search.Attributes.Add("onkeypress", "return fun1(event,'" & btnNOA_Search.ClientID & "')")
        txtContract_Search.Attributes.Add("onkeypress", "return fun1(event,'" & btnContract_Search.ClientID & "')")
        txtNTP_Search.Attributes.Add("onkeypress", "return fun1(event,'" & btnNTP_Search.ClientID & "')")
    End Sub
    Private Sub btnTab_Declaration_Click(sender As Object, e As EventArgs) Handles btnTab_Declaration.Click
        btnTab_Declaration.CssClass = "TabButton_Active"
        btnTab_PostQua.CssClass = "TabButton_InActive"
        btnTab1_Resolution.CssClass = "TabButton_InActive"
        btnTab2_NOA.CssClass = "TabButton_InActive"
        btnTab3_Contract.CssClass = "TabButton_InActive"
        btnTab4_NTP.CssClass = "TabButton_InActive"

        LoadTabs()
    End Sub
    Private Sub btnTab_PostQua_Click(sender As Object, e As EventArgs) Handles btnTab_PostQua.Click
        btnTab_Declaration.CssClass = "TabButton_InActive"
        btnTab_PostQua.CssClass = "TabButton_Active"
        btnTab1_Resolution.CssClass = "TabButton_InActive"
        btnTab2_NOA.CssClass = "TabButton_InActive"
        btnTab3_Contract.CssClass = "TabButton_InActive"
        btnTab4_NTP.CssClass = "TabButton_InActive"

        LoadTabs()
    End Sub
    Private Sub btnTab1_Resolution_Click(sender As Object, e As EventArgs) Handles btnTab1_Resolution.Click
        btnTab_Declaration.CssClass = "TabButton_InActive"
        btnTab_PostQua.CssClass = "TabButton_InActive"
        btnTab1_Resolution.CssClass = "TabButton_Active"
        btnTab2_NOA.CssClass = "TabButton_InActive"
        btnTab3_Contract.CssClass = "TabButton_InActive"
        btnTab4_NTP.CssClass = "TabButton_InActive"

        LoadTabs()
    End Sub
    Private Sub btnTab2_NOA_Click(sender As Object, e As EventArgs) Handles btnTab2_NOA.Click
        btnTab_Declaration.CssClass = "TabButton_InActive"
        btnTab_PostQua.CssClass = "TabButton_InActive"
        btnTab1_Resolution.CssClass = "TabButton_InActive"
        btnTab2_NOA.CssClass = "TabButton_Active"
        btnTab3_Contract.CssClass = "TabButton_InActive"
        btnTab4_NTP.CssClass = "TabButton_InActive"

        LoadTabs()
    End Sub
    Private Sub btnTab3_Contract_Click(sender As Object, e As EventArgs) Handles btnTab3_Contract.Click
        btnTab_Declaration.CssClass = "TabButton_InActive"
        btnTab_PostQua.CssClass = "TabButton_InActive"
        btnTab1_Resolution.CssClass = "TabButton_InActive"
        btnTab2_NOA.CssClass = "TabButton_InActive"
        btnTab3_Contract.CssClass = "TabButton_Active"
        btnTab4_NTP.CssClass = "TabButton_InActive"

        LoadTabs()
    End Sub
    Private Sub btnTab4_NTP_Click(sender As Object, e As EventArgs) Handles btnTab4_NTP.Click
        btnTab_Declaration.CssClass = "TabButton_InActive"
        btnTab_PostQua.CssClass = "TabButton_InActive"
        btnTab1_Resolution.CssClass = "TabButton_InActive"
        btnTab2_NOA.CssClass = "TabButton_InActive"
        btnTab3_Contract.CssClass = "TabButton_InActive"
        btnTab4_NTP.CssClass = "TabButton_Active"

        LoadTabs()
    End Sub



    Private Sub LoadTabs()
        If btnTab_Declaration.CssClass = "TabButton_Active" And btnTab_PostQua.CssClass = "TabButton_InActive" And btnTab1_Resolution.CssClass = "TabButton_InActive" And btnTab2_NOA.CssClass = "TabButton_InActive" And btnTab3_Contract.CssClass = "TabButton_InActive" And btnTab4_NTP.CssClass = "TabButton_InActive" Then

            LoadDeclaration()
            mvTabs.SetActiveView(Me.vwTab_Declaration)

        ElseIf btnTab_Declaration.CssClass = "TabButton_InActive" And btnTab_PostQua.CssClass = "TabButton_Active" And btnTab1_Resolution.CssClass = "TabButton_InActive" And btnTab2_NOA.CssClass = "TabButton_InActive" And btnTab3_Contract.CssClass = "TabButton_InActive" And btnTab4_NTP.CssClass = "TabButton_InActive" Then

            LoadPostQualification()
            mvTabs.SetActiveView(Me.vwTab_PostQua)

        ElseIf btnTab_Declaration.CssClass = "TabButton_InActive" And btnTab_PostQua.CssClass = "TabButton_InActive" And btnTab1_Resolution.CssClass = "TabButton_Active" And btnTab2_NOA.CssClass = "TabButton_InActive" And btnTab3_Contract.CssClass = "TabButton_InActive" And btnTab4_NTP.CssClass = "TabButton_InActive" Then

            LoadResolution()
            mvTabs.SetActiveView(Me.vwTab1_Reso)

        ElseIf btnTab_Declaration.CssClass = "TabButton_InActive" And btnTab_PostQua.CssClass = "TabButton_InActive" And btnTab1_Resolution.CssClass = "TabButton_InActive" And btnTab2_NOA.CssClass = "TabButton_Active" And btnTab3_Contract.CssClass = "TabButton_InActive" And btnTab4_NTP.CssClass = "TabButton_InActive" Then

            LoadNOA()
            mvTabs.SetActiveView(Me.vwTab2_NOA)

        ElseIf btnTab_Declaration.CssClass = "TabButton_InActive" And btnTab_PostQua.CssClass = "TabButton_InActive" And btnTab1_Resolution.CssClass = "TabButton_InActive" And btnTab2_NOA.CssClass = "TabButton_InActive" And btnTab3_Contract.CssClass = "TabButton_Active" And btnTab4_NTP.CssClass = "TabButton_InActive" Then

            LoadContract()
            mvTabs.SetActiveView(Me.vwTab3_Contract)

        ElseIf btnTab_Declaration.CssClass = "TabButton_InActive" And btnTab_PostQua.CssClass = "TabButton_InActive" And btnTab1_Resolution.CssClass = "TabButton_InActive" And btnTab2_NOA.CssClass = "TabButton_InActive" And btnTab3_Contract.CssClass = "TabButton_InActive" And btnTab4_NTP.CssClass = "TabButton_Active" Then

            LoadNTP()
            mvTabs.SetActiveView(Me.vwTab4_NTP)

        Else

        End If
    End Sub


    '----------- DECLARITION
    Private Sub LoadDeclaration()
        Try
            dtDeclaration = objDerived.GetDataTable("EXEC [AMS].[sp_Infra_Notices] 'Declaration'", CommandType.Text)
            If dtDeclaration.Rows.Count < 5 Then
                dtDeclaration.Merge(dtTemp_declaration(4 - dtDeclaration.Rows.Count))
            End If
            grdDeclaration.DataSource = dtDeclaration
            grdDeclaration.DataBind()
            grdDeclaration.SelectedIndex = -1

            grdDeclaration_Bidders.DataSource = dtTemp_DeclarationBidders(2)
            grdDeclaration_Bidders.DataBind()

            txtDate_Declaration.Text = Date.Today.ToShortDateString

        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        End Try

    End Sub
    Private Sub btnDeclaration_Search_Click(sender As Object, e As EventArgs) Handles btnDeclaration_Search.Click
        Try

            Dim myview As DataView
            myview = dtDeclaration.DefaultView

            If drpDeclaration_Search.SelectedItem.Value = 1 Then
                myview.RowFilter = "ITB_No like '%" & replaceapostrophe(txtDeclaration_Search.Text) & "%'"
            Else
                myview.RowFilter = "PPA like '%" & replaceapostrophe(txtDeclaration_Search.Text) & "%'"
            End If

            grdDeclaration.DataSource = myview
            grdDeclaration.DataBind()
            grdDeclaration.SelectedIndex = -1

            grdDeclaration_Bidders.DataSource = dtTemp_DeclarationBidders(2)
            grdDeclaration_Bidders.DataBind()

        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        End Try
    End Sub
    Private Sub grdDeclaration_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles grdDeclaration.PageIndexChanging
        grdDeclaration.DataSource = dtDeclaration
        grdDeclaration.PageIndex = e.NewPageIndex
        grdDeclaration.DataBind()
        grdDeclaration.SelectedIndex = -1
    End Sub
    Private Sub grdDeclaration_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grdDeclaration.SelectedIndexChanged
        Try
            Try

                dtDeclarationBidders = objDerived.GetDataTable("SELECT A.Infra_Bidders_ID, A.Supplier_ID, B.SuppName, A.BidAmount, CONVERT(BIT,1) AS isVisible FROM [AMS].[tbl_Infra_Bidding] AS A " &
                                " INNER JOIN DBO.Supplier AS B ON A.Supplier_ID = B.Supplier_Id WHERE A.Infra_BidPrep_ID = '" & grdDeclaration.SelectedDataKey("Infra_BidPrep_ID") & "' ORDER BY B.SuppName", CommandType.Text)
                grdDeclaration_Bidders.DataSource = dtDeclarationBidders
                grdDeclaration_Bidders.DataBind()

                btnDeclaration_Save.Enabled = True

            Catch ex As Exception
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
            End Try


        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        End Try
    End Sub
    Protected Sub drpDeclaration_Passed_Changed(ByVal sender As Object, ByVal e As System.EventArgs)

        Dim drp As DropDownList = TryCast(sender, DropDownList)
        Dim grd As GridViewRow = TryCast(drp.NamingContainer, GridViewRow)
        Dim rw = grd.DataItemIndex

        If drp.SelectedValue = 2 Then
            CType(grdDeclaration_Bidders.Rows(rw).FindControl("drpDeclaration_Winner"), DropDownList).SelectedValue = 1
            CType(grdDeclaration_Bidders.Rows(rw).FindControl("drpDeclaration_Winner"), DropDownList).Enabled = False

        Else
            CType(grdDeclaration_Bidders.Rows(rw).FindControl("drpDeclaration_Winner"), DropDownList).Enabled = True

        End If

    End Sub
    Protected Sub drpDeclaration_Winner_Changed(ByVal sender As Object, ByVal e As System.EventArgs)

        Dim drp As DropDownList = TryCast(sender, DropDownList)
        Dim grd As GridViewRow = TryCast(drp.NamingContainer, GridViewRow)
        Dim rw = grd.DataItemIndex

        For i As Integer = 0 To grdDeclaration_Bidders.Rows.Count - 1
            If i <> rw Then
                CType(grdDeclaration_Bidders.Rows(i).FindControl("drpDeclaration_Winner"), DropDownList).SelectedValue = 1
            End If
        Next
    End Sub
    Private Sub btnDeclaration_Save_Click(sender As Object, e As EventArgs) Handles btnDeclaration_Save.Click
        Try
            Dim withPassed As Boolean = False
            Dim withWinner As Boolean = False

            For i As Integer = 0 To grdDeclaration_Bidders.Rows.Count - 1
                If CType(grdDeclaration_Bidders.Rows(i).FindControl("drpDeclaration_Passed"), DropDownList).SelectedItem.Text = "Passed" Then
                    withPassed = True
                End If

                If CType(grdDeclaration_Bidders.Rows(i).FindControl("drpDeclaration_Winner"), DropDownList).SelectedItem.Text = "Winner" Then
                    withWinner = True
                End If
            Next


            If withPassed = False Or withWinner = False Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "There should be at least 1 Rate as Passed and declared as Winner before saving.")

            Else

                For i As Integer = 0 To grdDeclaration_Bidders.Rows.Count - 1
                    Dim isWinner As Boolean = IIf(CType(grdDeclaration_Bidders.Rows(i).FindControl("drpDeclaration_Winner"), DropDownList).SelectedItem.Text = "Winner", True, False)
                    Dim ResponsiveBid As String
                    If isWinner = True Then
                        ResponsiveBid = drpDeclaration_ResponsiveBid.SelectedItem.Text
                    Else
                        ResponsiveBid = ""
                    End If

                    objDerived.Execute("UPDATE [AMS].[tbl_Infra_Bidding] SET [Reso_Rate] = '" & CType(grdDeclaration_Bidders.Rows(i).FindControl("drpDeclaration_Passed"), DropDownList).SelectedItem.Text & "', [Reso_Remarks] = '" & replaceapostrophe(CType(grdDeclaration_Bidders.Rows(i).FindControl("txtDeclaration_Remarks"), TextBox).Text) & "', [Reso_isWinner] = '" & isWinner & "', ResponsiveBid = '" & ResponsiveBid & "' WHERE [Infra_Bidders_ID] = '" & dtDeclarationBidders.Rows(i)("Infra_Bidders_ID") & "'", CommandType.Text)
                Next


                objDerived.Execute("UPDATE [AMS].[tbl_Infra_BidPreparation] SET [withWinner] = 1 WHERE [Infra_BidPrep_ID] = '" & grdDeclaration.SelectedDataKey("Infra_BidPrep_ID") & "'", CommandType.Text)


                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")
                btnDeclaration_Save.Enabled = False
                LoadDeclaration()


            End If

        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        End Try
    End Sub





    '------ POST QUALIFICATION
    Private Sub LoadPostQualification()
        Try

            dtPostQua = objDerived.GetDataTable("EXEC [AMS].[sp_Infra_Notices] 'PostQua'", CommandType.Text)
            If dtPostQua.Rows.Count < 5 Then
                dtPostQua.Merge(dtTemp_PostQua(4 - dtPostQua.Rows.Count))
            End If
            grdPostQua.DataSource = dtPostQua
            grdPostQua.DataBind()
            grdPostQua.SelectedIndex = -1

        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        End Try
    End Sub
    Private Sub btnPostQua_Search_Click(sender As Object, e As EventArgs) Handles btnPostQua_Search.Click
        Try
            Dim myview As DataView
            myview = dtPostQua.DefaultView

            If drpPostQua_Search.SelectedItem.Value = 1 Then
                myview.RowFilter = "ITB_No like '%" & replaceapostrophe(txtPostQua_Search.Text) & "%'"
            ElseIf drpPostQua_Search.SelectedItem.Value = 2 Then
                myview.RowFilter = "PPA like '%" & replaceapostrophe(txtPostQua_Search.Text) & "%'"
            End If

            grdPostQua.DataSource = myview
            grdPostQua.DataBind()
            grdPostQua.SelectedIndex = -1

        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        End Try
    End Sub
    Private Sub grdPostQua_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles grdPostQua.PageIndexChanging
        grdPostQua.DataSource = dtPostQua
        grdPostQua.PageIndex = e.NewPageIndex
        grdPostQua.DataBind()
        grdPostQua.SelectedIndex = -1
    End Sub
    Private Sub grdPostQua_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grdPostQua.SelectedIndexChanged
        Try

            txtDate_PostQua.Text = Date.Today.ToShortDateString
            txtDate_DocsReq.Text = Date.Today.ToShortDateString
            txtDate_PeriodFrom.Text = Date.Today.ToShortDateString
            txtDate_PeriodTo.Text = Date.Today.ToShortDateString
            txtDate_Result.Text = Date.Today.ToShortDateString

            lblPostQua_Read.Text = FormatNumber(grdPostQua.SelectedDataKey("BidAmount"), 2)
            lblPostQua_Calculated.Text = FormatNumber(grdPostQua.SelectedDataKey("BidAmount"), 2)
            lblPostQua_V_Bidder.Text = grdPostQua.SelectedDataKey("SuppName")


            Dim dt As New DataTable
            dt = objDerived.GetDataTable("SELECT C.ProjectName, B.SuppName, A.BidAmount " &
                                       "     , 'NOW THEREFORE, the TWG RESOLVE, as it hereby RESOLVED, to recommend for APPROVAL to BAC the award of Contract for the ' + C.ProjectName + ' in favour of ' + B.SuppName + ' as the Lowest Calculated and Responsive Bidder as to price/cost and specifications in the amount of '   " &
                                       "         + CASE WHEN RIGHT( A.BidAmount,2) = '00' THEN (SELECT DBO.Num_ToWords ( A.BidAmount)) + ' PESOS'                                                                                                                                                                                   " &
                                       "         ELSE  (SELECT DBO.Num_ToWords ( A.BidAmount)) + ' PESOS and ' + (SELECT DBO.Num_ToWords (RIGHT( A.BidAmount,2)) + ' CENTAVOS') END + ' (Php ' + FORMAT( A.BidAmount, 'N2') + ') ' AS Resolved1                                                                                     " &
                                       "     , 'Issued by the Technical Working Group this ' + CAST(CONVERT(VARCHAR(20),GETDATE(),107) AS VARCHAR(200)) + ' in the City of Pasay.' AS Resolved2                                                                                                                                     " &
                                       " FROM AMS.tbl_Infra_Bidding AS A INNER JOIN DBO.Supplier AS B ON A.Supplier_ID = B.Supplier_Id INNER JOIN AMS.tbl_Infra_BidPreparation AS C ON A.Infra_BidPrep_ID = C.Infra_BidPrep_ID                                                                                                      " &
                                       " WHERE A.Infra_Bidders_ID = '" & grdPostQua.SelectedDataKey("Infra_Bidders_ID") & "'", CommandType.Text)


            txtPostQua_ThereFore.Text = dt.Rows(0)("Resolved1") & vbCrLf & vbCrLf & dt.Rows(0)("Resolved2")

            btnSave_PostQua.Enabled = True
            btnPreview_PostQua.Enabled = False

        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        End Try
    End Sub
    Private Sub btnSave_PostQua_Click(sender As Object, e As EventArgs) Handles btnSave_PostQua.Click
        Try

            objDerived.Execute("INSERT INTO [AMS].[tbl_Infra_PostQua] ([Infra_BidPrep_ID],[postqua_date],[Supplier_ID],[date_docs],[date_period1],[date_period2],[date_result],[legal_a]            " &
                         "  ,[legal_b],[legal_c],[legal_e],[tech_f],[tech_g],[tech_h],[tech_i1],[tech_i2],[tech_i3],[tech_i4],[tech_i5],[tech_i6],[tech_j1],[tech_j2],[fin_k],[fin_l]               " &
                         "  ,[finCom_a],[finCom_b],[finCom_c],[post_a],[post_b],[post_c],[iv_findings],[v_findings],[v_grounds],[therefore],[legal_a_Findngs],[legal_b_Findngs],[legal_c_Findngs]   " &
                         "  ,[legal_e_Findngs],[tech_f_Findngs],[tech_g_Findngs],[tech_h_Findngs],[tech_i1_Findngs],[tech_i2_Findngs],[tech_i3_Findngs],[tech_i4_Findngs],[tech_i5_Findngs]         " &
                         "  ,[tech_i6_Findngs],[tech_j1_Findngs],[tech_j2_Findngs],[fin_k_Findngs],[fin_l_Findngs],[finCom_a_Findngs],[finCom_b_Findngs],[finCom_c_Findngs],[post_a_Findngs]        " &
                         "  ,[post_b_Findngs],[post_c_Findngs]) " &
                         "  VALUES                              " &
                         "  ('" & grdPostQua.SelectedDataKey("Infra_BidPrep_ID") & "'           " &
                         "  ,'" & txtDate_PostQua.Text & "'          " &
                         "  ,'" & grdPostQua.SelectedDataKey("Supplier_ID") & "'                " &
                         "  ,'" & CType(txtDate_DocsReq.Text, Date) & "'             " &
                         "  ,'" & CType(txtDate_PeriodFrom.Text, Date) & "'          " &
                         "  ,'" & CType(txtDate_PeriodTo.Text, Date) & "'          " &
                         "  ,'" & CType(txtDate_Result.Text, Date) & "'           " &
                         "  ,'" & replaceapostrophe(txt_RemarksA.Text) & "'          " &
                         "  ,'" & replaceapostrophe(txt_RemarksB.Text) & "'           " &
                         "  ,'" & replaceapostrophe(txt_RemarksC.Text) & "'           " &
                         "  ,'" & replaceapostrophe(txt_RemarksD.Text) & "'           " &
                         "  ,'" & replaceapostrophe(txt_RemarksF.Text) & "'            " &
                         "  ,'" & replaceapostrophe(txt_RemarksG.Text) & "'            " &
                         "  ,'" & replaceapostrophe(txt_RemarksH.Text) & "'            " &
                         "  ,'" & replaceapostrophe(txt_RemarksI1.Text) & "'           " &
                         "  ,'" & replaceapostrophe(txt_RemarksI2.Text) & "'            " &
                         "  ,'" & replaceapostrophe(txt_RemarksI3.Text) & "'            " &
                         "  ,'" & replaceapostrophe(txt_RemarksI4.Text) & "'            " &
                         "  ,'" & replaceapostrophe(txt_RemarksI5.Text) & "'            " &
                         "  ,'" & replaceapostrophe(txt_RemarksI6.Text) & "'            " &
                         "  ,'" & replaceapostrophe(txt_RemarksJ1.Text) & "'           " &
                         "  ,'" & replaceapostrophe(txt_RemarksJ2.Text) & "'            " &
                         "  ,'" & replaceapostrophe(txt_RemarksK.Text) & "'             " &
                         "  ,'" & replaceapostrophe(txt_RemarksL.Text) & "'             " &
                         "  ,'" & replaceapostrophe(txt_Remarks2A.Text) & "'          " &
                         "  ,'" & replaceapostrophe(txt_Remarks2B.Text) & "'          " &
                         "  ,'" & replaceapostrophe(txt_Remarks2C.Text) & "'         " &
                         "  ,'" & replaceapostrophe(txt_Remarks3A.Text) & "'            " &
                         "  ,'" & replaceapostrophe(txt_Remarks3B.Text) & "'            " &
                         "  ,'" & replaceapostrophe(txt_Remarks3C.Text) & "'            " &
                         "  ,'" & replaceapostrophe(txtPostQua_IV_Findings.Text) & "'      " &
                         "  ,'" & replaceapostrophe(txtPostQua_V_Findings.Text) & "'        " &
                         "  ,'" & replaceapostrophe(txtPostQua_V_Grounds.Text) & "'         " &
                         "  ,'" & replaceapostrophe(txtPostQua_ThereFore.Text) & "'       " &
                         "  ,'" & replaceapostrophe(txt_FindingsA.Text) & "'              " &
                         "  ,'" & replaceapostrophe(txt_FindingsB.Text) & "'             " &
                         "  ,'" & replaceapostrophe(txt_FindingsC.Text) & "'              " &
                         "  ,'" & replaceapostrophe(txt_FindingsD.Text) & "'              " &
                         "  ,'" & replaceapostrophe(txt_FindingsF.Text) & "'               " &
                         "  ,'" & replaceapostrophe(txt_FindingsG.Text) & "'               " &
                         "  ,'" & replaceapostrophe(txt_FindingsH.Text) & "'               " &
                         "  ,'" & replaceapostrophe(txt_FindingsI1.Text) & "'              " &
                         "  ,'" & replaceapostrophe(txt_FindingsI2.Text) & "'              " &
                         "  ,'" & replaceapostrophe(txt_FindingsI3.Text) & "'              " &
                         "  ,'" & replaceapostrophe(txt_FindingsI4.Text) & "'              " &
                         "  ,'" & replaceapostrophe(txt_FindingsI5.Text) & "'              " &
                         "  ,'" & replaceapostrophe(txt_FindingsI6.Text) & "'              " &
                         "  ,'" & replaceapostrophe(txt_FindingsJ1.Text) & "'              " &
                         "  ,'" & replaceapostrophe(txt_FindingsJ2.Text) & "'              " &
                         "  ,'" & replaceapostrophe(txt_FindingsK.Text) & "'                " &
                         "  ,'" & replaceapostrophe(txt_FindingsL.Text) & "'                " &
                         "  ,'" & replaceapostrophe(txt_Findings2A.Text) & "'             " &
                         "  ,'" & replaceapostrophe(txt_Findings2B.Text) & "'             " &
                         "  ,'" & replaceapostrophe(txt_Findings2C.Text) & "'             " &
                         "  ,'" & replaceapostrophe(txt_Findings3A.Text) & "'               " &
                         "  ,'" & replaceapostrophe(txt_Findings3B.Text) & "'               " &
                         "  ,'" & replaceapostrophe(txt_Findings3C.Text) & "')", CommandType.Text)

            Session("infa_postqua_ID") = objDerived.GetValue("SELECT TOP(1) infa_postqua_ID FROM AMS.tbl_Infra_PostQua ORDER BY infa_postqua_ID DESC", CommandType.Text)

            objDerived.Execute("UPDATE [AMS].[tbl_Infra_BidPreparation] SET [withPostQua] = 1 WHERE [Infra_BidPrep_ID] = '" & grdPostQua.SelectedDataKey("Infra_BidPrep_ID") & "'", CommandType.Text)


            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Post Qualification has been successfully saved.")
            btnSave_PostQua.Enabled = False
            btnPreview_PostQua.Enabled = True
            LoadPostQualification()

        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        End Try
    End Sub
    Private Sub btnPreview_PostQua_Click(sender As Object, e As EventArgs) Handles btnPreview_PostQua.Click

    End Sub






    '----------- RESOLUTION
    Private Sub LoadResolution()
        Try
            dtResolution = objDerived.GetDataTable("EXEC [AMS].[sp_Infra_Notices] 'Resolution'", CommandType.Text)
            If dtResolution.Rows.Count < 5 Then
                dtResolution.Merge(dtTemp_Reso(4 - dtResolution.Rows.Count))
            End If
            grdResolution.DataSource = dtResolution
            grdResolution.DataBind()
            grdResolution.SelectedIndex = -1

            txtReso_Date.Text = Date.Today.ToShortDateString

        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        End Try

    End Sub
    Private Sub btnReso_Search_Click(sender As Object, e As EventArgs) Handles btnReso_Search.Click
        Try

            Dim myview As DataView
            myview = dtResolution.DefaultView

            If drpReso_Search.SelectedItem.Value = 1 Then
                myview.RowFilter = "ITB_No like '%" & replaceapostrophe(txtReso_Search.Text) & "%'"
            Else
                myview.RowFilter = "PPA like '%" & replaceapostrophe(txtReso_Search.Text) & "%'"
            End If

            grdResolution.DataSource = myview
            grdResolution.DataBind()



        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        End Try
    End Sub
    Private Sub grdResolution_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles grdResolution.PageIndexChanging
        grdResolution.DataSource = dtResolution
        grdResolution.PageIndex = e.NewPageIndex
        grdResolution.DataBind()
        grdResolution.SelectedIndex = -1
    End Sub
    Private Sub grdResolution_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grdResolution.SelectedIndexChanged
        Try
            txtReso_ResponsiveBid.Text = grdResolution.SelectedDataKey("ResponsiveBid")

            drpReso_BACVC.DataSource = objDerived.GetDataTable("SELECT TOP(1) * FROM [dbo].[View_BAC] WHERE [isActive] = 1 AND [isDefault] = 1 AND [BAC_PostionID] = 2", CommandType.Text)
            drpReso_BACVC.DataTextField = ("Name")
            drpReso_BACVC.DataValueField = ("empsig_id")
            drpReso_BACVC.DataBind()

            drpReso_BACC.DataSource = objDerived.GetDataTable("SELECT TOP(1) * FROM [dbo].[View_BAC] WHERE [isActive] = 1 AND [isDefault] = 1 AND [BAC_PostionID] = 1", CommandType.Text)
            drpReso_BACC.DataTextField = ("Name")
            drpReso_BACC.DataValueField = ("empsig_id")
            drpReso_BACC.DataBind()

            drpReso_GSO.DataSource = objDerived.GetDataTable("SELECT TOP(1) Full_Name, EmpID, position_desc FROM HRMS.view_signatory WHERE isDeptHead = 'Yes' AND deptid = 7 AND division_Key = 86 ", CommandType.Text)
            drpReso_GSO.DataTextField = ("Full_Name")
            drpReso_GSO.DataValueField = ("EmpID")
            drpReso_GSO.DataBind()

            drpReso_CBO.DataSource = objDerived.GetDataTable("SELECT TOP(1) Full_Name, EmpID, position_desc FROM HRMS.view_signatory WHERE isDeptHead = 'Yes' AND deptid = 8 AND division_Key = 86 ", CommandType.Text)
            drpReso_CBO.DataTextField = ("Full_Name")
            drpReso_CBO.DataValueField = ("EmpID")
            drpReso_CBO.DataBind()

            drpReso_CEO.DataSource = objDerived.GetDataTable("SELECT TOP(1) Full_Name, EmpID, position_desc FROM HRMS.view_signatory WHERE isDeptHead = 'Yes' AND deptid = 27 AND division_Key = 86 ", CommandType.Text)
            drpReso_CEO.DataTextField = ("Full_Name")
            drpReso_CEO.DataValueField = ("EmpID")
            drpReso_CEO.DataBind()

            drpReso_EndUser.DataSource = objDerived.GetDataTable("SELECT Full_Name, EmpID FROM HRMS.view_signatory WHERE deptid = '" & grdResolution.SelectedDataKey("RC_ID") & "' AND division_Key = '" & grdResolution.SelectedDataKey("Function_ID") & "' ORDER BY isDeptHead DESC, Full_Name", CommandType.Text)
            drpReso_EndUser.DataTextField = ("Full_Name")
            drpReso_EndUser.DataValueField = ("EmpID")
            drpReso_EndUser.DataBind()

            drpReso_Approvedby.DataSource = objDerived.GetDataTable("SELECT TOP(1) Full_Name, EmpID FROM HRMS.view_signatory WHERE deptid = 1 AND division_Key = 86 AND isDeptHead = 'Yes'", CommandType.Text)
            drpReso_Approvedby.DataTextField = ("Full_Name")
            drpReso_Approvedby.DataValueField = ("EmpID")
            drpReso_Approvedby.DataBind()

            drpReso_EndUser.DataSource = objDerived.GetDataTable("SELECT TOP(1) Full_Name, EmpID FROM HRMS.view_signatory WHERE deptid = '" & grdResolution.SelectedDataKey("RC_ID") & "' AND division_Key = '" & grdResolution.SelectedDataKey("Function_ID") & "' AND isDeptHead = 'Yes'", CommandType.Text)
            drpReso_EndUser.DataTextField = ("Full_Name")
            drpReso_EndUser.DataValueField = ("EmpID")
            drpReso_EndUser.DataBind()


            btnReso_Save.Enabled = True
            btnReso_Preview.Enabled = False

        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        End Try
    End Sub

    Private Sub btnReso_Save_Click(sender As Object, e As EventArgs) Handles btnReso_Save.Click
        Try

            objDerived.Execute("INSERT INTO [AMS].[tbl_Infra_Resolution] ([Infra_BidPrep_ID],[Reso_Date],[Reso_No],[Supplier_ID],[BidAmount],[ResponsiveBid],[BACC],[BACVC],[CBO],[GSO],[CEO],[Approvedby],[EndUser]) " &
                                       " VALUES                         " &
                                       " ('" & grdResolution.SelectedDataKey("Infra_BidPrep_ID") & "'      " &
                                       " ,'" & CType(txtReso_Date.Text, Date) & "'                       " &
                                       " ,'" & replaceapostrophe(txtReso_No.Text) & "'              " &
                                       " ,'" & grdResolution.SelectedDataKey("Supplier_ID") & "'    " &
                                       " ,'" & grdResolution.SelectedDataKey("BidAmount") & "'          " &
                                       " ,'" & txtReso_ResponsiveBid.Text & "'                      " &
                                       " ,'" & drpReso_BACC.SelectedItem.Value & "'                  " &
                                       " ,'" & drpReso_BACVC.SelectedItem.Value & "'                " &
                                       " ,'" & drpReso_CBO.SelectedItem.Value & "'                  " &
                                       " ,'" & drpReso_GSO.SelectedItem.Value & "'                   " &
                                       " ,'" & drpReso_CEO.SelectedItem.Value & "'                   " &
                                       " ,'" & drpReso_Approvedby.SelectedItem.Value & "'            " &
                                       " ,'" & drpReso_EndUser.SelectedItem.Value & "')", CommandType.Text)


            objDerived.Execute("UPDATE [AMS].[tbl_Infra_BidPreparation] SET [withResolution] = 1 WHERE [Infra_BidPrep_ID] = '" & grdResolution.SelectedDataKey("Infra_BidPrep_ID") & "'", CommandType.Text)

            Session("Infra_BidPrep_ID") = grdResolution.SelectedDataKey("Infra_BidPrep_ID")

            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")
            btnReso_Save.Enabled = False
            btnReso_Preview.Enabled = True
            LoadResolution()

        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        End Try
    End Sub
    Private Sub btnReso_Preview_Click(sender As Object, e As EventArgs) Handles btnReso_Preview.Click
        Session("Report") = "Resolution"
        Session("Page") = "Infra_Notice"

        Dim url As String = "../../MainReports/rpt_Infra_Reports.aspx"
        Dim fullurl As String = " var win= window.open('" + url + "', '_blank');"
        ScriptManager.RegisterStartupScript(Me, GetType(String), "OPEN_WINDOW", fullurl, True)
    End Sub




    '----------- NOTICE OF AWARD
    Private Sub LoadNOA()
        Try

            dtNOA = objDerived.GetDataTable("EXEC [AMS].[sp_Infra_Notices] 'NOA'", CommandType.Text)
            If dtNOA.Rows.Count < 5 Then
                dtNOA.Merge(dtTemp_Notice(4 - dtNOA.Rows.Count))
            End If
            grdNOA.DataSource = dtNOA
            grdNOA.DataBind()
            grdNOA.SelectedIndex = -1

            drpNOA_Approvedby.DataSource = objDerived.GetDataTable("SELECT EmpID, Full_Name FROM HRMS.view_signatory WHERE deptid = 1 AND division_Key = 86 AND isDeptHead = 'Yes'", CommandType.Text)
            drpNOA_Approvedby.DataTextField = "Full_Name"
            drpNOA_Approvedby.DataValueField = "EmpID"
            drpNOA_Approvedby.DataBind()


        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        End Try
    End Sub
    Private Sub btnNOA_Search_Click(sender As Object, e As EventArgs) Handles btnNOA_Search.Click
        Try

            Dim myview As DataView
            myview = dtNOA.DefaultView

            If drpNOA_Search.SelectedItem.Value = 1 Then
                myview.RowFilter = "ITB_No like '%" & replaceapostrophe(txtNOA_Search.Text) & "%'"
            Else
                myview.RowFilter = "PPA like '%" & replaceapostrophe(txtNOA_Search.Text) & "%'"
            End If

            grdNOA.DataSource = myview
            grdNOA.DataBind()

        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        End Try
    End Sub
    Private Sub grdNOA_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles grdNOA.PageIndexChanging
        grdNOA.DataSource = dtNOA
        grdNOA.PageIndex = e.NewPageIndex
        grdNOA.DataBind()
    End Sub
    Private Sub grdNOA_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grdNOA.SelectedIndexChanged
        Try

            txtNOA_Date.Text = Date.Today.ToShortDateString

            btnNOA_Save.Enabled = True
            btnNOA_Preview.Enabled = False

        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        End Try
    End Sub
    Private Sub btnNOA_Save_Click(sender As Object, e As EventArgs) Handles btnNOA_Save.Click
        Try
            Session("Infra_BidPrep_ID") = grdNOA.SelectedDataKey("Infra_BidPrep_ID")

            objDerived.Execute("INSERT INTO [AMS].[tbl_Infra_NOA] ([Infra_BidPrep_ID],[NOA_Date],[Approvedby]) " &
                                  "  VALUES                     " &
                                  "  ('" & grdNOA.SelectedDataKey("Infra_BidPrep_ID") & "'  " &
                                  "  ,'" & CType(txtNOA_Date.Text, Date) & "'     " &
                                  "  ,'" & drpNOA_Approvedby.SelectedItem.Value & "')", CommandType.Text)

            objDerived.Execute("UPDATE AMS.tbl_Infra_BidPreparation SET withNOA = 1 WHERE Infra_BidPrep_ID = '" & grdNOA.SelectedDataKey("Infra_BidPrep_ID") & "'", CommandType.Text)

            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")
            LoadNOA()

            btnNOA_Save.Enabled = False
            btnNOA_Preview.Enabled = True

        Catch ex As Exception
            objDerived.Execute("DELETE FROM [AMS].[tbl_Infra_NOA] WHERE [Infra_BidPrep_ID] = '" & grdNOA.SelectedDataKey("Infra_BidPrep_ID") & "'", CommandType.Text)
            objDerived.Execute("UPDATE AMS.tbl_Infra_BidPreparation SET withNOA = 0 WHERE Infra_BidPrep_ID = '" & grdNOA.SelectedDataKey("Infra_BidPrep_ID") & "'", CommandType.Text)
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        End Try
    End Sub
    Private Sub btnNOA_Preview_Click(sender As Object, e As EventArgs) Handles btnNOA_Preview.Click
        Session("Report") = "NOA"
        Session("Page") = "Infra_Notice"

        Dim url As String = "../../MainReports/rpt_Infra_Reports.aspx"
        Dim fullurl As String = " var win= window.open('" + url + "', '_blank');"
        ScriptManager.RegisterStartupScript(Me, GetType(String), "OPEN_WINDOW", fullurl, True)
    End Sub




    '----------- CONTRACT
    Private Sub LoadContract()
        Try

            dtContract = objDerived.GetDataTable("EXEC [AMS].[sp_Infra_Notices] 'Contract'", CommandType.Text)
            If dtContract.Rows.Count < 5 Then
                dtContract.Merge(dtTemp_Notice(4 - dtContract.Rows.Count))
            End If
            grdContract.DataSource = dtContract
            grdContract.DataBind()
            grdContract.SelectedIndex = -1

            drpContract_Aprpovedby.DataSource = objDerived.GetDataTable("SELECT EmpID, Full_Name FROM HRMS.view_signatory WHERE deptid = 1 AND division_Key = 86 AND isDeptHead = 'Yes'", CommandType.Text)
            drpContract_Aprpovedby.DataTextField = "Full_Name"
            drpContract_Aprpovedby.DataValueField = "EmpID"
            drpContract_Aprpovedby.DataBind()


        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        End Try
    End Sub
    Private Sub btnContract_Search_Click(sender As Object, e As EventArgs) Handles btnContract_Search.Click
        Try

            Dim myview As DataView
            myview = dtContract.DefaultView

            If drpContract_Search.SelectedItem.Value = 1 Then
                myview.RowFilter = "ITB_No like '%" & replaceapostrophe(txtContract_Search.Text) & "%'"
            Else
                myview.RowFilter = "PPA like '%" & replaceapostrophe(txtContract_Search.Text) & "%'"
            End If

            grdContract.DataSource = myview
            grdContract.DataBind()

        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        End Try
    End Sub
    Private Sub grdContract_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles grdContract.PageIndexChanging
        grdContract.DataSource = dtContract
        grdContract.PageIndex = e.NewPageIndex
        grdContract.DataBind()
    End Sub
    Private Sub grdContract_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grdContract.SelectedIndexChanged
        Try

            txtContract_Date.Text = Date.Today.ToShortDateString

            txtContractNo.Text = ""
            txtContract_Completion.Text = ""
            txtContractorID_No.Text = ""
            txtContractorID_Validity.Text = ""

            btnContract_Save.Enabled = True
            btnContract_Preview.Enabled = False

        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        End Try
    End Sub
    Private Sub btnContract_Save_Click(sender As Object, e As EventArgs) Handles btnContract_Save.Click
        Try

            objDerived.Execute("INSERT INTO [AMS].[tbl_Infra_Contract] ([Infra_BidPrep_ID],[Contract_Date],[ContractNo],[Supplier_ID],[ContractorID_No],[ContractorID_Validity],[Completion_Timeline],[Approvedby]) " &
                               " VALUES                                   " &
                               " ('" & grdContract.SelectedDataKey("Infra_BidPrep_ID") & "'                " &
                               " ,'" & CType(txtContract_Date.Text, Date) & "'              " &
                               " ,'" & replaceapostrophe(txtContractNo.Text) & "'             " &
                               " ,'" & grdContract.SelectedDataKey("Supplier_ID") & "'                     " &
                               " ,'" & txtContractorID_No.Text & "'         " &
                               " ,'" & txtContractorID_Validity.Text & "'   " &
                               " ,'" & replaceapostrophe(txtContract_Completion.Text) & "'    " &
                               " ,'" & drpContract_Aprpovedby.SelectedItem.Value & "')", CommandType.Text)

            objDerived.Execute("UPDATE AMS.tbl_Infra_BidPreparation SET withContract = 1 WHERE Infra_BidPrep_ID = '" & grdContract.SelectedDataKey("Infra_BidPrep_ID") & "'", CommandType.Text)

            Session("Infra_BidPrep_ID") = grdContract.SelectedDataKey("Infra_BidPrep_ID")

            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")
            LoadContract()

            btnContract_Save.Enabled = False
            btnContract_Preview.Enabled = True

        Catch ex As Exception
            objDerived.Execute("DELETE FROM [AMS].[tbl_Infra_Contract] WHERE [Infra_BidPrep_ID] = '" & grdContract.SelectedDataKey("Infra_BidPrep_ID") & "'", CommandType.Text)
            objDerived.Execute("UPDATE AMS.tbl_Infra_BidPreparation SET withContract = 0 WHERE Infra_BidPrep_ID = '" & grdContract.SelectedDataKey("Infra_BidPrep_ID") & "'", CommandType.Text)
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        End Try
    End Sub
    Private Sub btnContract_Preview_Click(sender As Object, e As EventArgs) Handles btnContract_Preview.Click
        Session("Report") = "Contract"
        Session("Page") = "Infra_Notice"

        Dim url As String = "../../MainReports/rpt_Infra_Reports.aspx"
        Dim fullurl As String = " var win= window.open('" + url + "', '_blank');"
        ScriptManager.RegisterStartupScript(Me, GetType(String), "OPEN_WINDOW", fullurl, True)
    End Sub



    '----------- NOTICE TO PROCEED
    Private Sub LoadNTP()
        Try

            dtNTP = objDerived.GetDataTable("EXEC [AMS].[sp_Infra_Notices] 'NTP'", CommandType.Text)
            If dtNTP.Rows.Count < 5 Then
                dtNTP.Merge(dtTemp_Notice(4 - dtNTP.Rows.Count))
            End If
            grdNTP.DataSource = dtNTP
            grdNTP.DataBind()
            grdNTP.SelectedIndex = -1

            drpNTP_Approvedby.DataSource = objDerived.GetDataTable("SELECT EmpID, Full_Name FROM HRMS.view_signatory WHERE deptid = 1 AND division_Key = 86 AND isDeptHead = 'Yes'", CommandType.Text)
            drpNTP_Approvedby.DataTextField = "Full_Name"
            drpNTP_Approvedby.DataValueField = "EmpID"
            drpNTP_Approvedby.DataBind()


        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        End Try
    End Sub
    Private Sub btnNTP_Search_Click(sender As Object, e As EventArgs) Handles btnNTP_Search.Click
        Try

            Dim myview As DataView
            myview = dtNTP.DefaultView

            If drpNTP_Search.SelectedItem.Value = 1 Then
                myview.RowFilter = "ITB_No like '%" & replaceapostrophe(txtNTP_Search.Text) & "%'"
            Else
                myview.RowFilter = "PPA like '%" & replaceapostrophe(txtNTP_Search.Text) & "%'"
            End If

            grdNTP.DataSource = myview
            grdNTP.DataBind()

        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        End Try
    End Sub
    Private Sub grdNTP_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles grdNTP.PageIndexChanging
        grdNTP.DataSource = dtNTP
        grdNTP.PageIndex = e.NewPageIndex
        grdNTP.DataBind()
    End Sub
    Private Sub grdNTP_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grdNTP.SelectedIndexChanged
        Try

            txtNTP_Date.Text = Date.Today.ToShortDateString
            txtNTP_No.Text = ""

            btnNTP_Save.Enabled = True
            btnNTP_Preview.Enabled = False

        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        End Try
    End Sub
    Private Sub btnNTP_Save_Click(sender As Object, e As EventArgs) Handles btnNTP_Save.Click
        Try

            If txtNTP_No.Text = "" Then
                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "NTP number is required.")

            Else
                objDerived.Execute("INSERT INTO [AMS].[tbl_Infra_NTP] ([Infra_BidPrep_ID],[NTP_Date],[NTP_No],[Approvedby]) " &
                                   " VALUES                         " &
                                   " ('" & grdNTP.SelectedDataKey("Infra_BidPrep_ID") & "'      " &
                                   " ,'" & CType(txtNTP_Date.Text, Date) & "'         " &
                                   " ,'" & replaceapostrophe(txtNTP_No.Text) & "'        " &
                                   " ,'" & drpNTP_Approvedby.SelectedItem.Value & "')", CommandType.Text)

                objDerived.Execute("UPDATE AMS.tbl_Infra_BidPreparation SET withNTP = 1 WHERE Infra_BidPrep_ID = '" & grdNTP.SelectedDataKey("Infra_BidPrep_ID") & "'", CommandType.Text)

                Session("Infra_BidPrep_ID") = grdNTP.SelectedDataKey("Infra_BidPrep_ID")

                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")
                LoadNTP()

                txtNTP_No.Text = ""
                btnNTP_Save.Enabled = False
                btnNTP_Preview.Enabled = True
            End If



        Catch ex As Exception
            objDerived.Execute("DELETE FROM [AMS].[tbl_Infra_NTP] WHERE [Infra_BidPrep_ID] = '" & grdNTP.SelectedDataKey("Infra_BidPrep_ID") & "'", CommandType.Text)
            objDerived.Execute("UPDATE AMS.tbl_Infra_BidPreparation SET withNTP = 0 WHERE Infra_BidPrep_ID = '" & grdNTP.SelectedDataKey("Infra_BidPrep_ID") & "'", CommandType.Text)
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        End Try
    End Sub
    Private Sub btnNTP_Preview_Click(sender As Object, e As EventArgs) Handles btnNTP_Preview.Click
        Session("Report") = "NTP"
        Session("Page") = "Infra_Notice"

        Dim url As String = "../../MainReports/rpt_Infra_Reports.aspx"
        Dim fullurl As String = " var win= window.open('" + url + "', '_blank');"
        ScriptManager.RegisterStartupScript(Me, GetType(String), "OPEN_WINDOW", fullurl, True)
    End Sub


End Class
