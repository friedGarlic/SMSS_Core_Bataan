<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="rpt_abstract_of_bids_calculated.aspx.vb" Inherits="Reports_and_Query_rpt_abstract_of_bids_calculated" title="Abstract of Bids as Calculated" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager> 
    <table style="width: 1015px">
        <tr>
            <td style="width: 1015px">
                <table style="width: 1000px">
                    <tr>
                        <td align="left" style="width: 1000px">
                <asp:LinkButton ID="LinkButton1" runat="server" CssClass="text5">Back to previous page...</asp:LinkButton></td>
                    </tr>
                    <tr>
                        <td align="left" style="width: 1000px">
                <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" BestFitPage="False" Height="800px" Width="980px"  BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" ToolPanelView="None" />

                <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
                <Report FileName="rpt_abstract_bids_bidding.rpt">
                </Report>
                </CR:CrystalReportSource>

                <CR:CrystalReportSource ID="CrystalReportSource2" runat="server">
                <Report FileName="rpt_abstract_bids_bidding_read.rpt">
                </Report>
                </CR:CrystalReportSource>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>

