<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="t_rpt_InventoryCustodianSlip.aspx.vb" Inherits="Inventory_t_rpt_InventoryCustodianSlip"
    Title="Inventory Custodian Slip" StylesheetTheme="SkinFile" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>


    <table cellspacing="1" style="width: 1010px">
        <tr>
            <td width="10"></td>
            <td class="text5" width="1000">
                <asp:LinkButton ID="LinkButton1" runat="server" CssClass="text">Back to previous page...</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td width="10"></td>
            <td class="text5" width="1000">
                <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true"  Style="background-color: white" HasToggleGroupTreeButton="False" />
                <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
                    <Report FileName="t_rpt_InventoryCustodianSlip.rpt">
                    </Report>
                </CR:CrystalReportSource>

            </td>
        </tr>
    </table>


</asp:Content>

