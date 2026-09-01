<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="rpt_ssmi.aspx.vb" Inherits="MainReports_rpt_ssmi" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<script runat="server">


</script>




<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
      <div>
        <table width="1020px">
            <tr>
                <td style="width: 1%"></td>
                <td style="width: 98%" class="PageTitle">SUMMARY OF SUPPLIES AND MATERIALS ISSUED
                </td>
                <td style="width: 1%"></td>
            </tr>
             <tr>
                <td style="width: 1%"></td>
                <td style="width: 98%" align="left">
                     <asp:LinkButton runat="server" ID="lnkback" CssClass="LinkBtnSelect" Text="Back to Previous Page ..." OnClick="lnkback_Click"></asp:LinkButton>
                </td>
                <td style="width: 1%"></td>
            </tr>
            <tr>
                <td style="width: 1%"></td>
                <td style="width: 98%" align="center">
                    <div style="width: 100%; text-align: center; vertical-align: middle">
                        <table width="100%">
                            <tr>
                                <td style="width: 100%" align="center">
                                     <CR:CrystalReportViewer ID="SSMI" runat="server" AutoDataBind="true" HasToggleGroupTreeButton="False" HasCrystalLogo="False" HasSearchButton="False"
                                        EnableParameterPrompt="false" HasDrilldownTabs="False" BestFitPage="False" BackColor="#ffffff" Height="800px" Width="980px" BorderStyle="Solid" BorderColor="#2977dc" BorderWidth="1px" />


                                    <CR:CrystalReportSource ID="CrystalReportSource1" runat="server" CacheDuration="1">
                                        <Report FileName="rpt_summarysuppliesused.rpt"></Report>
                                    </CR:CrystalReportSource>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </td>
                </tr>
            </table>
          </div>
</asp:Content>

