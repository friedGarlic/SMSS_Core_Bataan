<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="rpt_canvass.aspx.vb" Inherits="bidding_rpt_canvass" title="Canvass Report" StylesheetTheme="SkinFile" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager> 

    <table width="1000">
        <tr>
            <td style="background-color: transparent; text-align: left">
                <asp:LinkButton ID="LinkButton1" runat="server" CssClass="text">Back to previous page...</asp:LinkButton>&nbsp;
            </td>
        </tr>
        <tr>
            <td style="background-color: transparent; text-align: center">
                <cr:crystalreportviewer id="CrystalReportViewer1" runat="server" autodatabind="true"  hastogglegrouptreebutton="False" style="background-color: white; text-align: left;"></cr:crystalreportviewer>
            </td>
        </tr>
    </table>
    <cr:crystalreportsource id="CrystalReportSource1" runat="server"><REPORT FileName="rpt_cavass.rpt" /></cr:crystalreportsource>
</asp:Content>

