<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="rpt_Infra_Resolution.aspx.vb" 
Inherits="bidding_Bidding_Infra_rpt_Infra_Resolution" title="BAC RESOLUTION" StylesheetTheme="SkinFile"%>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:ScriptManager id="ScriptManager1" runat="server">
</asp:ScriptManager>
    <table style="width: 1000px">
        <tr>
            <td style="width: 50px">
                &nbsp;</td>
            <td align="left" style="width: 950px">
            </td>
        </tr>
        <tr>
            <td style="width: 50px">
            </td>
            <td align="left" style="width: 950px">
                <asp:LinkButton ID="LinkButton1" runat="server" CssClass="text">Back to previous page...</asp:LinkButton></td>
        </tr>
        <tr>
            <td style="width: 50px">
            </td>
            <td align="left" style="width: 950px">
                <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true"
                     HasToggleGroupTreeButton="False" Style="background-color: white" BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" />
                <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
                    <Report FileName="rpt_Infra_Resolution.rpt">
                    </Report>
                </CR:CrystalReportSource>
            </td>
        </tr>
        <tr>
            <td style="width: 50px">
            </td>
            <td align="left" style="width: 950px">
            </td>
        </tr>
    </table>



</asp:Content>

