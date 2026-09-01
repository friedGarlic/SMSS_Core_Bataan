<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="rpt_ReturnedPPESummay.aspx.vb" 
Inherits="Reports_and_Query_rpt_ReturnedPPESummay" title="SUMMARY OF RETURNED PPE" EnableEventValidation="false"%>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
    
    
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
    <table style="width: 1010px">
        <tr>
            <td class="text5" style="width: 20px">
            </td>
            <td class="text5" style="width: 990px">
                <asp:LinkButton ID="LinkButton1" runat="server" CssClass="text">Back to previous page...</asp:LinkButton></td>
        </tr>
        <tr>
            <td class="text5" style="width: 20px">
            </td>
            <td class="text5" style="width: 990px">
                <cr:crystalreportviewer id="CrystalReportViewer1" runat="server" autodatabind="true" hastogglegrouptreebutton="False" style="background-color: white; text-align: left;" Height="50px" Width="350px" BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px"></cr:crystalreportviewer>
    <cr:crystalreportsource id="CrystalReportSource1" runat="server">
        <Report FileName="rpt_ReturnedSummary.rpt">
        </Report>
    </cr:crystalreportsource>
            </td>
        </tr>
    </table>
</asp:Content>

