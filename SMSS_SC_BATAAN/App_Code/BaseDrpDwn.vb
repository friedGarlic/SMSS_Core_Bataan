Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.UI

Public Class BaseDrpDwn
    Public Class DropdownLoad
        Dim obj As New BaseGeneral
        Dim p() As SqlParameter
        Dim ds As New DataSet

        Public Sub loadDrpDwnList(ByVal c As WebControls.DropDownList, ByVal strcmd As String, ByVal TextField As String, ByVal ValueField As String, ByVal cmdType As CommandType)
            c.DataSource = obj.GetDataTable(strcmd, cmdType)
            c.DataTextField = TextField
            c.DataValueField = ValueField
            c.DataBind()
            'ds.Reset()
            c.Items.Add("--SELECT--")
            c.Items(c.Items.Count - 1).Value = -1
            c.Items(c.Items.Count - 1).Selected = True
        End Sub

        Public Sub loadListBox(ByVal c As WebControls.ListBox, ByVal strcmd As String, ByVal TextField As String, ByVal ValueField As String, ByVal cmdType As CommandType)
            c.DataSource = obj.GetDataTable(strcmd, cmdType)
            c.DataTextField = TextField
            c.DataValueField = ValueField
            c.DataBind()
            'ds.Reset()
            'c.Items.Add("SELECT")
            'c.Items(c.Items.Count - 1).Selected = True
        End Sub
    End Class
End Class
