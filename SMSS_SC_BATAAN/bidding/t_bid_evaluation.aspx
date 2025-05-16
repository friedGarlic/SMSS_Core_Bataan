<%@ Page 
    Language="VB" 
    AutoEventWireup="false" 
    MasterPageFile="~/MasterPage.master" 
    EnableEventValidation="false"
    StylesheetTheme="SkinFile" 
    CodeFile="t_bid_evaluation.aspx.vb" 
    Inherits="bidding_t_bid_evaluation" 
    Title="Bid Evaluation" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    
    <script type="text/javascript">
        // It is important to place this JavaScript code after ScriptManager1
        var xPos, yPos;
        var prm = Sys.WebForms.PageRequestManager.getInstance();

        function BeginRequestHandler(sender, args) {
            if ($get('<%=Panel2.ClientID%>') != null) {
                // Get X and Y positions of scrollbar before the partial postback
                xPos = $get('<%=Panel2.ClientID%>').scrollLeft;
                yPos = $get('<%=Panel2.ClientID%>').scrollTop;
            }
        }

        function EndRequestHandler(sender, args) {
            if ($get('<%=Panel2.ClientID%>') != null) {
                // Set X and Y positions back to the scrollbar
                // after partial postback
                $get('<%=Panel2.ClientID%>').scrollLeft = xPos;
                $get('<%=Panel2.ClientID%>').scrollTop = yPos;
            }
        }

        prm.add_beginRequest(BeginRequestHandler);
        prm.add_endRequest(EndRequestHandler);
    </script>






    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>


            <div>
                <table width="100%">
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="PageTitle">BID EVALUATION
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:GridView ID="grdBidEvaluation" runat="server" Width="70%" SkinID="GridViewAA" PageSize="8" OnSelectedIndexChanged="grdBidEvaluation_SelectedIndexChanged"
                                AutoGenerateColumns="False" AllowPaging="True" DataKeyNames="pre_procurement_hdr_id,TotalABC,CountSupplier,obr_evaluation_hdr_id,isPublicInfra"
                                OnRowDataBound="grdBidEvaluation_RowDataBound" OnPageIndexChanging="grdBidEvaluation_PageIndexChanging">
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
                        <td style="width: 98%" class="DivTitle"><asp:Label ID="lblBidEvaluationStage" runat="server" Text="Preliminary Examination Of Bids"></asp:Label>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <span class="column_RightBold">Bidder Name :</span>
                            &nbsp;<asp:DropDownList ID="ddBidder" runat="server" Width="400px" OnSelectedIndexChanged="ddBidder_SelectedIndexChanged" CssClass="drpdownCSS" Enabled="False" AutoPostBack="True"></asp:DropDownList>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="DivTitle">List Of Goods
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                <ContentTemplate>
                                    <asp:Panel ID="Panel2" runat="server" Width="98%" CssClass="PanelSize" ScrollBars="Vertical">
                                        <asp:GridView ID="grdGoods" runat="server"  Width="100%"  SkinID="GridViewAA" PageSize="8" AutoGenerateColumns="False"
                                            EmptyDataText="No Data Found." ShowFooter="True" DataKeyNames="PRDtlID" OnSelectedIndexChanged="grdGoods_SelectedIndexChanged">
                                            <Columns>
                                                   <asp:TemplateField HeaderText="" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:LinkButton runat="server" ID="lnkRemove" CssClass="LinkBtnCancel" Text="Delete" CommandName="Select" Font-Underline="false" OnClick="lnkRemove_Click"></asp:LinkButton>
                                                        <cc1:ConfirmButtonExtender runat="server" ID="confirmBtn" TargetControlID="lnkRemove" ConfirmOnFormSubmit="true"  ConfirmText="Are you sure to remove this item from Purchase Request?"></cc1:ConfirmButtonExtender>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:BoundField DataField="Item_Desc" HeaderText="Description" HtmlEncode="false">
                                                    <ItemStyle HorizontalAlign="Left" Width="49%"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Unit" HeaderText="Unit">
                                                    <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Cost" DataFormatString="{0:N}" HeaderText="Unit Price">
                                                    <ItemStyle HorizontalAlign="Right" Width="10%"></ItemStyle>
                                                </asp:BoundField>

                                                <asp:TemplateField HeaderText="Quantity">
                                                    <ItemTemplate>
                                                        <asp:label ID="txtQty" runat="server" Width="95%" Text='<%# Bind("Qty") %>'  OnTextChanged="txtQty_TextChanged"></asp:label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" Width="8%"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Bid Unit Price">
                                                    <FooterTemplate>
                                                        <strong>TOTAL :</strong>
                                                    </FooterTemplate>
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtBidUnitPrice" runat="server" Width="95%" Text='<%# Bind("Cost", "{0:N}") %>' AutoPostBack="True" CssClass="txtbox_Amt" OnTextChanged="txtBidUnitPrice_TextChanged"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <FooterStyle HorizontalAlign="Right"></FooterStyle>
                                                    <ItemStyle HorizontalAlign="Center" Width="8%"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Total">
                                                    <FooterTemplate>
                                                        <asp:Label ID="lblTotalBid" runat="server" Font-Bold="True"></asp:Label>
                                                    </FooterTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblTotal" runat="server"></asp:Label>
                                                    </ItemTemplate>

                                                    <FooterStyle HorizontalAlign="Right"></FooterStyle>
                                                    <ItemStyle HorizontalAlign="Right" Width="10%"></ItemStyle>
                                                </asp:TemplateField>
                                            </Columns>

                                            <FooterStyle BackColor="#2977DC"></FooterStyle>
                                            <HeaderStyle BackColor="#2977DC" ForeColor="White"></HeaderStyle>
                                        </asp:GridView>
                                    </asp:Panel>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:Button ID="btnSave" OnClick="btnSave_Click" runat="server" Width="150px" CssClass="CSButton" Text="SAVE" Enabled="False" OnClientClick="StartProgressBar();"></asp:Button>
                            &nbsp;<asp:Button ID="btnCancel" OnClick="btnCancel_Click" Visible="false" runat="server" Width="150px" CssClass="CSButton" Text="CANCEL" Enabled="False" OnClientClick="StartProgressBar();"></asp:Button>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%;height:10px"></td>
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
                            <asp:GridView ID="grdBidders" runat="server" Width="80%" SkinID="GridViewAA" PageSize="8" AutoGenerateColumns="False" 
                                EmptyDataText="No Data Found.">
                                <Columns>
                                    <asp:BoundField DataField="SuppName" HeaderText="Bidder Name">
                                        <ItemStyle HorizontalAlign="Left" Width="500px"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="NoItems" HeaderText="No. of Items">
                                        <ItemStyle HorizontalAlign="Center" Width="100px"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="BidAmount" DataFormatString="{0:N}" HeaderText="Total Bid Amount">
                                        <ItemStyle HorizontalAlign="Right" Width="200px"></ItemStyle>
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
                        <td style="width: 98%" align="center">
                            <asp:Button ID="btnback" OnClick="btnback_Click" runat="server" Width="150px" CssClass="CSButton" Text="PREVIOUS STEP" OnClientClick="StartProgressBar();" Enabled="false"></asp:Button>
                            &nbsp;<asp:Button ID="btnFail" OnClick="btnFail_Click1" runat="server" Width="150px" CssClass="CSButton" Text="FAILURE OF BIDDING" Enabled="False" OnClientClick="StartProgressBar();"></asp:Button>
                            &nbsp;<asp:Button ID="btnNext" OnClick="btnNext_Click" runat="server" Width="150px" CssClass="CSButton" Text="NEXT STEP" Enabled="False" OnClientClick="StartProgressBar();"></asp:Button>
                            <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender2" runat="server" TargetControlID="btnFail" ConfirmText="About to declare failure of bidding.">
                            </cc1:ConfirmButtonExtender>
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


            


            <asp:Panel Style="border-top-width: 1px; border-left-width: 1px; border-left-color: #0033cc; border-bottom-width: 1px; border-bottom-color: #0033cc; border-top-color: #0033cc; background-color: transparent; text-align: center; border-right-width: 1px; border-right-color: #0033cc" ID="PanelProgress" runat="server" Width="109px" Enabled="False">
                <img alt="" src="../images/ajax-loader.gif" />
            </asp:Panel>
            <cc1:ModalPopupExtender ID="ProgressBarModalPopupExtender" runat="server" TargetControlID="ButtonProgress" PopupControlID="PanelProgress" BehaviorID="ProgressBarModalPopupExtender" BackgroundCssClass="modalBackground">
            </cc1:ModalPopupExtender>
            <asp:Button Style="border-top-style: none; border-right-style: none; border-left-style: none; background-color: transparent; border-bottom-style: none" ID="ButtonProgress" runat="server" Width="16px" Enabled="False"></asp:Button> 
        
        
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
