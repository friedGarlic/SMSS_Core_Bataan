Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections.Hashtable
Imports System.Collections.DictionaryEntry
Imports System.Windows.Forms.Control
Imports System.Drawing
Partial Class Inventory_t_Drainage
    Inherits System.Web.UI.Page
    Private objDerived As New DerivedDal
    Dim msg As New MsgeBox
    Dim obj As New AccessRule
    Dim idholder As String = ""
    Private Property pMaterial() As DataTable
        Get
            Return CType(Session("pMaterial"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("pMaterial") = value
        End Set
    End Property
#Region "function"
    Public Function createdatatable(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        dt.Columns.Add("Material", GetType(String))
        dt.Columns.Add("Quantity", GetType(Integer))
        For i As Integer = 0 To row
            dr = dt.NewRow
            dr("Material") = DBNull.Value
            dr("Quantity") = DBNull.Value
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function
    Public Function createdatatableledger(ByVal row As Integer) As DataTable
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim myDataColumn As DataColumn
        myDataColumn = New DataColumn()
        'dt.Columns.Add("Property_Dtl_ID", GetType(Long))
        dt.Columns.Add("dDate", GetType(Date))
        dt.Columns.Add("Trans_Type", GetType(String))
        dt.Columns.Add("ref", GetType(String))
        dt.Columns.Add("AccountablePerson", GetType(String))
        dt.Columns.Add("Department", GetType(String))
        dt.Columns.Add("position", GetType(String))
        dt.Columns.Add("acceptedby", GetType(String))
        dt.Columns.Add("inspectedby", GetType(String))
        dt.Columns.Add("DebitQty", GetType(Integer))
        dt.Columns.Add("DebitUnit", GetType(String))
        dt.Columns.Add("DebitCost", GetType(Decimal))
        dt.Columns.Add("CreditQty", GetType(Integer))
        dt.Columns.Add("CreditUnit", GetType(String))
        dt.Columns.Add("CreditCost", GetType(Decimal))
        dt.Columns.Add("BalQty", GetType(Integer))
        dt.Columns.Add("BalanceUnit", GetType(String))
        dt.Columns.Add("BalCost", GetType(Decimal))
        For i As Integer = 0 To row
            dr = dt.NewRow
            'dr("Property_Dtl_ID") = DBNull.Value
            dr("dDate") = DBNull.Value
            dr("Trans_Type") = DBNull.Value
            dr("ref") = DBNull.Value
            dr("AccountablePerson") = DBNull.Value
            dr("Department") = DBNull.Value
            dr("position") = DBNull.Value
            dr("acceptedby") = DBNull.Value
            dr("inspectedby") = DBNull.Value
            dr("DebitQty") = DBNull.Value
            dr("DebitUnit") = DBNull.Value
            dr("DebitCost") = DBNull.Value
            dr("CreditQty") = DBNull.Value
            dr("CreditUnit") = DBNull.Value
            dr("CreditCost") = DBNull.Value
            dr("BalQty") = DBNull.Value
            dr("BalanceUnit") = DBNull.Value
            dr("BalCost") = DBNull.Value
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function
#End Region
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            pMaterial = objDerived.GetDataTable("select * from AMS.Slop_Protection_Material", CommandType.Text)
            If pMaterial.Rows.Count < 5 Then
                pMaterial.Merge(createdatatable(5 - pMaterial.Rows.Count))
            End If
            grdMaterial.DataSource = pMaterial
            grdMaterial.DataBind()
            loadEquipmentLedger()
        End If
    End Sub
    Protected Sub OnDataBound(sender As Object, e As EventArgs)
        'Dim row As New GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal)
        'Dim cell As New TableHeaderCell()
        'cell.Text = "ROADS AND BRIDGES CONSTRUCTION"
        'cell.ColumnSpan = 3
        'row.Controls.Add(cell)

        'cell = New TableHeaderCell()
        'cell.ColumnSpan = 1
        'cell.Text = "DEBIT"
        'row.Controls.Add(cell)


        'cell = New TableHeaderCell()
        'cell.ColumnSpan = 1
        'cell.Text = "CREDIT"
        'row.Controls.Add(cell)


        'cell = New TableHeaderCell()
        'cell.ColumnSpan = 1
        'cell.Text = "BALANCE"
        'row.Controls.Add(cell)

        'row.BackColor = ColorTranslator.FromHtml("WHITE")
        'row.ForeColor = ColorTranslator.FromHtml("BLACK")
        'grdLedger1.HeaderRow.Parent.Controls.AddAt(0, row)


        ''Optimize code using chat gpt

        Dim row As New GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal)
        row.BackColor = Color.White
        row.ForeColor = Color.Black

        Dim cell As TableHeaderCell

        cell = New TableHeaderCell()
        cell.Text = "ROADS AND BRIDGES CONSTRUCTION"
        cell.ColumnSpan = 3
        row.Cells.Add(cell)

        cell = New TableHeaderCell()
        cell.Text = "DEBIT"
        row.Cells.Add(cell)

        cell = New TableHeaderCell()
        cell.Text = "CREDIT"
        row.Cells.Add(cell)

        cell = New TableHeaderCell()
        cell.Text = "BALANCE"
        row.Cells.Add(cell)

        grdLedger1.Controls(0).Controls.AddAt(0, row)
    End Sub
    Protected Sub grdLedger1_RowDataBound(sender As Object, e As GridViewRowEventArgs)

        If e.Row.RowType = DataControlRowType.DataRow Then
            If e.Row.Cells(9).Text = "0" Then
                e.Row.Cells(9).Text = " "
            End If
            If e.Row.Cells(10).Text = "0.00" Then
                e.Row.Cells(10).Text = " "
            End If
            If e.Row.Cells(11).Text = "0" Then
                e.Row.Cells(11).Text = " "
            End If
            If e.Row.Cells(12).Text = "0.00" Then
                e.Row.Cells(12).Text = " "
            End If

        End If
    End Sub
    Public Sub loadEquipmentLedger()
        Dim dtAccount As New DataTable
        Dim itemid As String
        'If 

        'dtAccount = objDerived.GetDataTable("Select * From dbo.View_PropertyLedger where Item_ID = '" & gvsearchproperty.SelectedDataKey("Item_ID") & "' order by dDate", CommandType.Text)
        If idholder = "" Then
            dtAccount = objDerived.GetDataTable("Exec [AMS].[PropertyLedger] null", CommandType.Text)

        Else
            dtAccount = objDerived.GetDataTable("Exec [AMS].[PropertyLedger] '" & idholder & "'", CommandType.Text)

        End If
        ' dtAccount = objDerived.GetDataTable("Exec [AMS].[PropertyLedger] '" & gvsearchproperty.SelectedDataKey("Item_ID") & "'", CommandType.Text)

        If dtAccount.Rows.Count < 10 Then
            dtAccount.Merge(createdatatableledger(9 - dtAccount.Rows.Count))
        End If

        grdLedger1.DataSource = dtAccount
        grdLedger1.DataBind()
    End Sub
End Class
