<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="rpt_abstract_of_canvass.aspx.vb" Inherits="bidding_rpt_abstract_of_canvass" title="Abstract of Canvass" StylesheetTheme="SkinFile" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

    
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager> 


<table width="1010">
<tr>
    <td style="width: 80px" width="1015">
    </td>
<td width="1015" style="text-align:left; width: 930px;" align="left">
                <asp:LinkButton ID="LinkButton1" runat="server" CssClass="text">Back to previous page...</asp:LinkButton></td>
</tr>
    <tr>
        <td style="width: 80px" width="1015">
        </td>
        <td width="1015" align="left" style="width: 930px; text-align: left">
                <cr:crystalreportviewer id="CrystalReportViewer1" runat="server" autodatabind="true"  hastogglegrouptreebutton="False" style="background-color: white" Width="350px" BorderColor="Gainsboro" BorderStyle="Solid" BorderWidth="1px" Height="50px"></cr:crystalreportviewer><cr:crystalreportsource id="CrystalReportSource1" runat="server">
                    <REPORT FileName="rpt_abstract_bids_canvass.rpt" />
                </CR:CrystalReportSource>
                <cr:crystalreportsource id="Crystalreportsource2" runat="server">
                    <REPORT FileName="rpt_abstract_of_canvass_PerPR.rpt" />
                </CR:CrystalReportSource>
        </td>
    </tr>
</table>
</asp:Content>


