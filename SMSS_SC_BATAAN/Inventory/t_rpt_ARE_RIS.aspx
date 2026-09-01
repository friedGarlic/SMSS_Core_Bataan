<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" 
CodeFile="t_rpt_ARE_RIS.aspx.vb" Inherits="Inventory_t_rpt_ARE_RIS" 
title="Requisition and Issue Slip" StylesheetTheme="SkinFile"%>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
    
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager> 


    <table border="0" cellpadding="0" cellspacing="0" style="width: 800px; text-align: left">
        <tr>
            <td>
                <asp:LinkButton ID="LinkButton1" runat="server" CssClass="text">Back to previous page...</asp:LinkButton>
                <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true"  style="background-color: white" HasToggleGroupTreeButton="False" />
            </td>
        </tr>
    </table>
    <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
        <Report FileName="t_rpt_ARE_RIS.rpt">
        </Report>
    </CR:CrystalReportSource>
</asp:Content>

