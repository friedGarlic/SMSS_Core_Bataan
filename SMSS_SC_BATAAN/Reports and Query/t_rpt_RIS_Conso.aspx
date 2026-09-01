<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="t_rpt_RIS_Conso.aspx.vb" Inherits="Reports_and_Query_t_rpt_RIS_Conso" Title="RIS Consolidated Report" StylesheetTheme="SkinFile" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <div>
        <table width="1020px">
            <tr>
                <td style="width:1%"></td>
                <td style="width:98%" class="PageTitle">
                    <asp:Label runat="server" ID="lblTitle" Text="REQUISITION AND ISSUANCE CONSOLIDATED REPORT">
                    </asp:Label>
                </td>
                <td style="width:1%"></td>
            </tr>

            <tr>
                <td style="width:1%"></td>
                <td style="width:98%;height:10px"></td>
                <td style="width:1%"></td>
            </tr>

            <tr>
                <td style="width:1%"></td>
                <td style="width:98%" align="center">
                    <div style="max-width:850px; max-height:1300px; background-color:#808080; text-align:center; vertical-align:middle; overflow:scroll">
                        <table width="100%">
                            <tr>
                                <td style="width:100%;height:5px"></td>
                            </tr>

                            <tr>
                                <td style="width:100%" align="center">
                                    <CR:CrystalReportViewer ID="RISConsoReport" runat="server" AutoDataBind="true" HasToggleGroupTreeButton="False" HasCrystalLogo="False" BackColor="#ffffff" BestFitPage="true" />
                                    <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
                                    </CR:CrystalReportSource>
                                </td>
                            </tr>

                            <tr>
                                <td style="width:100%;height:5px"></td>
                            </tr>
                        </table>
                    </div>
                </td>
                <td style="width:1%"></td>
            </tr>
        </table>
    </div>
</asp:Content>