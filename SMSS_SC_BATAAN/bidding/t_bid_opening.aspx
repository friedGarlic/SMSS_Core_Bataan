<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" EnableEventValidation="false"
    StylesheetTheme="SkinFile" CodeFile="t_bid_opening.aspx.vb" Inherits="bidding_t_bid_opening" Title="BID Opening" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <script language="javascript" type="text/javascript">
        function Table2_onclick() {
        }
        function fun1(e, button1) {
            var evt = e ? e : window.event;
            var bt = document.getElementById(button1);
            if (bt) {
                if (evt.keyCode == 13) {
                    bt.click();
                    return false;
                }
            }
        }
    </script>

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
                        <td style="width: 98%" class="PageTitle">BID OPENING
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:GridView ID="grdOpenBid" runat="server" Width="80%" OnPageIndexChanging="grdOpenBid_PageIndexChanging" AllowPaging="True"
                                OnRowDataBound="grdOpenBid_RowDataBound" PageSize="8" OnSelectedIndexChanged="grdOpenBid_SelectedIndexChanged"
                                AutoGenerateColumns="False" DataKeyNames="pre_procurement_hdr_id,TotalABC,CountSupplier,obr_evaluation_hdr_id,isPublicInfra"
                                SkinID="GridViewAA">
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
                        <td style="width: 98%" class="DivTitle">List Of Bidders
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                                    <asp:Panel ID="Panel2" runat="server" Width="98%" CssClass="PanelSize" HorizontalAlign="Center" ScrollBars="Vertical">
                                        <asp:GridView ID="gvsupplier" runat="server" Width="100%" PageSize="5" OnSelectedIndexChanged="gvsupplier_SelectedIndexChanged" AutoGenerateColumns="False"
                                            DataKeyNames="Supplier_Id" SkinID="GridViewAA" EmptyDataText="No Data Found.">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Bid Security Details">
                                                    <ItemTemplate>
                                                        <table style="width: 100%">
                                                            <tbody>
                                                                <tr>
                                                                    <td style="width: 15%" class="column_RightBold">Bidder Name :</td>
                                                                    <td style="width: 40%" class="text5">
                                                                        <asp:Label ID="lblBidder" runat="server" Font-Bold="True" ForeColor="Red" Font-Size="11pt" Text='<%#Bind("SuppName") %>'></asp:Label></td>
                                                                    <td style="width: 15%" class="column_RightBold">Required Bid Security :</td>
                                                                    <td style="width: 30%" class="text5">
                                                                        <asp:TextBox Style="text-align: right" ID="txtRequiredBid" runat="server" Width="150px" Text='<%#Bind("requiredBid_security", "{0:N}") %>' CssClass="txtbox_Amt" Visible='<%# bind("isVisible") %>' ReadOnly="True"></asp:TextBox></td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 15%" class="column_RightBold">Form of Bid Security :</td>
                                                                    <td style="width: 40%" class="text5">
                                                                        <asp:DropDownList ID="ddBid" runat="server" Width="150px" OnSelectedIndexChanged="ddBid_SelectedIndexChanged" CssClass="txtboxinspection" AutoPostBack="True"></asp:DropDownList></td>
                                                                    <td style="width: 15%" class="column_RightBold">Total Bid Amount :</td>
                                                                    <td style="width: 30%" class="text5">
                                                                        <asp:TextBox Style="text-align: right" ID="txtamount" runat="server" Width="150px" Text='<%#Bind("amount", "{0:N}") %>' CssClass="txtbox_Amt" Visible='<%# bind("isVisible") %>' AutoPostBack="True" OnTextChanged="txtamount_TextChanged" Onkeyup="javascript:this.value=Comma(this.value);" Onchange="this.value=formatCurrency(this.value);"></asp:TextBox><cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtamount" ValidChars="0123456789.,"></cc1:FilteredTextBoxExtender>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 15%" class="column_RightBold">Bank / Company :</td>
                                                                    <td style="width: 40%" class="text5">
                                                                        <asp:TextBox ID="txtBankName" runat="server" Width="90%" Text='<%#Bind("bank") %>' CssClass="txtbox_Var" Visible='<%# bind("isVisible") %>' OnTextChanged="txtBankName_TextChanged"></asp:TextBox></td>
                                                                    <td style="width: 15%" class="column_RightBold">Remarks :</td>
                                                                    <td style="vertical-align: top; width: 30%" class="text5" rowspan="2">
                                                                        <asp:TextBox ID="txtRemarks" runat="server" Width="90%" CssClass="txtbox_Remarks" Visible='<%#Bind("isVisible") %>' OnTextChanged="txtRemarks_TextChanged" Height="50px" TextMode="MultiLine"></asp:TextBox></td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 15%" class="column_RightBold">OR / Bank Number :</td>
                                                                    <td style="width: 40%" class="text5">
                                                                        <asp:TextBox ID="txtNumber" runat="server" Width="90%" Text='<%#Bind("number") %>' CssClass="txtbox_Var" Visible='<%# bind("isVisible") %>' OnTextChanged="txtNumber_TextChanged"></asp:TextBox></td>
                                                                    <td style="width: 15%" class="column_RightBold"></td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 15%" class="column_RightBold">Validity Period :</td>
                                                                    <td style="width: 40%" class="text5">
                                                                        <asp:TextBox Style="text-align: right" ID="txtValidityPeriod" runat="server" Width="60px" Text='120' CssClass="txtbox_Var" Visible='<%#Bind("isVisible") %>' OnTextChanged="txtValidityPeriod_TextChanged"></asp:TextBox><asp:Label ID="Label3" runat="server" Text="(Days)" Visible='<%#Bind("isVisible") %>'></asp:Label><cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtValidityPeriod" ValidChars="0123456789"></cc1:FilteredTextBoxExtender>
                                                                    </td>
                                                                    <td style="width: 15%" class="column_RightBold">Status :</td>
                                                                    <td style="width: 30%" class="text5">
                                                                        <asp:Label ID="lblStatus" runat="server" Font-Bold="True" ForeColor="Red" Font-Size="11pt"></asp:Label></td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 15%" class="column_RightBold">Bid Security Amount :</td>
                                                                    <td style="width: 40%" class="text5">
                                                                        <asp:TextBox Style="text-align: right" ID="txtBidSecurityAmount" runat="server" Width="150px" Text='<%#Bind("Bid_security", "{0:N}") %>' CssClass="txtbox_Amt" Visible='<%# bind("isVisible", "{0:N}") %>' ReadOnly="True" OnTextChanged="txtBidSecurityAmount_TextChanged"></asp:TextBox><cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" TargetControlID="txtBidSecurityAmount" ValidChars="0123456789.,"></cc1:FilteredTextBoxExtender>
                                                                    </td>
                                                                    <td style="width: 15%" class="column_RightBold"></td>
                                                                    <td style="width: 30%" class="text5"></td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 15%" class="column_RightBold"></td>
                                                                    <td style="width: 40%" class="text5"></td>
                                                                    <td style="width: 15%" class="column_RightBold"></td>
                                                                    <td style="width: 30%" class="text5"></td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="50%"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="Status" HeaderText="Status" Visible="False">
                                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Width="12%"></ItemStyle>
                                                </asp:BoundField>
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
                            <asp:Button ID="btnsubmit" runat="server" Width="150px" CssClass="CSButton" Enabled="False" OnClientClick="StartProgressBar();" Text="SAVE"></asp:Button>
                            &nbsp;<asp:Button ID="btnReturn" runat="server" Enabled="False" visible="false" OnClientClick="StartProgressBar();" Text="RETURN" Width="150px" CssClass="CSButton" />
                            <cc1:ConfirmButtonExtender ID="btnReturn_ConfirmButtonExtender" runat="server" ConfirmText="Are you sure you want to save  this transaction?" TargetControlID="btnReturn">
                            </cc1:ConfirmButtonExtender>
                            <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" TargetControlID="btnsubmit" ConfirmText="Are you sure you want to save  this transaction?">
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
                <asp:HiddenField ID="hndValue1" runat="server" />
                <asp:HiddenField ID="hndValue2" runat="server" />
            </div>




            <asp:Panel Style="border-top-width: 1px; border-left-width: 1px; border-left-color: #0033cc; border-bottom-width: 1px; border-bottom-color: #0033cc; border-top-color: #0033cc; position: relative; background-color: transparent; text-align: center; border-right-width: 1px; border-right-color: #0033cc" ID="PanelProgress" runat="server" Width="109px">
                <img alt="" src="../images/ajax-loader.gif" />
            </asp:Panel>
            <cc1:ModalPopupExtender ID="ProgressBarModalPopupExtender" runat="server" TargetControlID="ButtonProgress" BehaviorID="ProgressBarModalPopupExtender" BackgroundCssClass="modalBackground" PopupControlID="PanelProgress"></cc1:ModalPopupExtender>
            <asp:Button Style="border-top-style: none; border-right-style: none; border-left-style: none; position: relative; background-color: transparent; border-bottom-style: none" ID="ButtonProgress" runat="server" Width="16px" Enabled="False"></asp:Button>
        

        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
