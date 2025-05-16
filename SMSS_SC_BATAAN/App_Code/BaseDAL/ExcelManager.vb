Imports Microsoft.VisualBasic
Imports Excel = Microsoft.Office.Interop.Excel
Imports System.Runtime.InteropServices
Imports System.IO
Imports OfficeOpenXml
Public Class ExcelManager
    'Public Sub InsertData(ByVal filePath As String, ByVal data As List(Of String()))
    '    Dim excelApp As New Excel.Application()
    '    Dim workbooks As Excel.Workbooks = excelApp.Workbooks
    '    Dim workbook As Excel.Workbook = workbooks.Open(filePath)
    '    Dim worksheet As Excel.Worksheet = workbook.Sheets(1)

    '    ' Find the next empty row in the Excel sheet
    '    Dim nextRow As Integer = worksheet.Cells(worksheet.Rows.Count, 1).End(Excel.XlDirection.xlUp).Row + 1

    '    ' Insert data into Excel
    '    For Each row In data
    '        For i As Integer = 0 To row.Length - 1
    '            worksheet.Cells(nextRow, i + 1) = row(i)
    '        Next
    '        nextRow += 1
    '    Next

    '    ' Save changes and close Excel
    '    workbook.Save()
    '    workbook.Close()
    '    workbooks.Close()
    '    Marshal.ReleaseComObject(worksheet)
    '    Marshal.ReleaseComObject(workbook)
    '    Marshal.ReleaseComObject(workbooks)
    '    excelApp.Quit()
    '    Marshal.ReleaseComObject(excelApp)
    'End Sub

    Public Sub InsertData(ByVal filePath As String, ByVal data As List(Of String()))
        ' Ensure the directory exists
        Dim directoryPath As String = Path.GetDirectoryName(filePath)
        If Not Directory.Exists(directoryPath) Then
            Directory.CreateDirectory(directoryPath)
        End If

        ' Set EPPlus LicenseContext (typically in Application_Start or Global.asax)
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial ' or LicenseContext.Commercial

        ' Load existing workbook or create new if it doesn't exist
        Using package As New ExcelPackage(New FileInfo(filePath))
            ' Get or create worksheet
            Dim worksheet As ExcelWorksheet
            If package.Workbook.Worksheets.Count > 0 Then
                worksheet = package.Workbook.Worksheets(0) ' Use the first worksheet
            Else
                worksheet = package.Workbook.Worksheets.Add("Sheet1")
            End If

            ' Find the next empty row in the Excel sheet
            Dim nextRow As Integer = worksheet.Dimension.End.Row + 1

            ' Write data rows
            For Each row In data
                For i As Integer = 0 To row.Length - 1
                    worksheet.Cells(nextRow, i + 1).Value = row(i)
                Next
                nextRow += 1
            Next

            ' Save changes to the Excel file
            package.Save()
        End Using
    End Sub

End Class
