'Imports System.Drawing
Imports System.IO
'Imports BarcodeReport
Imports System.Configuration
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine


Partial Class Barcode_PopUp
    Inherits System.Web.UI.Page
    Private objDerived As New BaseClasses.AccountClassAcounts

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim crystalReport As New ReportDocument
        crystalReport.Load(Server.MapPath("~/procurement/rptBArcode_forprint.rpt"))
        Dim dsbarcode As DataSet1 = GetData("select Barcode_Image from Property_Barcode where PropertyNo like '" & Session("PropertyNo") & "'")
        crystalReport.SetDataSource(dsbarcode)
        Barcode.ReportSource = crystalReport


    End Sub
    Private Function GetData(ByVal query As String) As DataSet1
        Dim conString As String = ConfigurationManager.ConnectionStrings("constr").ConnectionString
        Dim cmd As New SqlCommand(query)
        Using con As New SqlConnection(conString)
            Using sda As New SqlDataAdapter()
                cmd.Connection = con

                sda.SelectCommand = cmd
                Using dsbarcode As New DataSet1()
                    sda.Fill(dsbarcode, "Barcode_Table")
                    Return dsbarcode
                End Using
            End Using
        End Using
    End Function


End Class
