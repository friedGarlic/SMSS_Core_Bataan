<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" 
CodeFile="rpt_ppmp_contingency.aspx.vb" Inherits="planning_rpt_ppmp_contingency" 
title="PPMP Contingency" StylesheetTheme="SkinFile"%>

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
                        <td class="text5" style="width: 1000px">
                            <asp:LinkButton ID="LinkButton1" runat="server" CssClass="text">Back to previous page...</asp:LinkButton></td>
                    </tr>
                    <tr>
                        <td class="text5" style="width: 1000px">
                            <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true"
                                BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px"
                                HasToggleGroupTreeButton="False"  Height="50px" Style="background-color: white;
                                text-align: left" Width="350px" />
                            <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
                            </CR:CrystalReportSource>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>


</asp:Content>

