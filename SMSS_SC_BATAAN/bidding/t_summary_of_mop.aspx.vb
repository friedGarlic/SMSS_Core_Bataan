Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections.Hashtable
Imports System.Collections.DictionaryEntry
Imports System.Windows.Forms.Control
Partial Class bidding_t_summary_of_mop
    Inherits System.Web.UI.Page
    Private objDerived As New DerivedDal
    Dim obj As New AccessRule

#Region "property"
    Private Property pAMount() As DataTable
        Get
            Return CType(Session("pAMount"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pAMount") = value
        End Set
    End Property
    Private Property pData() As DataTable
        Get
            Return CType(Session("pData"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pData") = value
        End Set
    End Property
#End Region
#Region "Table"
    Public Function createdatatableMonitoring(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()

        dt.Columns.Add("pr_no", GetType(String))
        dt.Columns.Add("RC_Name", GetType(String))
        dt.Columns.Add("remarks", GetType(String))
        dt.Columns.Add("GA_Code", GetType(String))
        dt.Columns.Add("ABC", GetType(Decimal))


        For i As Integer = 0 To row
            dr = dt.NewRow

            dr("pr_no") = DBNull.Value
            dr("RC_Name") = DBNull.Value
            dr("remarks") = DBNull.Value
            dr("GA_Code") = DBNull.Value
            dr("ABC") = DBNull.Value
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            LoadMOD()
            loadData()


        End If
    End Sub
    Protected Sub loadData()
        pData = objDerived.GetDataTable("EXEC [AMS].[sp_Monitoring] '" & dd_mode_of_procurement.selecteditem.value & "'", CommandType.Text)
        'If pData.Rows.Count < 5 Then
        '    pData.Merge(createdatatableMonitoring(5 - pData.Rows.Count))
        'End If
        gvMonitoring.DataSource = pData
        gvMonitoring.DataBind()
        BindGridView()
    End Sub
    Protected Sub LoadMOD()
        pAMount = objDerived.GetDataTable("SELECT * FROM ams.mode_of_procurement", CommandType.Text)
        dd_mode_of_procurement.DataSource = pAMount
        dd_mode_of_procurement.DataTextField = ("mode_description2")
        dd_mode_of_procurement.DataValueField = ("mode_of_procurement_id")
        dd_mode_of_procurement.DataBind()
    End Sub
    Protected Sub BindGridView()
        ' Your existing code to bind data to gvMonitoring
        ' ...

        ' Calculate total - Assuming ABC is Decimal or Double
        Dim totalAmount As Decimal = 0
        For Each row As DataRow In pData.Rows ' Replace YourDataSource with the actual data source
            On Error Resume Next
            totalAmount += Convert.ToDecimal(row("ABC"))
        Next

        ' Store the total in ViewState to use later in RowDataBound
        ViewState("TotalAmount") = totalAmount

        gvMonitoring.DataBind()
    End Sub
    Protected Sub gvMonitoring_RowDataBound(sender As Object, e As GridViewRowEventArgs)
        Try
            If e.Row.RowType = DataControlRowType.Footer Then
                ' Assuming the ABC column is the last one, adjust the index as needed
                Dim cellIndex As Integer = 5 ' Index of ABC column, adjust based on your actual column index
                e.Row.Cells(4).Text = "Total : "
                e.Row.Cells(4).HorizontalAlign = HorizontalAlign.Right

                e.Row.Cells(cellIndex).Text = " " & val(ViewState("TotalAmount").ToString()).tostring("n2")
                e.Row.Cells(cellIndex).HorizontalAlign = HorizontalAlign.Left
            End If
            If e.Row.RowType = DataControlRowType.DataRow Then
                ' Set the row number in the first cell
                e.Row.Cells(0).Text = (e.Row.RowIndex + 1).ToString()
            End If
        Catch ex As Exception

        End Try

    End Sub
    Protected Sub dd_mode_of_procurement_SelectedIndexChanged(sender As Object, e As EventArgs)
        loadData()
    End Sub
    Protected Sub btnSearch_Click(sender As Object, e As EventArgs)
        If txtFROM.text <> "" And txtTO.text <> "" Then
            pData = objDerived.GetDataTable("EXEC [AMS].[sp_Monitoring_Search] '" & dd_mode_of_procurement.selecteditem.value & "','" & txtFrom.text & "','" & txtTo.text & "'", CommandType.Text)
            'If pData.Rows.Count < 5 Then
            '    pData.Merge(createdatatableMonitoring(5 - pData.Rows.Count))
            'End If
            gvMonitoring.DataSource = pData
            gvMonitoring.DataBind()
            BindGridView()
        Else

        End If

    End Sub
End Class
