<%@ Page 
    Language="VB" 
    AutoEventWireup="false" 
    MasterPageFile="~/MasterPage.master" 
    EnableEventValidation="false"
    CodeFile="t_bid_evaluation_ceiling_Limited.aspx.vb" 
    Inherits="t_bid_evaluation_ceiling_Limited"
    StylesheetTheme="SkinFile"
    Title="Bid Evaluation - Ceiling of Prices"  %>

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
                        <td style="width: 98%" class="PageTitle">BID EVALUATION
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:GridView ID="grdBidEvaluation" runat="server" Width="80%" OnPageIndexChanging="grdBidEvaluation_PageIndexChanging" SkinID="GridViewAA"
                                AllowPaging="True" OnRowDataBound="grdBidEvaluation_RowDataBound" OnSelectedIndexChanged="grdBidEvaluation_SelectedIndexChanged" AutoGenerateColumns="False"
                                PageSize="8" DataKeyNames="pre_procurement_hdr_id,TotalABC,CountSupplier,obr_evaluation_hdr_id,isPublicInfra">
                                <Columns>
                                    <asp:BoundField DataField="RefNumber" HeaderText="Reference Number">
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="BidLocation" HeaderText="Bid Location">
                                        <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="countSupplier" HeaderText="No. of Bidders">
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="TotalABC" DataFormatString="{0:N}" HeaderText="Total ABC">
                                        <ItemStyle HorizontalAlign="Right"></ItemStyle>
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
                        <td style="width: 98%" class="DivTitle"><asp:Label ID="lblBidEvaluationStage" runat="server" Text="Ceiling For Bid Prices"></asp:Label>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:GridView ID="grdBidders" runat="server" Width="90%" SkinID="GridViewAA" AutoGenerateColumns="False" PageSize="8" DataKeyNames="bid_opening_hdr_id"
                                EmptyDataText="No Data Found.">
                                <Columns>
                                    <asp:BoundField DataField="SuppName" HeaderText="Bidder Name">
                                        <ItemStyle HorizontalAlign="Left" Width="70%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="NoItems" HeaderText="No. of Items">
                                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="BidAmount" DataFormatString="{0:N}" HeaderText="Total Bid Amount">
                                        <ItemStyle HorizontalAlign="Right" Width="15%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Pass Criteria">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="CheckBox1" runat="server" OnCheckedChanged="CheckBox1_CheckedChanged" AutoPostBack="True"></asp:CheckBox>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
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
                            <asp:Button ID="btnback" OnClick="btnback_Click" runat="server" Width="150px" CssClass="CSButton" Text="PREVIOUS STEP" Enabled="False" OnClientClick="StartProgressBar();"></asp:Button>
                            &nbsp;<asp:Button ID="btnFail" OnClick="btnFail_Click1" runat="server" Width="150px" CssClass="CSButton" Text="FAILURE OF BIDDING" Enabled="False" OnClientClick="StartProgressBar();"></asp:Button>
                            &nbsp;<asp:Button ID="btnNext" OnClick="btnNext_Click" runat="server" Width="150px" CssClass="CSButton" Text="NEXT STEP" Enabled="False" OnClientClick="StartProgressBar();"></asp:Button>
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
                <img alt="" src="../images/ajax-loader.gif" />
            </asp:Panel>
            <cc1:ModalPopupExtender ID="ProgressBarModalPopupExtender" runat="server" TargetControlID="ButtonProgress" PopupControlID="PanelProgress" BehaviorID="ProgressBarModalPopupExtender">
            </cc1:ModalPopupExtender>
            <asp:Button Style="border-top-style: none; border-right-style: none; border-left-style: none; background-color: transparent; border-bottom-style: none" ID="ButtonProgress" runat="server" Width="16px" Enabled="False"></asp:Button> 
        
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

