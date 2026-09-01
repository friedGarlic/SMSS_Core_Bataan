<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" 
CodeFile="rpt_PhysicalCount_Inventories.aspx.vb" Inherits="Reports_and_Query_rpt_PhysicalCount_Inventories" 
title="Physical Count of Inventory" StylesheetTheme="SkinFile"%>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager> 
    <table style="width: 1000px">
        <tr>
            <td align="left" style="width: 1000px; height: 18px;">
                <asp:LinkButton ID="LinkButton1" runat="server" CssClass="text">Back to previous page...</asp:LinkButton></td>
        </tr>
        <tr>
            <td align="left" style="width: 1000px">
                <CR:CrystalReportViewer ID="rpt_PhysicalCount_Inventories" runat="server" AutoDataBind="true"
                     HasToggleGroupTreeButton="False" Style="background-color: white" BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" BestFitPage="False" Height="700px" Width="1000px" />
                <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
                    <Report FileName="rpt_PhysicalCount_Inventories.rpt">
                    </Report>
                </CR:CrystalReportSource><CR:CrystalReportSource ID="CrystalReportSource2" runat="server">
                    <Report FileName="rpt_Consolidated_PhysicalCount_Supplies.rpt">
                    </Report>
                </CR:CrystalReportSource>
            </td>
        </tr>
    </table>

</asp:Content>

