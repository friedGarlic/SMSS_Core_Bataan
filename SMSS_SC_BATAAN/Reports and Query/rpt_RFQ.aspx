<%@ Page Title="RFQ Report Preview" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="rpt_RFQ.aspx.vb" 
    Inherits="Reports_and_Query_rpt_RFQ" StylesheetTheme="SkinFile"  %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
    



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>  

    <table cellspacing="1" style="width: 1010px">
        <tr>
            <td width="10"></td>
            <td class="PageTitle" width="1000">REQUEST FOR QUOTATION REPORT</td>
        </tr>
        <tr>
            <td width="10"></td>
            <td class="text5" width="1000">
                <asp:LinkButton ID="lnkBack" runat="server" CssClass="text">Back to previous page...</asp:LinkButton></td>
        </tr>
        <tr>
            <td width="10"></td>
            <td class="text5" width="1000">
    <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true"  style="background-color: white" HasToggleGroupTreeButton="False" BorderColor="Gainsboro" BorderStyle="Solid" BorderWidth="1px" />
                <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
                    <Report FileName="rpt_canvass_sheet.rpt">
                    </Report>
                </CR:CrystalReportSource>
                </td>
        </tr>
        </table>


</asp:Content>

