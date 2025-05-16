Imports Microsoft.VisualBasic

Public Class BaseGeneral
    Inherits BaseDAL_SysMngr
#Region "Methods"
    Public Overrides Function Execute(ByVal rtnPrm As String, ByVal strCmd As String, ByVal cmdType As System.Data.CommandType, Optional ByVal param() As System.Data.SqlClient.SqlParameter = Nothing) As Long
        Return MyBase.Execute(rtnPrm, strCmd, cmdType, param)
    End Function

    Public Overrides Function GetValue(ByVal strCmd As String, ByVal cmdType As System.Data.CommandType) As String
        Return MyBase.GetValue(strCmd, cmdType)
    End Function

    Public Overrides Sub GetRecordsByID(ByVal strCmd As String, ByVal cmdType As System.Data.CommandType, Optional ByVal param() As System.Data.SqlClient.SqlParameter = Nothing)
        MyBase.GetRecordsByID(strCmd, cmdType, param)
    End Sub
#End Region
    Public Overrides Sub FillEntity()

    End Sub
End Class
