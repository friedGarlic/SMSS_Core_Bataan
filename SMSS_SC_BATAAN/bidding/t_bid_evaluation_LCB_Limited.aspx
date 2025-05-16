<%@ Page 
    Language="VB" 
    AutoEventWireup="false" 
    CodeFile="t_bid_evaluation_LCB_Limited.aspx.vb" 
    EnableEventValidation="false"
    Inherits="bidding_t_bid_evaluation_LCB_Limited"
    MasterPageFile="~/MasterPage.master"
    Title="Bid Evaluation - Lowest Calculated Bid" 
    StylesheetTheme="SkinFile" %>

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
                <table width="1020px">
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="PageTitle">BID EVALUATION - LCB
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="right">
                            <span class="column_RightBold">Date :</span>
                            &nbsp;<asp:TextBox runat="server" ID="txtDate" Width="100px" CssClass="txtbox_Date"></asp:TextBox>
                            &nbsp;<span class="CalendarFormat">(MM/DD/YYYY)</span>
                            <cc1:CalendarExtender runat="server" TargetControlID="txtDate" PopupButtonID="txtDate"></cc1:CalendarExtender>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:GridView ID="grdBidEvaluation" runat="server" Width="80%" DataKeyNames="pre_procurement_hdr_id,TotalABC,CountSupplier,obr_evaluation_hdr_id,isPublicInfra"
                                PageSize="8" AutoGenerateColumns="False" OnSelectedIndexChanged="grdBidEvaluation_SelectedIndexChanged" OnRowDataBound="grdBidEvaluation_RowDataBound"
                                AllowPaging="True" SkinID="GridViewAA" OnPageIndexChanging="grdBidEvaluation_PageIndexChanging">
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
                        <td style="width: 98%" class="DivTitle"><asp:Label ID="lblBidEvaluationStage" runat="server" Text="Lowest Calculated Bid / Highest Rated Bid"></asp:Label>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                <ContentTemplate>
                                    <asp:Panel ID="Panel2" runat="server" Width="98%" CssClass="PanelSize" ScrollBars="Vertical">
                                        <asp:GridView ID="grdGoods" runat="server" Width="100%" SkinID="GridViewAA" AutoGenerateColumns="False" EmptyDataText="No Data Found." ShowFooter="True">
                                            <Columns>
                                                <asp:BoundField DataField="Item_Desc" HeaderText="Description">
                                                    <ItemStyle HorizontalAlign="Left" Width="40%"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="Qty">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblQty" runat="server" Text='<%# Bind("Qty") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" Width="8%"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:BoundField DataField="Unit" HeaderText="Unit">
                                                    <ItemStyle HorizontalAlign="Center" Width="8%"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Cost" DataFormatString="{0:N}" HeaderText="PR Price">
                                                    <ItemStyle HorizontalAlign="Right" Width="10%"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="Bidder Name">
                                                    <FooterTemplate>
                                                        TOTAL :
                                                    </FooterTemplate>
                                                    <ItemTemplate>
                                                        <asp:DropDownList ID="ddBidder" runat="server" Width="98%" OnSelectedIndexChanged="ddBidder_SelectedIndexChanged" CssClass="drpdownCSS" AutoPostBack="True"></asp:DropDownList>
                                                    </ItemTemplate>
                                                    <FooterStyle HorizontalAlign="Right" Font-Bold="True"></FooterStyle>
                                                    <ItemStyle HorizontalAlign="Center" Width="24%"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Total Amount">
                                                    <FooterTemplate>
                                                        <asp:Label ID="lblTotalBid" runat="server"></asp:Label>
                                                    </FooterTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblTotal" runat="server" Text='<%# Bind("Total", "{0:N}") %>'></asp:Label>
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
                        <td style="width: 98%; height: 10px"></td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="DivTitle">Bac Signatories
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <table style="width: 100%">
                                <tr>
                                    <td style="width: 15%" class="column_RightBold">BAC Member 1 :</td>
                                    <td style="width: 35%" class="column_Left">
                                        <asp:DropDownList ID="ddBAC1" runat="server" Width="90%" AutoPostBack="True" Enabled="False" CssClass="drpdownCSS"></asp:DropDownList></td>
                                    <td style="width: 15%" class="column_RightBold">BAC Vice Chairman : </td>
                                    <td style="width: 35%" class="column_Left">
                                        <asp:DropDownList ID="ddBACVC" runat="server" Width="90%" AutoPostBack="True" Enabled="False" CssClass="drpdownCSS"></asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td style="width: 15%" class="column_RightBold">BAC Member 2 :</td>
                                    <td style="width: 35%" class="column_Left">
                                        <asp:DropDownList ID="ddBAC2" runat="server" Width="90%" AutoPostBack="True" Enabled="False" CssClass="drpdownCSS"></asp:DropDownList></td>
                                    <td style="width: 15%" class="column_RightBold">BAC Chairman : </td>
                                    <td style="width: 35%" class="column_Left">
                                        <asp:DropDownList ID="ddBACC" runat="server" Width="90%" AutoPostBack="True" Enabled="False" CssClass="drpdownCSS"></asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td style="width: 15%" class="column_RightBold">BAC Member 3 :</td>
                                    <td style="width: 35%" class="column_Left">
                                        <asp:DropDownList ID="ddBAC3" runat="server" Width="90%" AutoPostBack="True" Enabled="False" CssClass="drpdownCSS"></asp:DropDownList></td>
                                    <td style="width: 15%" class="column_RightBold">BAC TWG-HEAD : </td>
                                    <td style="width: 35%" class="column_Left">
                                        <asp:DropDownList ID="ddBACTWGH" runat="server" Width="90%" AutoPostBack="True" Enabled="False" CssClass="drpdownCSS">
                                        </asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td style="width: 15%" class="column_RightBold"></td>
                                    <td style="width: 35%" class="column_Left"></td>
                                    <td style="width: 15%" class="column_RightBold">
                                        <asp:Label ID="lblBAC_Pos" runat="server" Text="BAC Vice Chairman :" Visible="False"></asp:Label></td>
                                    <td style="width: 35%" class="column_Left"></td>
                                </tr>
                                <tr>
                                    <td style="width: 15%" class="column_RightBold">End User : </td>
                                    <td style="width: 35%" class="column_Left">
                                        <asp:DropDownList ID="ddEndUser" runat="server" Width="90%" AutoPostBack="True" Enabled="False" CssClass="drpdownCSS"></asp:DropDownList></td>
                                    <td style="width: 15%" class="column_RightBold"></td>
                                    <td style="width: 35%" class="column_Left"></td>
                                </tr>
                            </table>

                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%; height: 10px"></td>
                        <td style="width: 1%"></td>
                    </tr>
                      <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" valign="top">
                            <span class="column_RightBold">Remarks :</span>
                            &nbsp;<asp:TextBox runat="server" ID="txtRemarks" Width="50%" TextMode="MultiLine" CssClass="txtbox_Remarks" Text="but the latter failed to submit its bid proposal"></asp:TextBox>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:Button ID="btnWinner" OnClick="btnWinner_Click" runat="server" Width="150px" CssClass="CSButton" Text="DECLARE WINNER/S" Enabled="False" OnClientClick="StartProgressBar();"></asp:Button>
                        </td>
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
            <cc1:ModalPopupExtender ID="ProgressBarModalPopupExtender" runat="server" BehaviorID="ProgressBarModalPopupExtender" BackgroundCssClass="modalBackground" PopupControlID="PanelProgress" TargetControlID="ButtonProgress"></cc1:ModalPopupExtender>
            <asp:Button Style="border-top-style: none; border-right-style: none; border-left-style: none; background-color: transparent; border-bottom-style: none" ID="ButtonProgress" runat="server" Width="16px" Enabled="False"></asp:Button>&nbsp; 
        
        
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>


