Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections.Hashtable
Imports System.Collections.DictionaryEntry
Imports System.Windows.Forms.Control
Imports System.Data.OleDb
Imports Excel = Microsoft.Office.Interop.Excel

'Imports Spire.Xls
Imports System.Object
Imports System.MarshalByRefObject
Imports System.ComponentModel.Component
Imports System.Windows.Forms.CommonDialog
Imports System.Windows.Forms.FileDialog
Imports System.Windows.Forms.OpenFileDialog
Imports System.Windows.Forms





Partial Class Reports_and_Query_t_RFID
    Inherits System.Web.UI.Page
    Private objDerived_rpt As New connectionreport
    Dim obj As New AccessRule
    Private objDerived As New DerivedDal

   



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            obj.GetAccessRight(Me.Session("@UserName"), Page)
            If obj.HasAccess = False Then
                Me.Page.Response.Redirect("~/UnauthorizedAccess.aspx")
            End If

            ddYear.DataSource = objDerived.GetDataTable("SELECT [year] FROM [AMS].[APP] WHERE [status] <> 3 ORDER BY [year] DESC", CommandType.Text)
            ddYear.DataTextField = "year"
            ddYear.DataValueField = "year"
            ddYear.DataBind()
            ddYear.Items.Insert(0, "Select")

        End If

    End Sub

    Protected Sub btnConvert_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            '===================== ERROR IN FileDialog =====================
            'Dim wbSource As Workbook
            'Dim vrtSelectedItem As Object

            ''Allows you to pick the CSV file from wherever it's been saved.
            'With Application.FileDialog(msoFileDialogOpen)
            '    .InitialFileName = "C:\Users\YourUsername\Documents" & "\"
            '    .AllowMultiSelect = False
            '    .Show()
            '    For Each vrtSelectedItem In .SelectedItems
            '        wbSource = Workbooks.Open(vrtSelectedItem)
            '    Next
            'End With

            ''Saves the file as an .xlsx file.
            'wbSource.SaveAs(FileName:="Random Name.xlsx", FileFormat:=51)


            '===================== ERROR : FILE EXTENSION WAS ONLY CHANGED NOT THE FILE IT SELF =====================
            'Dim x = IO.File.ReadAllText("E:\Alvin Files\FILES\RFID\SCANNED\tagbuffer.csv")
            'x = x.Replace(",", Chr(9))
            'IO.File.WriteAllText("E:\Alvin Files\FILES\RFID\SCANNED\tagbuffer2.xls", x)


            '===================== ERROR : SUCCESSFULLY CONVERTED TO XLS FILE BUT ALL COLUMNS ARE MERGE =====================
            'Dim xlApp As Object
            'Dim newfilename As String

            'xlApp = CreateObject("excel.application")

            'xlApp.Visible = False
            'xlApp.DisplayAlerts = False

            'newfilename = "E:\Alvin Files\FILES\RFID\SCANNED\SCANNED RFID.xls"
            'xlApp.Workbooks.Open("E:\Alvin Files\FILES\RFID\SCANNED\tagbuffer.csv", Format:=4)
            'xlApp.ActiveWorkbook.SaveAs(newfilename)

            'xlApp.ActiveWorkbook.Close(0)
            'xlApp.Quit()
            'xlApp = Nothing

            '===================== ERROR : SYLK FORMAT =====================
            'Dim newFileName As String = "NewExcelFile.xls"
            'Dim oExcelFile As Object

            '' Open Excel application object
            'Try
            '    oExcelFile = GetObject(, "Excel.Application")
            'Catch
            '    oExcelFile = CreateObject("Excel.Application")
            'End Try

            'oExcelFile.Visible = False
            'oExcelFile.Workbooks.Open("E:\Alvin Files\FILES\RFID\SCANNED" + "\" + "tagbuffer2.xls")

            '' Turn off message box so that we do not get any messages
            'oExcelFile.DisplayAlerts = False


            ''Save the file as XLS file
            ''oExcelFile.ActiveWorkbook.SaveAs(FileName:="E:\Alvin Files\FILES\RFID\SCANNED" + "\" + newFileName, FileFormat:=Excel.XlFileFormat.xlExcel5, CreateBackup:=False)
            'oExcelFile.ActiveWorkbook.SaveAs(FileName:="E:\Alvin Files\FILES\RFID\SCANNED" + "\" + newFileName, CreateBackup:=True)

            '' Close the workbook
            'oExcelFile.ActiveWorkbook.Close(SaveChanges:=False)

            '' Turn the messages back on
            'oExcelFile.DisplayAlerts = True

            '' Quit from Excel
            'oExcelFile.Quit()

            '' Kill the variable
            'oExcelFile = Nothing


        Catch ex As Exception
        End Try
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If ddYear.SelectedItem.Text = "Select" Then
            MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Select Calendar Year.")

        Else
            Try
                '========== SAVE EXCEL FILE TO DATABASE [AMS].[tb_RFID] ========== 
                'Dim ExcelConnection As New System.Data.OleDb.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=E:\Alvin Files\FILES\RFID\SCANNED\tagbuffer2.xls;Extended Properties=""Excel 8.0 Xml;HDR=Yes;FMT=Delimited""")
                Dim ExcelConnection As New System.Data.OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\Alvin Files\FILES\RFID\SCANNED\tagbuffer.xls;Extended Properties=""Excel 12.0 Xml;HDR=Yes;FMT=Delimited""")
                'Dim ExcelConnection As New System.Data.OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\Alvin Files\FILES\RFID\SCANNED\tagbuffer.csv;Extended Properties=""text; HDR=Yes; FMT=Delimited""")
                'Dim ExcelConnection As New System.Data.OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\Alvin Files\FILES\RFID\SCANNED\tagbuffer.csv;Extended Properties=""Excel 12.0 Xml;HDR=Yes; FMT=Delimited""")
                ExcelConnection.Open()

                Dim expr As String = "SELECT IDs,EPC,Userdata,ReadTime FROM [tagbuffer$]"

                Dim objCmdSelect As OleDbCommand = New OleDbCommand(expr, ExcelConnection)
                Dim objDR As OleDbDataReader

                Dim SQLconn As New SqlConnection()
                Dim ConnString As String = "Data Source=DEV2K16\BATAAN_2K16;Initial Catalog=SMSS_Premium; User Id=sa; Password=P@ssw0rd;"
                SQLconn.ConnectionString = ConnString
                SQLconn.Open()

                Using bulkCopy As SqlBulkCopy = New SqlBulkCopy(SQLconn)
                    bulkCopy.DestinationTableName = "[AMS].[tb_RFID]"

                    Try
                        objDR = objCmdSelect.ExecuteReader
                        bulkCopy.WriteToServer(objDR)
                        objDR.Close()
                        SQLconn.Close()

                    Catch ex As Exception
                        MsgBox(ex.ToString)
                    End Try
                End Using

                '========== SAVE PROPERTY NUMBER HEX TO ASCII ========== 
                objDerived.GetRecords("UPDATE [AMS].[tb_RFID] SET [Year] = '" & ddYear.SelectedItem.Value & "' ", CommandType.Text)

                '========== SAVE PROPERTY NUMBER HEX TO ASCII ========== 
                objDerived.GetRecords("EXEC [AMS].[sp_SavePropNo_HexToASCII]", CommandType.Text)


                MsgeBox.CreateMessageAlertInUpdatePanel(Me.UpdatePanel1, "Transaction has been successfully saved.")
                '========== PREVIEW RFID REPORT ========== 
                'Me.CrystalReportViewer1.ReportSource = Me.CrystalReportSource1
                'Me.CrystalReportSource1.ReportDocument.SetDatabaseLogon(objDerived.username, objDerived.Password)
                'Me.CrystalReportSource1.ReportDocument.SetParameterValue("@RC_ID", Session("RC_ID"))
                'Me.CrystalReportSource1.ReportDocument.SetParameterValue("@Status", Session("Status"))
                'Me.CrystalReportSource1.ReportDocument.SetParameterValue("@Year", Session("Year"))
                'Me.CrystalReportSource1.ReportDocument.SetParameterValue("@Month", Session("Month"))
                'Me.CrystalReportSource1.ReportDocument.SetParameterValue("@PreparedBy_ID", Session("PreparedBy"))
            Catch ex As Exception
            End Try
        End If

    End Sub
End Class
