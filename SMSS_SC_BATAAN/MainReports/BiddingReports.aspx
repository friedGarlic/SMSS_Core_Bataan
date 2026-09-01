<%@ Page Title="Bidding Reports" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="BiddingReports.aspx.vb"
    Inherits="MainReports_BiddingReports" StylesheetTheme="SkinFile" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>



    <div>
        <table width="1020px">
            <tr>
                <td style="width: 1%"></td>
                <td style="width: 98%" class="PageTitle">BIDDING REPORTS
                </td>
                <td style="width: 1%"></td>
            </tr>
            <tr>
                <td style="width: 1%"></td>
                <td style="width: 98%" align="left">
                    <asp:LinkButton runat="server" ID="lnkBack" CssClass="LinkBtnSelect" Text="Back to Previous Page ..."></asp:LinkButton>
                </td>
                <td style="width: 1%"></td>
            </tr>
            <tr>
                <td style="width: 1%"></td>
                <td style="width: 98%" align="center">
                    <asp:RadioButtonList runat="server" ID="rbPreProcReports" CssClass="rbCS_Horizontal" Width="300px" RepeatDirection="Horizontal" AutoPostBack="true">
                        <asp:ListItem Value="1" Text="ORDER OF PAYMENT"></asp:ListItem>
                        <asp:ListItem Value="2" Text="BID FORM"></asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                <td style="width: 1%"></td>
            </tr>
            <tr>
                <td style="width: 1%"></td>
                <td style="width: 98%" align="center">
                    <asp:Panel runat="server" ID="pnlOP" Width="90%" Visible="false">
                        <table width="100%">
                            <tr>
                                <td style="width: 100%" align="center">
                                    <span class="column_RightBold">Select Bidder :</span>
                                    &nbsp;<asp:DropDownList runat="server" ID="drpSupplier" CssClass="drpdownCSS" Width="40%"></asp:DropDownList>
                                    &nbsp;<asp:Button runat="server" ID="btnPreviewOP" CssClass="CSButton" Width="12%" Text="Preview"/>
                                </td>
                            </tr>                          
                        </table>
                    </asp:Panel>
                </td>
                <td style="width: 1%"></td>
            </tr>
            <tr>
                <td style="width: 1%"></td>
                <td style="width: 98%" align="center">
                    <CR:CrystalReportViewer ID="BiddingReports" runat="server" AutoDataBind="true" HasToggleGroupTreeButton="False" HasCrystalLogo="False"
                        HasSearchButton="False" HasDrilldownTabs="False" BestFitPage="true" BackColor="#ffffff"
                        BorderStyle="Solid" BorderColor="#2977dc" BorderWidth="1px" />


                    <CR:CrystalReportSource ID="CRS_withPreBid" runat="server">
                        <Report FileName="ITB_withPreBid.rpt">
                        </Report>
                    </CR:CrystalReportSource>

                    <CR:CrystalReportSource ID="CRS_wOutPreBid" runat="server">
                        <Report FileName="ITB_wOutPreBid.rpt">
                        </Report>
                    </CR:CrystalReportSource>

                    <CR:CrystalReportSource ID="CRS_OP" runat="server">
                        <Report FileName="rpt_OP.rpt">
                        </Report>
                    </CR:CrystalReportSource>

                    <CR:CrystalReportSource ID="CRS_BidForm" runat="server">
                        <Report FileName="rpt_BidForm.rpt">
                        </Report>
                    </CR:CrystalReportSource>

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



    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <asp:Panel Style="border-top-width: 1px; border-left-width: 1px; border-left-color: #0033cc; border-bottom-width: 1px; border-bottom-color: #0033cc; border-top-color: #0033cc; position: relative; background-color: transparent; text-align: center; border-right-width: 1px; border-right-color: #0033cc" ID="PanelProgress" runat="server" Width="109px">
                <img alt="" src="../images/ajax-loader.gif" />
            </asp:Panel>
            <cc1:ModalPopupExtender ID="ProgressBarModalPopupExtender" runat="server" TargetControlID="ButtonProgress" BackgroundCssClass="modalBackground" PopupControlID="PanelProgress" BehaviorID="ProgressBarModalPopupExtender"></cc1:ModalPopupExtender>
            <asp:Button Style="border-top-style: none; border-right-style: none; border-left-style: none; position: relative; background-color: transparent; border-bottom-style: none" ID="ButtonProgress" runat="server" Width="16px" Enabled="False"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
        
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>

