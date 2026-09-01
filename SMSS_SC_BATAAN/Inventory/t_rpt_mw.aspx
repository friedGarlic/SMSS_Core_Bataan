<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" 
CodeFile="t_rpt_mw.aspx.vb"  StylesheetTheme="SkinFile" Inherits="t_rpt_mw" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
    
<asp:Content ID="Contetnt1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<script language="javascript" type="text/javascript">
</script>
    <table width="800">
        <tr>
            <td style="background-color: transparent; text-align: left;">
                <asp:LinkButton ID="LinkButton1" runat="server" CssClass="text">Back to previous page...</asp:LinkButton>
                <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true"  style="background-color: white" HasToggleGroupTreeButton="False" />
 
            </td>
        </tr>
    </table>
    <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
    </CR:CrystalReportSource>
</asp:Content>