<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" 
    CodeFile="t_rpt_receiving.aspx.vb" Inherits="Reports_and_Query_t_rpt_receiving" 
    Title="Inspection Report" StylesheetTheme="SkinFile" EnableEventValidation="false" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <asp:ScriptManager ID="ScriptManager1" runat="server" />

    <div>
        <table width="1020px">
            <tr>
                <td class="PageTitle">INSPECTION REPORT</td>
            </tr>
            <tr>
                <td align="left">
                    <asp:LinkButton ID="LinkButton1" runat="server" CssClass="LinkBtnSelect" Text="Back to Previous Page ..." />
                </td>
            </tr>
            <tr>
                <td align="center">
                    <div style="width: 850px; background-color: #808080; text-align: center;">
                        <table width="100%">
                            <tr><td style="height: 5px"></td></tr>
                            <tr>
                                <td align="center">
                                    <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true"
                                        HasToggleGroupTreeButton="False" HasCrystalLogo="False"
                                        BestFitPage="True" BackColor="#ffffff" ToolPanelView="None" />
                                    <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
                                        <Report FileName="rpt_receiving_v2.rpt" />
                                    </CR:CrystalReportSource>
                                </td>
                            </tr>
                            <tr><td style="height: 5px"></td></tr>
                        </table>
                    </div>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
