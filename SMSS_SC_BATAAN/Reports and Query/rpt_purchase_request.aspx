<%@ Page Language="VB"
    MasterPageFile="~/MasterPage.master" 
    AutoEventWireup="false"
    CodeFile="rpt_purchase_request.aspx.vb"
    Inherits="rpt_purchase_request"
    Title="Purchase Request Report" 
    StylesheetTheme="SkinFile" %>


<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <table style="width: 1010px">
        <tr>
            <td style="width: 20px"></td>
            <td class="PageTitle" style="width: 990px">PRUCHASE REQUEST REPORT</td>
        </tr>
        <tr>
            <td style="width: 20px"></td>
            <td class="text5" style="width: 990px">
                <asp:LinkButton ID="LinkButton1" runat="server" CssClass="text">Back to previous page...</asp:LinkButton></td>
        </tr>
        <tr>
            <td style="width: 20px"></td>
            <td class="text5" style="width: 990px">
                <asp:RadioButtonList ID="rdPRFormat" runat="server" AutoPostBack="True" CssClass="text"
                    RepeatDirection="Horizontal" Width="400px">
                    <asp:ListItem Selected="True" Value="1">PR Report (Long)</asp:ListItem>
                    <asp:ListItem Value="2">PR Report (Short)</asp:ListItem>
                </asp:RadioButtonList></td>
        </tr>
        <tr>
            <td style="width: 20px"></td>
            <td class="text5" style="width: 990px">
                <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true"  Style="background-color: white" HasToggleGroupTreeButton="False" BorderColor="Gainsboro" BorderStyle="Solid" BorderWidth="1px" />
                <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
                    <Report FileName="rpt_purchase_request.rpt">
                    </Report>
                </CR:CrystalReportSource>
                <CR:CrystalReportSource ID="CrystalReportSource2" runat="server">
                    <Report FileName="rpt_purchase_request_Short.rpt">
                    </Report>
                </CR:CrystalReportSource>
            </td>
        </tr>
    </table>
</asp:Content>

