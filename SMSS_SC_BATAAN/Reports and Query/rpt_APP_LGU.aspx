<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="rpt_APP_LGU.aspx.vb" 
Inherits="Reports_and_Query_rpt_APP_LGU" title="APP LGU" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
    <table style="width: 1010px">
        <tr>
            <td style="width: 1010px">
                <table style="width: 1000px">
                    <tr>
                        <td class="text5" style="width: 1000px">
                            <asp:LinkButton ID="LinkButton1" runat="server" CssClass="text">Back to previous page...</asp:LinkButton></td>
                    </tr>
                    <tr>
                        <td style="width: 1000px">
                            <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true"
                                BestFitPage="False" BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px"
                                 HasToggleGroupTreeButton="False" Height="750px" Style="background-color: white;
                                text-align: left" Width="980px" />
                            <CR:CrystalReportSource ID="CrystalReportSource1" runat="server" CacheDuration="1">
                                <Report FileName="rpt_app_DILG_LGU.rpt">
                                </Report>
                            </CR:CrystalReportSource>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>



</asp:Content>

