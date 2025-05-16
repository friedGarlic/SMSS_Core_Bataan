<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" EnableEventValidation="false"
CodeFile="rpt_resulotion_recommending_award.aspx.vb" 
Inherits="bidding_rpt_resulotion_recommending_award" 
title="Resulotion Recommending Award Report" StylesheetTheme="SkinFile" %>


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
                <asp:LinkButton ID="LinkButton1" runat="server" CssClass="text" Visible="False">Back to previous page...</asp:LinkButton></td>
                    </tr>
                    <tr>
                        <td style="width: 1000px">
                <cr:crystalreportviewer id="CrystalReportViewer1" runat="server" autodatabind="true"  hastogglegrouptreebutton="False" style="background-color: white" BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px"></cr:crystalreportviewer>
    <cr:crystalreportsource id="CrystalReportSource1" runat="server">
        <Report FileName="rpt_BACResolution.rpt">
        </Report>
    </cr:crystalreportsource>
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>

