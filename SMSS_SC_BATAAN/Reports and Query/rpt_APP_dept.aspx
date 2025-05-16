<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" 
CodeFile="rpt_APP_dept.aspx.vb" Inherits="Reports_and_Query_rpt_APP_dept" 
title="Annual Procurement Plan Per Department" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>

<table style="width: 1000px">
        <tr>
            <td align="left" style="width: 1000px">
                <asp:LinkButton ID="LinkButton1" runat="server" CssClass="text">Back to previous page...</asp:LinkButton></td>
        </tr>
    <tr>
        <td class="text5" style="width: 1000px">
            <asp:RadioButtonList ID="rbFormat" runat="server" AutoPostBack="True" RepeatDirection="Horizontal"
                Visible="False" Width="350px">
                <asp:ListItem Selected="True" Value="1">APP Report Format v1</asp:ListItem>
                <asp:ListItem Value="2">APP Report Format v2</asp:ListItem>
            </asp:RadioButtonList></td>
    </tr>
        <tr>
            <td align="left" style="width: 1000px">
    <cr:crystalreportviewer id="CrystalReportViewer1" runat="server" autodatabind="true"  hastogglegrouptreebutton="False" style="background-color: white; text-align: left;" Height="800px" Width="980px" BestFitPage="False" BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" ToolPanelView="None">
    </cr:crystalreportviewer>

    <cr:crystalreportsource id="CrystalReportSource1" runat="server" CacheDuration="1">
        <Report FileName="rpt_app_GPPB.rpt">
        </Report>
    </cr:crystalreportsource>

    <cr:crystalreportsource id="Crystalreportsource2" runat="server" CacheDuration="1">
        <Report FileName="rpt_app_DILG.rpt">
        </Report>
    </CR:CrystalReportSource>

    <cr:crystalreportsource id="Crystalreportsource3" runat="server" CacheDuration="1">
        <Report FileName="rpt_app_GPPB_v2.rpt">
        </Report>
    </CR:CrystalReportSource>
            </td>
        </tr>
    </table>
</asp:Content>

