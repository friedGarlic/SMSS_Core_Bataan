Imports System
Imports System.Data
Partial Class Reports_and_Query_t_Pre_Repair_Inspection
    Inherits System.Web.UI.Page
    Dim obj As New AccessRule
    Private objDerived As New DerivedDal



    Private Property dtDL() As DataTable
        Get
            Return CType(Session("dtDL"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtDL") = value
        End Set
    End Property
    Private Property dtProperty() As DataTable
        Get
            Return CType(Session("dtProperty"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtProperty") = value
        End Set
    End Property
    Public Function dtTemp_dtDL(ByVal row As Integer) As DataTable
        Dim dr As DataRow
        Dim dt As New DataTable
        Dim mycolumn As New DataColumn


        dt.Columns.Add("repair_hdr_id", GetType(Integer))
        dt.Columns.Add("repair_date", GetType(Date))
        dt.Columns.Add("RC_Name", GetType(String))
        dt.Columns.Add("GA_Code2", GetType(String))
        dt.Columns.Add("isVisible", GetType(Boolean))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("repair_hdr_id") = DBNull.Value
            dr("repair_date") = DBNull.Value
            dr("RC_Name") = DBNull.Value
            dr("GA_Code2") = DBNull.Value
            dr("isVisible") = False
            dt.Rows.Add(dr)
        Next
        Return dt
    End Function

    Public Function dtTemp_Property(ByVal row As Integer) As DataTable
        Dim dr As DataRow
        Dim dt As New DataTable
        Dim mycolumn As New DataColumn

        dt.Columns.Add("PropertyDetai_ID", GetType(Integer))
        dt.Columns.Add("Item_Desc", GetType(String))
        dt.Columns.Add("PropertyNo", GetType(String))
        dt.Columns.Add("SerialNo", GetType(String))
        dt.Columns.Add("previous_scope", GetType(String))
        dt.Columns.Add("nature_scope", GetType(String))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("PropertyDetai_ID") = DBNull.Value
            dr("Item_Desc") = DBNull.Value
            dr("PropertyNo") = DBNull.Value
            dr("SerialNo") = DBNull.Value
            dr("previous_scope") = DBNull.Value
            dr("nature_scope") = DBNull.Value
            dt.Rows.Add(dr)
        Next
        Return dt
    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then


            dtDL = objDerived.GetDataTable("SELECT A.repair_hdr_id, A.repair_date, CASE WHEN A.Function_ID = 86 THEN B.RC_Name ELSE B.Function_Desc END AS RC_Name, C.GA_Code2, CONVERT(BIT,1) AS isVisible" &
                                                "	FROM AMS.tbl_Repairs_Hdr AS A                                                                             " &
                                                "   INNER JOIN DBO.View_RespCenter_withFunctions AS B ON A.RC_ID = B.RC_ID AND A.Function_ID = B.Function_ID  " &
                                                "   INNER JOIN AMS.View_AccountList AS C ON A.GA_ID = C.GA_ID AND A.BGA_ID = C.BGA_ID                         " &
                                                "   WHERE A.isApproved = 1 AND A.isCancelled = 0 ORDER BY A.repair_date DESC", CommandType.Text)

            grdRepair.DataSource = dtDL
            grdRepair.DataBind()

            grdProperty.DataSource = dtTemp_Property(4)
            grdProperty.DataBind()



        End If

    End Sub


    Protected Sub grdRepair_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grdRepair.SelectedIndexChanged
        Try
            dtProperty = objDerived.GetDataTable("SELECT E.Item_Desc, C.PropertyNo, C.SerialNo, B.previous_scope, B.nature_scope, B.PropertyDetai_ID " &
                                                                  "  FROM AMS.tbl_Repairs_Hdr AS A                                                                   " &
                                                                  "  INNER JOIN AMS.tbl_Repairs_Dtl AS B ON A.repair_hdr_id = B.repair_hdr_id                        " &
                                                                  "  INNER JOIN AMS.Property_Dtl AS C ON B.PropertyDetai_ID = C.PropertyDetai_ID                     " &
                                                                  "  INNER JOIN AMS.Property AS D ON C.Property_ID = D.Property_ID                                   " &
                                                                  "  INNER JOIN AMS.View_ItemList AS E ON D.Item_ID = E.Item_ID                                      " &
                                                                  "  WHERE A.repair_hdr_id = '" & grdRepair.SelectedDataKey("repair_hdr_id") & "'             " &
                                                                  "  ORDER BY E.Item_Desc", CommandType.Text)

            GrdProperty.DataSource = dtProperty
            GrdProperty.DataBind()



        Catch ex As Exception
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Something went wrong, please contact system admin.")
        End Try

    End Sub
    Protected Sub rbSearch_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rbSearch.SelectedIndexChanged
        loadsearch()
    End Sub
    Public Sub loadsearch()
        Select Case (rbSearch.SelectedItem.Value)
            Case 1
                drpAccount.DataSource = objDerived.GetDataTable("SELECT (A.GA_Code2 + ' - ' + A.GA_Title2) AS GA_Title, A.GA_ID, A.BGA_ID, A.GA_Code, A.GA_Code2  FROM AMS.View_AccountList AS A WHERE A.AllotmentClass_ID = 3 AND A.BGA_ID = 0 ORDER BY A.GA_Title, A.GA_Code2", CommandType.Text)
                drpAccount.DataTextField = ("GA_Title")
                drpAccount.DataValueField = ("GA_ID")
                drpAccount.DataBind()
                drpAccount.Items.Insert(0, "Select")

                mvSearch.SetActiveView(Me.vwAccount)
            Case 2
                drpDepartment.DataSource = objDerived.GetDataTable("SELECT DISTINCT RC_Name, RC_ID FROM dbo.View_RespCenter_withFunctions WHERE Function_ID = 86 ORDER BY RC_Name", CommandType.Text)
                drpDepartment.DataTextField = ("RC_Name")
                drpDepartment.DataValueField = ("RC_ID")
                drpDepartment.DataBind()
                drpDepartment.Items.Insert(0, "Select")

                mvSearch.SetActiveView(Me.vwDepartment)


        End Select

    End Sub


    Protected Sub btnSearch_GA_Click(sender As Object, e As EventArgs) Handles btnSearch_GA.Click
        dtDL = objDerived.GetDataTable("SELECT A.repair_hdr_id, A.repair_date, CASE WHEN A.Function_ID = 86 THEN B.RC_Name ELSE B.Function_Desc END AS RC_Name, C.GA_Code2, CONVERT(BIT,1) AS isVisible" &
                                               "	FROM AMS.tbl_Repairs_Hdr AS A                                                                             " &
                                               "   INNER JOIN DBO.View_RespCenter_withFunctions AS B ON A.RC_ID = B.RC_ID AND A.Function_ID = B.Function_ID  " &
                                               "   INNER JOIN AMS.View_AccountList AS C ON A.GA_ID = C.GA_ID AND A.BGA_ID = C.BGA_ID                         " &
                                               "   WHERE A.isApproved = 1 AND A.isCancelled = 0 AND   c.GA_ID = " & drpAccount.SelectedItem.Value & "          " &
                                               "    ORDER BY A.repair_date DESC", CommandType.Text)

        grdRepair.DataSource = dtDL
        grdRepair.DataBind()

        grdProperty.DataSource = dtTemp_Property(4)
        grdProperty.DataBind()

    End Sub

    Protected Sub btnSearch_RC_Click(sender As Object, e As EventArgs) Handles btnSearch_RC.Click
        dtDL = objDerived.GetDataTable("SELECT A.repair_hdr_id, A.repair_date, CASE WHEN A.Function_ID = 86 THEN B.RC_Name ELSE B.Function_Desc END AS RC_Name, C.GA_Code2, CONVERT(BIT,1) AS isVisible" &
                                              "	FROM AMS.tbl_Repairs_Hdr AS A                                                                             " &
                                              "   INNER JOIN DBO.View_RespCenter_withFunctions AS B ON A.RC_ID = B.RC_ID AND A.Function_ID = B.Function_ID  " &
                                              "   INNER JOIN AMS.View_AccountList AS C ON A.GA_ID = C.GA_ID AND A.BGA_ID = C.BGA_ID                         " &
                                              "   WHERE A.isApproved = 1 AND A.isCancelled = 0 AND   B.RC_ID = " & drpDepartment.SelectedItem.Value & "          " &
                                              "    ORDER BY A.repair_date DESC", CommandType.Text)

        grdRepair.DataSource = dtDL
        grdRepair.DataBind()

        grdProperty.DataSource = dtTemp_Property(4)
        grdProperty.DataBind()
    End Sub
    Protected Sub BtnPreview_Click(sender As Object, e As EventArgs) Handles BtnPreview.Click
        Session("Report") = "PreRepair"
        Session("Page") = "PreRepairReport"
        Session("repair_hdr_id") = grdRepair.SelectedDataKey("repair_hdr_id")

        Me.Page.Response.Redirect("~/MainReports/RepairReports.aspx")
    End Sub

End Class



