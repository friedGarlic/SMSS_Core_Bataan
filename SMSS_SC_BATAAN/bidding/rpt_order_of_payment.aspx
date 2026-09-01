<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="rpt_order_of_payment.aspx.vb" Inherits="rpt_order_of_payment" StylesheetTheme="SkinFile"%>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager> 
    <table style="width: 1015px">
        <tr>
            <td class="text5" style="width: 100px">
            </td>
            <td class="text5" style="width: 915px">
                <asp:LinkButton ID="LinkButton1" runat="server" CssClass="text">Back to previous page...</asp:LinkButton></td>
        </tr>
        <tr>
            <td style="width: 100px">
            </td>
            <td class="text5" style="width: 915px">
                <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true"  style="background-color: white" HasToggleGroupTreeButton="False" BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" ToolPanelView="None" />
    <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
        <Report FileName="rpt_order_of_payment.rpt">
        </Report>
    </CR:CrystalReportSource>
            </td>
        </tr>
    </table>
    <br />
    <br />
    <br />
    <br />

    <table border="0" cellpadding="0" cellspacing="0" style="width: 1000px; text-align: left">
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>

