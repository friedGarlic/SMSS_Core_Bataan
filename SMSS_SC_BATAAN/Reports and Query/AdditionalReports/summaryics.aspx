<%@ Page Title="Summary of Inventory Custodian Slip" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="summaryics.aspx.vb"
    Inherits="Reports_and_Query_AdditionalReports_summaryics" StylesheetTheme="SkinFile" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <script type="text/javascript"> 
        function stopRKey(evt) {
            var evt = (evt) ? evt : ((event) ? event : null);
            var node = (evt.target) ? evt.target : ((evt.srcElement) ? evt.srcElement : null);
            if ((evt.keyCode == 13) && (node.type == "text")) {
                return false;
            }
        }
        document.onkeypress = stopRKey;
    </script>


    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>


            <div>
                <table width="100%">
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="PageTitle">SUMMARY OF INVENTORY CUSTODIAN SLIP
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <table width="80%">
                                <tr>
                                    <td style="width: 20%" class="column_RightBold">Year : </td>
                                    <td style="width: 80%" class="column_Left">
                                        <asp:DropDownList runat="server" ID="drpYear" CssClass="drpdownCSS" Width="20%"></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 20%" class="column_RightBold">As of Month : </td>
                                    <td style="width: 80%" class="column_Left">
                                        <asp:DropDownList runat="server" ID="drpMonths" CssClass="drpdownCSS" Width="20%">
                                            <asp:ListItem Value="1" Text="January" Selected="True"></asp:ListItem>
                                            <asp:ListItem Value="2" Text="February"></asp:ListItem>
                                            <asp:ListItem Value="3" Text="March"></asp:ListItem>
                                            <asp:ListItem Value="4" Text="April"></asp:ListItem>
                                            <asp:ListItem Value="5" Text="May"></asp:ListItem>
                                            <asp:ListItem Value="6" Text="June"></asp:ListItem>
                                            <asp:ListItem Value="7" Text="July"></asp:ListItem>
                                            <asp:ListItem Value="8" Text="August"></asp:ListItem>
                                            <asp:ListItem Value="9" Text="September"></asp:ListItem>
                                            <asp:ListItem Value="10" Text="October"></asp:ListItem>
                                            <asp:ListItem Value="11" Text="November"></asp:ListItem>
                                            <asp:ListItem Value="12" Text="December"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 20%" class="column_RightBold">Prepared By : </td>
                                    <td style="width: 80%" class="column_Left">
                                        <asp:DropDownList runat="server" ID="drpPreparedby" CssClass="drpdownCSS" Width="50%"></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 20%" class="column_RightBold">Noted By : </td>
                                    <td style="width: 80%" class="column_Left">
                                        <asp:DropDownList runat="server" ID="drpNotedby" CssClass="drpdownCSS" Width="50%"></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 100%; height: 10px" colspan="2" align="center"></td>
                                </tr>
                                <tr>
                                    <td style="width: 20%" class="column_RightBold"></td>
                                    <td style="width: 80%" class="column_Left">
                                        <asp:Button runat="server" ID="btnPreview" CssClass="CSButton" Width="20%" Text="Preview" OnClientClick="StartProgressBar();" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 100%" colspan="2" align="center"></td>
                                </tr>
                            </table>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <div style="width: 100%; text-align: center; vertical-align: middle">
                                <table width="100%">
                                    <tr>
                                        <td style="width: 100%; height: 10px"></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100%" align="center">

                                            <CR:CrystalReportViewer ID="SummaryReports" runat="server" AutoDataBind="true" HasToggleGroupTreeButton="False" HasCrystalLogo="False" HasSearchButton="False" HasDrilldownTabs="False"
                                                BestFitPage="true" BackColor="#ffffff" BorderStyle="Solid" BorderColor="#2977dc" BorderWidth="1px" />

                                            <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
                                                <Report FileName="rpt_summaryics.rpt"></Report>
                                            </CR:CrystalReportSource>

                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100%; height: 10px"></td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%"></td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%"></td>
                        <td style="width: 1%"></td>
                    </tr>
                </table>
            </div>


            <asp:Panel Style="border-top-width: 1px; border-left-width: 1px; border-left-color: #0033cc; border-bottom-width: 1px; border-bottom-color: #0033cc; border-top-color: #0033cc; background-color: transparent; text-align: center; border-right-width: 1px; border-right-color: #0033cc" ID="PanelProgress" runat="server" Width="109px">
                <img alt="" src="../../images/ajax-loader.gif" />
            </asp:Panel>
            <cc1:ModalPopupExtender ID="ProgressBarModalPopupExtender" runat="server" PopupControlID="PanelProgress" BackgroundCssClass="modalBackground" TargetControlID="ButtonProgress" BehaviorID="ProgressBarModalPopupExtender"></cc1:ModalPopupExtender>
            <asp:Button Style="border-top-style: none; border-right-style: none; border-left-style: none; background-color: transparent; border-bottom-style: none" ID="ButtonProgress" runat="server" Width="16px" Enabled="False"></asp:Button>&nbsp;&nbsp; 
       

        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>

