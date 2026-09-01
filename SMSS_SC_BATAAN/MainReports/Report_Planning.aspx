<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Report_Planning.aspx.vb" Inherits="MainReports_Report_Planning" %>


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
                <td style="width: 98%" class="PageTitle">PROJECT PROCUREMENT MANAGEMENT PLAN REPORT
                </td>
                <td style="width: 1%"></td>
            </tr>

            <tr>
                <td style="width: 1%"></td>
                <td style="width: 98%" class="column_Left">
                    <asp:LinkButton ID="lnkBackPrevious" runat="server" Font-Underline="true" CssClass="LinkBtnSelect" Text="Back To Previous Page ...">
                    </asp:LinkButton>
                </td>
                <td style="width: 1%"></td>
            </tr>
            <tr>
                  <td style="width: 1%"></td>
                <td style="width: 1%" align="left">
                 <asp:RadioButtonList ID="PPMP_FORMAT" runat="server" AutoPostBack="True" CssClass="rbCS_Vertical"
                        RepeatDirection="Horizontal" Width="300px">
                        <asp:ListItem Value="1" >PPMP CONSOLIDATED</asp:ListItem>
                        <asp:ListItem Value="2" Selected="True">PPMP PER PPA</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>

            <tr>
                <td style="width: 1%"></td>
                <td style="width: 98%" class="column_Center">
                    <div style="width: 1000px; background-color: #ffffff; text-align: center; vertical-align: middle">
                        <table width="100%">
                            <tr>
                                <td style="width: 100%; height: 5px"></td>
                            </tr>
                            <tr>
                                <td style="width: 100%" align="center">
                                    <CR:CrystalReportViewer ID="PlanningReports" runat="server" AutoDataBind="true" HasToggleGroupTreeButton="False" HasCrystalLogo="False" HasSearchButton="False" HasDrilldownTabs="False"
                                        BestFitPage="False" BackColor="#ffffff" Height="910px" Width="980px" BorderStyle="Solid" BorderColor="#999999" BorderWidth="1px" />
                                  
                                    
                                    <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">                                    
                                    </CR:CrystalReportSource>
                                    <CR:CrystalReportSource ID="CrystalReportSource2" runat="server">       
                                        <Report FileName="PPMP_Monthly_Revision.rpt"></Report>
                                    </CR:CrystalReportSource>
                                    <CR:CrystalReportSource ID="CrystalReportSource3" runat="server">       
                                        <Report FileName="PPMP_Monthly_PERPPA.rpt"></Report>
                                    </CR:CrystalReportSource>

                                </td>
                            </tr>
                            <tr>
                                <td style="width: 100%; height: 5px"></td>
                            </tr>
                        </table>
                    </div>


                </td>
                <td style="width: 1%"></td>
            </tr>
            <tr>
                <td style="width: 1%"></td>
                <td style="width: 98%; height: 10px"></td>
                <td style="width: 1%"></td>
            </tr>
        </table>
    </div>

    <asp:UpdatePanel runat="server" ID="UpdatePanel1">
        <ContentTemplate>

          <asp:Panel Style="border-top-width: 1px; border-left-width: 1px; border-left-color: #0033cc; border-bottom-width: 1px; border-bottom-color: #0033cc; border-top-color: #0033cc; background-color: transparent; text-align: center; border-right-width: 1px; border-right-color: #0033cc" ID="PanelProgress" runat="server" Width="109px">
                <img alt="" src="../images/ajax-loader.gif" />
            </asp:Panel>
            <cc1:ModalPopupExtender ID="ProgressBarModalPopupExtender" runat="server" BackgroundCssClass="modalBackground" TargetControlID="ButtonProgress" PopupControlID="PanelProgress" BehaviorID="ProgressBarModalPopupExtender"></cc1:ModalPopupExtender>
            <asp:Button Style="border-top-style: none; border-right-style: none; border-left-style: none; background-color: transparent; border-bottom-style: none" ID="ButtonProgress" runat="server" Width="16px" Enabled="False"></asp:Button>



        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
