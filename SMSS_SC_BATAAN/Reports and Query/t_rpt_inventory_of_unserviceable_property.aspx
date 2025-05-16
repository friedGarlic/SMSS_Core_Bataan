<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="t_rpt_inventory_of_unserviceable_property.aspx.vb" Inherits="t_rpt_inventory_of_unserviceable_property" title="Inventory Of Unserviceable Property Report" StylesheetTheme="SkinFile" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>  

    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
        <tr>
            <td style="text-align: left">
                <asp:LinkButton ID="LinkButton1" runat="server" CssClass="text">Back to previous page...</asp:LinkButton><cr:crystalreportviewer
                    id="CrystalReportViewer1" runat="server" autodatabind="true" bestfitpage="False"
                     hasgotopagebutton="False" hastogglegrouptreebutton="False"
                    height="600px" style="background-color: white; text-align: left" width="1000px"></cr:crystalreportviewer></td>
        </tr>
        <tr>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
                    <Report FileName="IIRUP.rpt">
                    </Report>
                </CR:CrystalReportSource><CR:CrystalReportSource ID="CrystalReportSource2" runat="server">
                    <Report FileName="IIRUS.rpt">
                    </Report>
                </CR:CrystalReportSource>
            </td>
        </tr>
        <tr>
            <td>
            </td>
        </tr>
    </table>
</asp:Content>

