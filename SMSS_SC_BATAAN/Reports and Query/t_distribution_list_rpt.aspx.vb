Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections.Hashtable
Imports System.Collections.DictionaryEntry
Imports System.Windows.Forms.Control
Partial Class Reports_and_Query_t_distribution_list_rpt
    Inherits System.Web.UI.Page
    Dim obj As New AccessRule
    Private objDerived As New DerivedDal
    Private Property dtDL() As DataTable
        Get
            Return CType(Session("dtDL"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("dtDL") = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then


            dtDL = objDerived.GetDataTable("SELECT DISTINCT A.prhdr_id as prhdr_id, A.PR_Date, A.pr_no, B.RC_Name, B.Function_Desc, A.ABC, A.RC_ID, C.Quarter as quarter" &
                                            " FROM AMS.PR_Hdr AS A INNER JOIN DBO.View_RespCenter_withFunctions AS B ON A.RC_ID = B.RC_ID AND A.Function_ID = B.Function_ID FULL JOIN AMS.tb_GsoPR_Hdr AS C ON A.prhdr_id = C.prhdr_id " &
                                            " WHERE A.IsApproved = 1 and isConsolidated = 1 ORDER BY A.PR_Date DESC, A.pr_no DESC", CommandType.Text)

            distributionList.DataSource = dtDL
            distributionList.DataBind()



        End If




    End Sub
    Protected Sub distributionList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles distributionList.SelectedIndexChanged
        Session("Page") = "DL"

        Session("prhdr_id") = distributionList.SelectedDataKey("prhdr_id")
        Session("Quarter") = distributionList.SelectedDataKey("quarter")
        Session("Pr_no") = distributionList.SelectedDataKey("pr_no")
        Dim url As String = "/MainReports/DistributionList_Reports.aspx"
        Dim fullURL As String = " var win= window.open('" + url + "', '_blank');"
        ScriptManager.RegisterStartupScript(Me, GetType(String), "OPEN_WINDOW", fullURL, True)
    End Sub



End Class
