<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="t_Infra_Abstract.aspx.vb"
    Inherits="bidding_Bidding_Infra_t_Infra_Abstract" Title="INFRA ABSTRACT" EnableEventValidation="false" StylesheetTheme="SkinFile" %>

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
                        <td style="width: 98%" class="PageTitle">ABSTRACT OF BIDS - INFRA
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="right">
                            <span class="column_RightBold">Date :</span>
                            <asp:TextBox ID="txtDate" runat="server" Width="100px" CssClass="txtbox_Date"></asp:TextBox>
                            <span class="CalendarFormat">(MM/DD/YYYY)</span>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:GridView ID="grdProjectList" runat="server" Width="90%" DataKeyNames="Infra_Hdr_ID,pre_procurement_hdr_id,RC_ID,Function_ID" PageSize="8" AutoGenerateColumns="False" EmptyDataText="No Data Found." SkinID="GridViewAA" AllowPaging="True" OnSelectedIndexChanged="grdProjectList_SelectedIndexChanged">
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkSelect" runat="server" Font-Underline="False" CssClass="LinkBtnSelect" CommandName="Select" Visible='<%# Bind("isVisible") %>' OnClick="lnkSelect_Click">Select</asp:LinkButton>
                                        </ItemTemplate>

                                        <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="pr_no" HeaderText="PR Number">
                                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="project_name" HeaderText="Project Name">
                                        <ItemStyle HorizontalAlign="Left" Width="70%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ABC" DataFormatString="{0:N}" HeaderText="ABC">
                                        <ItemStyle HorizontalAlign="Right" Width="15%"></ItemStyle>
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
                        <td style="width: 98%" class="DivTitle">List Of Bidders
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:GridView ID="grdBidders" runat="server" Width="75%" DataKeyNames="Supplier_ID,Infra_BidderHdr_ID" EmptyDataText="No Data Found." SkinID="GridViewAA" OnSelectedIndexChanged="grdBidders_SelectedIndexChanged" ShowFooter="True">
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkSelect" OnClick="lnkSelect_Click1" runat="server" CssClass="LinkBtnSelect" Font-Underline="False" CommandName="Select">Select</asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="7%"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="SuppName" HeaderText="Bidder Name">
                                        <ItemStyle HorizontalAlign="Left" Width="65%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Total_Amount" DataFormatString="{0:N}" HeaderText="Total Bid Amount">
                                        <ItemStyle HorizontalAlign="Right" Width="20%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Declare">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkWinner" OnClick="lnkWinner_Click" runat="server" CssClass="LinkBtnSelect" Font-Underline="False" CommandName="Select" OnClientClick="StartProgressBar();">Winner</asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="8%"></ItemStyle>
                                    </asp:TemplateField>
                                </Columns>
                                <FooterStyle BackColor="#2977DC"></FooterStyle>
                                <HeaderStyle BackColor="#2977DC" ForeColor="White"></HeaderStyle>
                            </asp:GridView>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:Panel ID="PanelSignatory" runat="server" Width="90%" CssClass="panel_border" HorizontalAlign="Center" Visible="False">
                                <table style="width: 98%">
                                    <tr>
                                        <td style="width: 3%" class="column_LeftBold"></td>
                                        <td style="width: 12%" class="column_LeftBold"></td>
                                        <td style="width: 35%" class="column_Left"></td>
                                        <td style="width: 15%" class="column_LeftBold"></td>
                                        <td style="width: 35%" class="column_Left"></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 3%" class="column_LeftBold"></td>
                                        <td style="width: 12%" class="column_LeftBold">BAC Member :</td>
                                        <td style="width: 35%" class="column_Left">
                                            <asp:DropDownList ID="ddBACMember1" runat="server" Width="95%" CssClass="drpdownCSS"></asp:DropDownList></td>
                                        <td style="width: 15%" class="column_LeftBold">BAC Vice Chairman:</td>
                                        <td style="width: 35%" class="column_Left">
                                            <asp:DropDownList ID="ddBACVChair" runat="server" Width="95%" CssClass="drpdownCSS"></asp:DropDownList></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 3%" class="column_LeftBold"></td>
                                        <td style="width: 12%" class="column_LeftBold">BAC Member :</td>
                                        <td style="width: 35%" class="column_Left">
                                            <asp:DropDownList ID="ddBACMember2" runat="server" Width="95%" CssClass="drpdownCSS"></asp:DropDownList></td>
                                        <td style="width: 15%" class="column_LeftBold">BAC Chairman :</td>
                                        <td style="width: 35%" class="column_Left">
                                            <asp:DropDownList ID="ddBACChair" runat="server" Width="95%" CssClass="drpdownCSS"></asp:DropDownList></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 3%" class="column_LeftBold"></td>
                                        <td style="width: 12%" class="column_LeftBold">BAC Member :</td>
                                        <td style="width: 35%" class="column_Left">
                                            <asp:DropDownList ID="ddBACMember3" runat="server" Width="95%" CssClass="drpdownCSS"></asp:DropDownList></td>
                                        <td style="width: 15%" class="column_LeftBold"></td>
                                        <td style="width: 35%" class="column_Left"></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 3%" class="column_LeftBold"></td>
                                        <td style="width: 12%" class="column_LeftBold">End User :</td>
                                        <td style="width: 35%" class="column_Left">
                                            <asp:DropDownList ID="ddPreparedBy" runat="server" Width="95%" CssClass="drpdownCSS"></asp:DropDownList></td>
                                        <td style="width: 15%" class="column_LeftBold">BAC TWG Head :</td>
                                        <td style="width: 35%" class="column_Left">
                                            <asp:DropDownList ID="ddApprovedBy" runat="server" Width="95%" CssClass="drpdownCSS"></asp:DropDownList></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 3%" class="column_LeftBold"></td>
                                        <td style="width: 12%" class="column_LeftBold"></td>
                                        <td style="width: 35%" class="column_Left"></td>
                                        <td style="width: 15%" class="column_LeftBold"></td>
                                        <td style="width: 35%" class="column_Left"></td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="DivTitle">Information / Details</td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <span class="column_RightBold">Bidder : </span>
                            &nbsp;<asp:DropDownList ID="drpBidderName" runat="server" Width="50%" CssClass="drpdownCSS" OnSelectedIndexChanged="drpBidderName_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:GridView ID="grdDetails" runat="server" Width="85%" DataKeyNames="Infra_Dtl_ID" EmptyDataText="No Data Found." SkinID="GridViewAA" ShowFooter="True">
                                <Columns>
                                    <asp:BoundField DataField="PartNo" HeaderText="Part No.">
                                        <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Description" HeaderText="Description">
                                        <ItemStyle HorizontalAlign="Left" Width="50%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Unit" HeaderText="Unit">
                                        <ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Quantity" HeaderText="Quantity" FooterText="TOTAL :">
                                        <FooterStyle HorizontalAlign="Right" Font-Bold="True"></FooterStyle>

                                        <ItemStyle HorizontalAlign="Right" Width="10%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Bid Amount">
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalAmount" runat="server" Font-Bold="True">0.00</asp:Label>
                                        </FooterTemplate>
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtBidAmount" runat="server" Width="90%" CssClass="txtboxAmount" AutoPostBack="True" Text='<%#Bind("Bid_Price") %>' OnTextChanged="txtBidAmount_TextChanged"></asp:TextBox>
                                        </ItemTemplate>

                                        <FooterStyle HorizontalAlign="Right"></FooterStyle>

                                        <ItemStyle HorizontalAlign="Center" Width="20%"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Infra_Dtl_ID" Visible="False">
                                        <ItemTemplate>
                                            <asp:Label ID="lblInfra_Dtl_ID" runat="server" Text='<%# Bind("Infra_Dtl_ID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Infra_BidderDtl_ID" Visible="False">
                                        <ItemTemplate>
                                            <asp:Label ID="lblInfra_BidderDtl_ID" runat="server" Text='<%# Bind("Infra_BidderDtl_ID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>

                                <FooterStyle BackColor="#2977DC"></FooterStyle>
                                <HeaderStyle BackColor="#2977DC" ForeColor="White"></HeaderStyle>
                            </asp:GridView>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <table style="width: 95%">
                                <tbody>
                                    <tr>
                                        <td style="width: 18%" class="column_LeftBold">Time Duration CD</td>
                                        <td style="width: 2%" class="column_LeftBold">:</td>
                                        <td style="width: 30%" class="column_Left">
                                            <asp:TextBox ID="txtTimeDuration" runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox></td>
                                        <td style="width: 18%" class="column_LeftBold">Bid Security Amount</td>
                                        <td style="width: 2%" class="column_LeftBold">:</td>
                                        <td style="width: 30%" class="column_Left">
                                            <asp:TextBox ID="txtBidSecurityAmt" runat="server" Width="50%" CssClass="txtbox_Amt">0.00</asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 18%" class="column_LeftBold">Form of Bid Security</td>
                                        <td style="width: 2%" class="column_LeftBold">:</td>
                                        <td style="width: 30%" class="column_Left">
                                            <asp:TextBox ID="txtBidSecurityForm" runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox></td>
                                        <td style="width: 18%" class="column_LeftBold">Required Bid Security</td>
                                        <td style="width: 2%" class="column_LeftBold">:</td>
                                        <td style="width: 30%" class="column_Left">
                                            <asp:TextBox ID="txtRequiredBidSec" runat="server" Width="50%" CssClass="txtbox_Amt">0.00</asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 18%" class="column_LeftBold">Bank / Company</td>
                                        <td style="width: 2%" class="column_LeftBold">:</td>
                                        <td style="width: 30%" class="column_Left">
                                            <asp:TextBox ID="txtBankCampany" runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox></td>
                                        <td style="width: 18%" class="column_LeftBold">Sufficient / Insufficient</td>
                                        <td style="width: 2%" class="column_LeftBold">:</td>
                                        <td style="width: 30%" class="column_Left">
                                            <asp:DropDownList ID="ddSufficient" runat="server" Width="92%" CssClass="drpdownCSS">
                                                <asp:ListItem Selected="True" Value="1">SUFFICIENT</asp:ListItem>
                                                <asp:ListItem Value="2">INSUFFICIENT</asp:ListItem>
                                            </asp:DropDownList></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 18%" class="column_LeftBold">Number</td>
                                        <td style="width: 2%" class="column_LeftBold">:</td>
                                        <td style="width: 30%" class="column_Left">
                                            <asp:TextBox ID="txtNumber" runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox></td>
                                        <td style="width: 18%" class="column_LeftBold">Remarks</td>
                                        <td style="width: 2%" class="column_LeftBold">:</td>
                                        <td style="vertical-align: top; width: 30%; text-align: left" class="column_Left" rowspan="2">
                                            <asp:TextBox ID="txtRemarks" runat="server" Width="90%" CssClass="txtbox_Remarks" Height="40px"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 18%" class="column_LeftBold">Validity Period</td>
                                        <td style="width: 2%" class="column_LeftBold">:</td>
                                        <td style="width: 30%" class="column_Left">
                                            <asp:TextBox ID="txtValidityPeriod" runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox></td>
                                        <td style="width: 18%" class="column_LeftBold"></td>
                                        <td style="width: 2%" class="column_LeftBold"></td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:Button ID="btnSave" OnClick="btnSave_Click" runat="server" Width="150px" CssClass="CSButton" Text="SAVE" OnClientClick="StartProgressBar();"></asp:Button>
                            &nbsp;<asp:Button ID="btnPreview" OnClick="btnPreview_Click" runat="server" Width="150px" CssClass="CSButton" Text="PREVIEW" Enabled="False"></asp:Button>
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
            <cc1:ModalPopupExtender ID="ProgressBarModalPopupExtender" runat="server" TargetControlID="ButtonProgress" PopupControlID="PanelProgress" BehaviorID="ProgressBarModalPopupExtender" BackgroundCssClass="modalBackground"></cc1:ModalPopupExtender>
            <asp:Button Style="border-top-style: none; border-right-style: none; border-left-style: none; background-color: transparent; border-bottom-style: none" ID="ButtonProgress" runat="server" Width="16px" Enabled="False"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp; 
       
            
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>

