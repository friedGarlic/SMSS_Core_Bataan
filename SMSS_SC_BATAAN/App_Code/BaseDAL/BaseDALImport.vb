Imports Microsoft.VisualBasic

Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections.Generic
Imports System
Imports System.Web.UI.WebControls
Imports System.Configuration

Namespace BaseDLL

    Public Class BaseDALImport

        Public cn As New SqlConnection
        Public cmd As New SqlCommand
        Public da As New SqlDataAdapter
        Public rd As SqlDataReader
        Public rtrnValue As Long


        Public conStr As String = ConfigurationManager.ConnectionStrings("FMSConnectionString").ToString
        Public pusername, ppassword As String

        Public Sub UserNameSearch()
            Dim str As String
            str = conStr
            Dim i As Integer = str.IndexOf("User ID=")
            Dim j As Integer = i + 1 + 8 'start of User ID + the length of the string
            Dim k As Integer = j
            Dim username As String = ""

            'User ID=test;Password=p@ssw0rd
            For x As Integer = k To str.IndexOf(";Password") '49 to 53
                username = username & GetChar(conStr, x)
            Next
            pusername = username
        End Sub

        Public Sub PasswordSearch()
            Dim str As String
            str = conStr
            Dim i As Integer = str.IndexOf("Password=")
            Dim j As Integer = i + 1 + 9 'start of Password + the length of the string
            Dim k As Integer = j
            Dim password As String = ""

            'User ID=test;Password=p@ssw0rd
            For x As Integer = k To str.Length
                password = password & GetChar(conStr, x)
            Next
            ppassword = password
        End Sub

        Public Property username() As String
            Get
                Call UserNameSearch()
                Return pusername

            End Get
            Set(ByVal value As String)

            End Set
        End Property
        Private ppass As String
        Public Property Password() As String
            Get
                Call PasswordSearch()
                Return ppassword
            End Get
            Set(ByVal value As String)

            End Set
        End Property

        Public Overridable Function GetDataTable(ByVal strCmd As String, ByVal cmdType As CommandType, Optional ByVal param() As SqlParameter = Nothing) As DataTable
            Dim dt As New DataTable
            cn = New SqlConnection(conStr)
            Try
                If Not IsNothing(param) Then
                    For Each p As SqlParameter In param
                        If IsNothing(p) Then
                            Continue For
                        Else
                            cmd.Parameters.Add(p)
                        End If
                    Next
                End If

                cmd.CommandText = strCmd
                cmd.CommandType = cmdType
                cmd.Connection = cn
                cmd.CommandTimeout = 0
                da.SelectCommand = cmd
                cn.Open()
                da.Fill(dt)

                Return dt

            Catch ex As Exception
                Throw New Exception(ex.Message)
                'Throw New Exception("There was an error retrieving inmate record")
            Finally
                da.Dispose()
                If cn.State = Data.ConnectionState.Open Then
                    cn.Close()
                End If
            End Try

        End Function
        Public Overridable Function Execute(ByVal rtnPrm As String, ByVal strCmd As String, ByVal cmdType As CommandType, Optional ByVal param() As SqlParameter = Nothing) As String

            cn = New SqlConnection(conStr)
            Try
                If Not IsNothing(param) Then
                    If Not IsNothing(param) Then
                        For Each p As SqlParameter In param
                            cmd.Parameters.Add(p)
                        Next
                    End If
                End If

                cmd.CommandText = strCmd
                cmd.Connection = cn
                cmd.CommandType = cmdType
                cmd.CommandTimeout = 0
                cn.Open()
                cmd.ExecuteScalar()
                rtrnValue = cmd.Parameters(rtnPrm).Value

                Return rtrnValue

            Catch ex As Exception
                Throw New Exception(ex.Message)
            Finally
                If cn.State = Data.ConnectionState.Open Then
                    cn.Close()
                    cmd.Parameters.Clear()
                End If
            End Try
        End Function

        Public Overridable Function Execute(ByVal strCmd As String, ByVal cmdType As CommandType, Optional ByVal param() As SqlParameter = Nothing) As Long
            cn = New SqlConnection(conStr)
            Try
                If Not IsNothing(param) Then
                    If Not IsNothing(param) Then
                        For Each p As SqlParameter In param
                            cmd.Parameters.Add(p)
                        Next
                    End If
                End If

                cmd.CommandText = strCmd
                cmd.Connection = cn
                cmd.CommandType = cmdType
                cmd.CommandTimeout = 0
                cn.Open()
                cmd.ExecuteScalar()
                'rtrnValue = cmd.Parameters(rtnprm).Value

                Return rtrnValue

            Catch ex As Exception
                Throw New Exception(ex.Message)
            Finally
                If cn.State = Data.ConnectionState.Open Then
                    cn.Close()
                    cmd.Parameters.Clear()
                End If
            End Try
        End Function


        Public Overridable Function GetValue(ByVal strCmd As String, ByVal cmdType As CommandType) As String
            Dim rtnVal As String
            cn = New SqlConnection(conStr)
            Try
                cmd.CommandText = strCmd
                cmd.Connection = cn
                cmd.CommandType = cmdType
                cmd.CommandTimeout = 0
                cn.Open()
                If IsDBNull(cmd.ExecuteScalar) Then
                    rtnVal = ""
                Else
                    rtnVal = cmd.ExecuteScalar()
                End If
                Return rtnVal
            Catch ex As Exception
                Throw New Exception(ex.Message.Trim())
            Finally
                If cn.State = Data.ConnectionState.Open Then
                    cn.Close()
                End If
            End Try
        End Function

        Public Overridable Sub GetRecordsByID(ByVal strCmd As String, ByVal cmdType As CommandType, Optional ByVal param() As SqlParameter = Nothing)
            cn = New SqlConnection(conStr)
            Try
                cmd.CommandText = strCmd
                cmd.Connection = cn
                cmd.CommandType = cmdType
                cmd.CommandTimeout = 0
                If Not IsNothing(param) Then
                    If Not IsNothing(param) Then
                        For Each p As SqlParameter In param
                            cmd.Parameters.Add(p)
                        Next
                    End If
                End If


            Catch ex As Exception
                Throw New Exception(ex.Message)
            Finally
                If cn.State = Data.ConnectionState.Open Then
                    cn.Close()
                    cmd.Parameters.Clear()
                End If
            End Try

        End Sub

        Public Overridable Function GetRecords(ByVal strCmd As String, ByVal cmdType As CommandType, Optional ByVal param() As SqlParameter = Nothing) As DataSet
            Dim ds As New DataSet

            cn = New SqlConnection(conStr)
            Try
                If Not IsNothing(param) Then
                    For Each p As SqlParameter In param
                        cmd.Parameters.Add(p)
                    Next
                End If

                cmd.CommandText = strCmd
                cmd.CommandType = cmdType
                cmd.Connection = cn
                cmd.CommandTimeout = 0
                da.SelectCommand = cmd
                cn.Open()
                da.Fill(ds)

                Return ds

            Catch ex As Exception
                Throw New Exception(ex.Message)
            Finally
                If cn.State = Data.ConnectionState.Open Then
                    cn.Close()
                    cmd.Parameters.Clear()
                End If
            End Try

        End Function

        Public Overridable Function SaveData(ByVal strCmd As String, ByVal cmdType As CommandType, Optional ByVal param() As SqlParameter = Nothing) As DataSet
            Dim ds As New DataSet

            cn = New SqlConnection(conStr)
            Try
                If Not IsNothing(param) Then
                    For Each p As SqlParameter In param
                        cmd.Parameters.Add(p)
                    Next
                End If

                cmd.CommandText = strCmd
                cmd.CommandType = cmdType
                cmd.Connection = cn
                cmd.CommandTimeout = 0
                da.SelectCommand = cmd
                cn.Open()
                da.Fill(ds)

                Return ds

            Catch ex As Exception
                Throw New Exception(ex.Message)
            Finally
                If cn.State = Data.ConnectionState.Open Then
                    cn.Close()
                    cmd.Parameters.Clear()
                End If
            End Try

        End Function

        Public Sub loadDrpDwnList(ByVal drp As DropDownList, ByVal valuefield As String, ByVal txtfield As String, ByVal tablename As String, Optional ByVal ex As String = "")
            drp.DataSource = GetRecords("select * from " & tablename, CommandType.Text)
            drp.DataTextField = txtfield
            drp.DataValueField = valuefield
            drp.DataBind()
        End Sub




        Public Function Search(ByVal data As DataTable, ByVal searchby As String, ByVal SearchString As Object) As DataView
            Dim ds As New DataSet
            Dim dt As DataTable
            dt = data
            Dim myview As DataView
            myview = dt.DefaultView
            If TypeOf SearchString Is Date Then


                If SearchString = CType("01 /01/1901", Date) Then
                    myview = dt.DefaultView
                Else
                    myview.RowFilter = " " & searchby & "=#" & SearchString & "#"
                End If

            Else
                myview.RowFilter = " " & searchby & " Like '" & SearchString.ToString & "%'  "
            End If

            Return myview
        End Function
        Public Function Search2(ByVal data As DataTable, ByVal searchby As String, ByVal SearchString As Object) As DataView
            Dim ds As New DataSet
            Dim dt As DataTable
            dt = data
            Dim myview As DataView
            myview = dt.DefaultView
            If TypeOf SearchString Is Date Then


                If SearchString = CType("01 /01/1901", Date) Then
                    myview = dt.DefaultView
                Else
                    myview.RowFilter = " " & searchby & "=#" & SearchString & "#"
                End If

            Else
                myview.RowFilter = " " & searchby & " Like '%" & SearchString.ToString & "%'  "
            End If

            Return myview
        End Function

    End Class


End Namespace

