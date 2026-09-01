<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" 
CodeFile="rpt_obr_evaluation_canvass.aspx.vb" Inherits="bidding_rpt_obr_evaluation_canvass" 
title="OBR Evaluation - Canvass Report" StylesheetTheme="SkinFile" %>


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
                &nbsp;<br />
                <table style="width: 1000px; ">
                    <tr>
                        <td style="width: 100px">
                            &nbsp;</td>
                        <td align="left" style="width: 900px">
                <cr:crystalreportviewer id="CrystalReportViewer1" runat="server" autodatabind="true"  hastogglegrouptreebutton="False" style="background-color: white; text-align: left; "></cr:crystalreportviewer>
                            <br />
    <cr:crystalreportsource id="CrystalReportSource1" runat="server"><REPORT FileName="rpt_obr_evaluation_canvass.rpt" /></cr:crystalreportsource>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>


</asp:Content>

