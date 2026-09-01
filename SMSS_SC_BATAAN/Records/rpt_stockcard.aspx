<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" EnableEventValidation="false"
CodeFile="rpt_stockcard.aspx.vb" Inherits="Records_rpt_stockcard" title="Stock Card Report" StylesheetTheme="SkinFile"%>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>   
    <table style="width: 1000px">
        
                <tr>
                    <%--<td width="10px"></td>--%>
                    <td class="PageTitle" width="1000px">Stock Card Report  </td>
                
                </tr>
        <tr>
            <td align="left" style="width: 1000px">
                <asp:LinkButton ID="LinkButton1" runat="server" CssClass="text">Back to previous page...</asp:LinkButton></td>
        </tr>
        <tr>
            <td align="left" style="width: 1000px">
                <cr:crystalreportviewer id="CrystalReportViewer1" runat="server" autodatabind="true"  hastogglegrouptreebutton="False" style="background-color: white; text-align: left;" Height="800px" Width="980px" BestFitPage="False" BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px"></cr:crystalreportviewer>
    <cr:crystalreportsource id="CrystalReportSource1" runat="server">
        <Report FileName="rpt_StockCard.rpt">
        </Report>
    </cr:crystalreportsource>
            </td>
        </tr>
    </table>
</asp:Content>

