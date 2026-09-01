Imports Microsoft.VisualBasic
Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web.UI.Page
Imports System.Collections.Generic
Imports Newtonsoft.Json
Imports System.Net.Http

Partial Class Sample


    Inherits System.Web.UI.Page
    Dim apiUrl As String = ConfigurationManager.AppSettings("SampleAPI")

    Private Sub Sample_Load(sender As Object, e As EventArgs) Handles Me.Load

        If Not Me.IsPostBack Then
            Dim dt As System.Data.DataTable = New System.Data.DataTable()
            dt.Columns.AddRange(New System.Data.DataColumn() {
                                 New System.Data.DataColumn("ProductID", GetType(Integer)),
                                New System.Data.DataColumn("ProductName", GetType(String)),
                                New System.Data.DataColumn("image", GetType(String)),
                                New System.Data.DataColumn("Price", GetType(String))})
            dt.Rows.Add(1, "Product 1", "~/Images/22.png", "100Php")
            dt.Rows.Add(2, "Product 2", "~/Images/Ambulance.jpg", "150Php")
            dt.Rows.Add(3, "Product 3", "~/Images/attendance.jpg", "200Php")
            dt.Rows.Add(4, "Product 4", "~/Images/blankImage.jpg", "250Php")
            dt.Rows.Add(5, "Product 5", "~/Images/blankImage.jpg", "350Php")
            dt.Rows.Add(6, "Product 5", "~/Images/blankImage.jpg", "350Php")
            dt.Rows.Add(7, "Product 5", "~/Images/blankImage.jpg", "350Php")
            dt.Rows.Add(8, "Product 5", "~/Images/blankImage.jpg", "350Php")
            dt.Rows.Add(9, "Product 5", "~/Images/blankImage.jpg", "350Php")
            dt.Rows.Add(10, "Product 5", "~/Images/blankImage.jpg", "350Php")
            dt.Rows.Add(11, "Product 5", "~/Images/blankImage.jpg", "350Php")
            dt.Rows.Add(12, "Product 5", "~/Images/blankImage.jpg", "350Php")

            ListView1.DataSource = dt
            ListView1.DataBind()
        End If




        'Dim client As New HttpClient
        'Dim username As String = "admin super"
        'Dim url As String = String.Format(apiUrl + "/api/User/GetUserInfo?UserName={0}", UserName)
        'Dim json As String = client.GetAsync(url).Result.Content.ReadAsStringAsync().Result

        '  Dim str As String = Request.Cookies("UserName").Value

        'If Request.Cookies.Get("PATASPREMIER") IsNot Nothing Then
        '    msgbox("has value")
        'Else

        'End If

        'Dim array As javascriptarray = JavaScriptConvert.DeserializeObject(client.GetAsync(url).Result.Content.ReadAsStringAsync().Result)
        'Dim enum1 As IEnumerable(Of javascriptarray)
        'enum1 = JavaScriptConvert.DeserializeObject(client.GetAsync(url).Result.Content.ReadAsStringAsync().Result)

        ' label1.text = json
        ' client


        'Dim dt As New DataTable()
        '' dt.Columns.AddRange(New DataColumn(1) {New DataColumn("Name"), New DataColumn("Country")})
        '' dt = ViewState("Customers")
        'For i As Integer = 0 To 100 - 1
        '    dt.Rows.Add()
        'Next

        '   ViewState("Customers") = dt
        Me.BindGrid()
    End Sub
    Protected Sub BindGrid()
        grdPropertyInfo.DataSource = DirectCast(ViewState("Customers"), DataTable)
        grdPropertyInfo.DataBind()
    End Sub
    Protected Sub grdPropertyInfo_RowDataBound(sender As Object, e As GridViewRowEventArgs)
        ViewState("Customers") = DirectCast(grdPropertyInfo.DataSource, DataTable)

    End Sub

End Class
