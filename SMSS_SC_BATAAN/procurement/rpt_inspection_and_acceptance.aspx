<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeFile="rpt_inspection_and_acceptance.aspx.vb" StylesheetTheme="SkinFile" Inherits="rpt_inspection_and_acceptance" Title="Inspection And Acceptance Report" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>


<asp:Content ID="Contetnt1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <table style="width: 1000px">
        <tr>
            <td class="text5" style="width: 1000px">
                <asp:LinkButton ID="LinkButton1" runat="server"  CssClass="LinkBtnSelect" >Back to previous page...</asp:LinkButton>

            </td>
        </tr>
        <tr>
            <td class="text5" style="width: 1000px" align="left">         

                <asp:RadioButtonList ID="rbFormatChoice" runat="server" AutoPostBack="true" RepeatDirection="Horizontal" Width="250px">
                    <asp:ListItem Value="1" Selected="True">Short Size</asp:ListItem>
                    <asp:ListItem Value="2">Long Size</asp:ListItem>
                </asp:RadioButtonList>

            </td>
        </tr>
        <tr>
            <td style="width: 1000px" class="text5">
                <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true"
                     Style="background-color: white" HasToggleGroupTreeButton="False" BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" />
                <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
                    <Report FileName="rpt_Inspection_Acceptance.rpt"></Report>
                </CR:CrystalReportSource>
            </td>
        </tr>
    </table>
</asp:Content>
