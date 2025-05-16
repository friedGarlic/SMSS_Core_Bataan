Imports System.Data

Partial Class Reports_and_Query_WasteMaterials_Reports
    Inherits System.Web.UI.Page
    Private objDerived As New DerivedDal

    Private Property dtWaste() As DataTable
        Get
            Return CType(Session("dtWaste"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtWaste") = value
        End Set
    End Property
    Public Function tempTable_WMR(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("WMHdr_ID", GetType(Integer))
        dt.Columns.Add("WM_Date", GetType(Date))
        dt.Columns.Add("ctrl_no", GetType(String))
        dt.Columns.Add("RC_Name", GetType(String))
        dt.Columns.Add("isVisible", GetType(Boolean))

        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("WMHdr_ID") = DBNull.Value
            dr("WM_Date") = DBNull.Value
            dr("ctrl_no") = DBNull.Value
            dr("RC_Name") = DBNull.Value
            dr("isVisible") = False
            dt.Rows.Add(dr)
        Next
        Return dt
    End Function

    Private Sub Reports_and_Query_WasteMaterials_Reports_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

            dtWaste = objDerived.GetDataTable("SELECT A.WMHdr_ID, A.WM_Date, A.rc_id, CASE WHEN A.Function_ID = 86 THEN B.RC_Name ELSE B.Function_Desc END AS RC_Name, CONVERT(BIT,1) AS isVisible    " &
                                                  "  FROM AMS.WMR_Hdr AS A INNER JOIN DBO.View_RespCenter_withFunctions AS B ON A.RC_ID = B.RC_ID AND A.Function_ID = B.Function_ID                     " &
                                                  "  ORDER BY A.WM_Date DESC, A.rc_id DESC", CommandType.Text)

            If dtWaste.Rows.Count < 5 Then
                dtWaste.Merge(tempTable_WMR(4 - dtWaste.Rows.Count))
            End If
            grdWMR.DataSource = dtWaste
            grdWMR.DataBind()


        End If

        txtSearch.Attributes.Add("onkeypress", "return fun1(event,'" & btnSearch.ClientID & "')")
    End Sub
    Public Function replaceapostrophe(ByVal str As String) As String
        Return Replace(str, "'", "''")
    End Function
    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim myview As DataView
        myview = dtWaste.DefaultView

        If drpSearch.SelectedItem.Value = 2 Then
            myview.RowFilter = "RC_Name like '%" & replaceapostrophe(txtSearch.Text) & "%'"
        Else
            myview.RowFilter = "ctrl_no like '%" & replaceapostrophe(txtSearch.Text) & "%'"
        End If

        grdWMR.DataSource = myview
        grdWMR.DataBind()

    End Sub

    Private Sub grdWMR_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles grdWMR.PageIndexChanging
        grdWMR.DataSource = dtWaste
        grdWMR.PageIndex = e.NewPageIndex
        grdWMR.DataBind()
    End Sub

    Private Sub grdWMR_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grdWMR.SelectedIndexChanged
        Session("Page") = "RQ"
        Session("Report") = "WMR"
        Session("WMHdr_ID") = grdWMR.SelectedDataKey("WMHdr_ID")
        Me.Page.Response.Redirect("~/MainReports/Disposal_Notices.aspx")
    End Sub
End Class
