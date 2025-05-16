<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="t_rpt_notice_of_award.aspx.vb" Inherits="t_rpt_notice_of_award" title="Notice Of Award Report" StylesheetTheme="SkinFile" %>
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
                <asp:LinkButton ID="LinkButton1" runat="server" CssClass="text">Back to previous page...</asp:LinkButton></td>
                    </tr>
                    <tr>
                        <td style="width: 1000px">
                            <cr:crystalreportviewer
                    id="CrystalReportViewer1" runat="server" autodatabind="true"
                     hasgotopagebutton="False" hastogglegrouptreebutton="False"
                    height="50px" style="background-color: white; text-align: left" width="350px" BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px"></cr:crystalreportviewer>
                <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
                    <Report FileName="rpt_NoticeAward.rpt">
                    </Report>
                </CR:CrystalReportSource>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>

