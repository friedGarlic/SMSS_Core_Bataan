<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" 
CodeFile="t_rpt_requisition_and_issuance.aspx.vb" Inherits="t_rpt_requisition_and_issuance" 
title="Requisition And Issuance Report" StylesheetTheme="SkinFile"%>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager> 
    <table style="width: 1000px">
        <tr>
            <td class="text5" style="width: 10px">
            </td>
            <td class="text5" style="width: 990px">
                <asp:LinkButton ID="LinkButton1" runat="server" CssClass="text">Back to previous page...</asp:LinkButton></td>
        </tr>
        <tr>
            <td class="text5" style="width: 10px">
            </td>
            <td class="text5" style="width: 990px">
                <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true"  style="background-color: white" HasToggleGroupTreeButton="False" BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" />
    <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
        <Report FileName="t_rpt_requisition_and_issuance.rpt">
        </Report>
    </CR:CrystalReportSource>
            </td>
        </tr>
    </table>
</asp:Content>

