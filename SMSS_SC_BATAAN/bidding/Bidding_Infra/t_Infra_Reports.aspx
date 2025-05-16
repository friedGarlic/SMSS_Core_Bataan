<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="t_Infra_Reports.aspx.vb"
    Inherits="bidding_Bidding_Infra_t_Infra_Reports" Title="INFRA REPORTS" EnableEventValidation="false" StylesheetTheme="SkinFile" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>






            <div>
                <table width="1020px">
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="PageTitle">INFRASTRUCTURE REPORTS
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="left">
                            <asp:Button ID="btnBILL" runat="server" Width="150px" CssClass="Initial" Text="BILL OF QUANTITIES" OnClientClick="StartProgressBar();" OnClick="btnBILL_Click"></asp:Button>
                            <asp:Button ID="btnAbstract" runat="server" Width="150px" CssClass="Initial" Text="ABSTRACT OF BIDS" OnClientClick="StartProgressBar();" OnClick="btnAbstract_Click"></asp:Button>
                            <asp:Button ID="btnResolution" runat="server" Width="150px" CssClass="Initial" Text="BAC RESOLUTION" OnClientClick="StartProgressBar();" OnClick="btnResolution_Click"></asp:Button>
                            <asp:Button ID="btnNOA" runat="server" Width="150px" CssClass="Initial" Text="NOTICE OF AWARD" OnClientClick="StartProgressBar();" OnClick="btnNOA_Click"></asp:Button>
                            <asp:Button ID="btnNTP" runat="server" Width="150px" CssClass="Initial" Text="NOTICE TO PROCEED" OnClientClick="StartProgressBar();" OnClick="btnNTP_Click"></asp:Button>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <span class="column_RightBold">Search By :</span>
                            <asp:DropDownList ID="ddSearch" runat="server" Width="120px" CssClass="drpdownCSS">
                                <asp:ListItem Selected="True" Value="1">PR Number</asp:ListItem>
                                <asp:ListItem Value="2">Project Name</asp:ListItem>
                                <asp:ListItem Value="3">ITB Number</asp:ListItem>
                            </asp:DropDownList>
                            <asp:TextBox ID="txtSearch" runat="server" Width="300px" CssClass="txtbox_Var"></asp:TextBox>
                            <asp:Button ID="btnSearch" runat="server" Width="150px" CssClass="CSButton" Text="SEARCH" OnClientClick="StartProgressBar();" OnClick="btnSearch_Click"></asp:Button>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:GridView ID="grdInfra" runat="server" Width="98%" DataKeyNames="Infra_Hdr_ID" PageSize="15" AutoGenerateColumns="False" 
                                OnSelectedIndexChanged="grdInfra_SelectedIndexChanged" AllowPaging="True" SkinID="GridViewAA" EmptyDataText="No Data Found." 
                                >
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkView" runat="server" CssClass="LinkBtnPreview" Visible='<%# Bind("IsVisible") %>' CommandName="Select" Font-Underline="False">View</asp:LinkButton>
                                        </ItemTemplate>

                                        <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="pr_no" HeaderText="PR Number">
                                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="project_reference_no" HeaderText="ITB No.">
                                        <ItemStyle HorizontalAlign="Center" Width="13%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="project_name" HeaderText="Project Name">
                                        <ItemStyle HorizontalAlign="Left" Width="60%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Total_Amount" DataFormatString="{0:N}" HeaderText="Bid Amount">
                                        <ItemStyle HorizontalAlign="Right" Width="12%"></ItemStyle>
                                    </asp:BoundField>
                                </Columns>

                                <FooterStyle BackColor="#2977DC"></FooterStyle>

                                <HeaderStyle BackColor="#2977DC" ForeColor="White"></HeaderStyle>
                            </asp:GridView>
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
            <cc1:ModalPopupExtender ID="ProgressBarModalPopupExtender" runat="server" TargetControlID="ButtonProgress" PopupControlID="PanelProgress" BackgroundCssClass="modalBackground" BehaviorID="ProgressBarModalPopupExtender"></cc1:ModalPopupExtender>
            <asp:Button Style="border-top-style: none; border-right-style: none; border-left-style: none; background-color: transparent; border-bottom-style: none" ID="ButtonProgress" runat="server" Width="16px" Enabled="False"></asp:Button>&nbsp;&nbsp;
        
        
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

