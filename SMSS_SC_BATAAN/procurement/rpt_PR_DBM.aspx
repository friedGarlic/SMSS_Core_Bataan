<%@ Page Language="VB" MasterPageFile="~/MasterPage.master"  AutoEventWireup="false" CodeFile="rpt_PR_DBM.aspx.vb" 
Inherits="rpt_PR_DBM" EnableEventValidation="false"  title="Purchase Request for DBM Report" StylesheetTheme="SkinFile" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

    
    
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>   


    <table border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td class="text5" style="width: 1000px">
                <asp:LinkButton ID="LinkButton1" runat="server" CssClass="text">Back to previous page...</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td style="width: 800px; text-align: left">
                &nbsp;<CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true"  style="background-color: white" HasToggleGroupTreeButton="False" />
            </td>
        </tr>
    </table>
    <table border="0" cellpadding="0" cellspacing="0" style="width: 800px">
        <tr>
            <td style="width: 800px">
    <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
        <Report FileName="rpt_PR_DBM.rpt">
        </Report>
    </CR:CrystalReportSource>
                </td>
        </tr>
        <tr>
            <td style="width: 800px; text-align: left">
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

