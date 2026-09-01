<%@ 
    Page Language="VB" 
    MasterPageFile="~/MasterPage.master"
    AutoEventWireup="false" 
    CodeFile="rpt_BidEval_PostQua_v2.aspx.vb" 
    Inherits="bidding_rpt_BidEval_PostQua_v2"
    Title="Post Qualification"
    StylesheetTheme="SkinFile"
%>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <table style="width: 1010px">
        <tr>
            <td style="width: 1010px">
                <table style="width: 1000px">
                    <tr>
                        <td class="text5" style="width: 1000px">
                            <asp:LinkButton ID="LinkButton1" runat="server" CssClass="text">Back to previous page...</asp:LinkButton>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 1000px"></td>
                    </tr>
                    <tr>
                        <td style="width: 1000px">
                            <CR:CrystalReportViewer ID="CrystalReportViewer5" runat="server" AutoDataBind="true" BestFitPage="false" HasToggleGroupTreeButton="false" Height="750px" Style="background-color: white; text-align: left" Width="980px" BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" ToolPanelView="None" />

                            <CR:CrystalReportSource ID="CrystalReportSource1" runat="server" CacheDuration="1">
                                <Report FileName="rpt_BidEval_PostQua_v2.rpt"></Report>
                            </CR:CrystalReportSource>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>

</asp:Content>

