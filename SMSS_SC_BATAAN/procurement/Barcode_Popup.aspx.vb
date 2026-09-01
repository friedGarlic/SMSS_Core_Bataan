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
        'If Not IsPostBack Then

        'End If
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
    'Me.Barcode.ReportSource = Me.CrystalReportSource1
    'Me.CrystalReportSource1.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
    'Me.CrystalReportSource1.ReportDocument.SetParameterValue(0, Session("PropertyNo"))

    ''Try
    '' here i have define a simple datatable inwhich image will recide 
    'Dim dt As New DataTable()
    '' object of data row 
    'Dim drow As DataRow
    '' add the column in table to store the image of Byte array type 
    'dt.Columns.Add("Image", System.Type.[GetType]("System.Byte[]"))
    'drow = dt.NewRow
    '' define the filestream object to read the image 
    'Dim fs As FileStream
    '' define te binary reader to read the bytes of image 
    'Dim br As BinaryReader
    '' check the existance of image 
    'Dim dinNo As String = "221-14-10-000041"
    'Dim strPath As String = AppDomain.CurrentDomain.BaseDirectory & "BarcodeImages\" + dinNo + ".png"
    'If File.Exists(AppDomain.CurrentDomain.BaseDirectory & "BarcodeImages\" + dinNo + ".png") Then
    '    ' open image in file stream 
    '    fs = New FileStream(AppDomain.CurrentDomain.BaseDirectory & "BarcodeImages\" + dinNo + ".png", FileMode.Open)
    'Else
    '    ' if phot does not exist show the nophoto.jpg file 
    '    fs = New FileStream(AppDomain.CurrentDomain.BaseDirectory + "NoPhoto.jpg", FileMode.Open)
    'End If
    '' initialise the binary reader from file streamobject 
    'br = New BinaryReader(fs)
    '' define the byte array of filelength 
    'Dim imgbyte As Byte() = New Byte(fs.Length) {}
    '' read the bytes from the binary reader 
    'imgbyte = br.ReadBytes(Convert.ToInt32((fs.Length)))
    'drow(0) = imgbyte
    '' add the image in bytearray 
    'dt.Rows.Add(drow)
    '' add row into the datatable 
    'br.Close()
    '' close the binary reader 
    'fs.Close()
    '' close the file stream 
    'Dim rptobj As New rptBarcode_print
    '' object of crystal report 
    'rptobj.SetDataSource(dt)
    '' set the datasource of crystalreport object 
    ''set the report source 
    'Barcode.ReportSource = rptobj
    'Catch ex As Exception
    ' error handling 
    'Interaction.MsgBox("Missing 10157.jpg or nophoto.jpg in application folder")
    ' End Try


End Class
