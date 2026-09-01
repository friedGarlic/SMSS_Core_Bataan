<%@ Page Title="Documents for Auction" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Disposal_ISSP_List.aspx.vb"
    Inherits="Inventory_Disposal_Disposal_ISSP_List" StylesheetTheme="SkinFile" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

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

        function toPeso(objctrl) {
            //Get the Entered Value
            var number = objctrl.value.toString(),
                //Split the number between dollars and cents
                php = number.split('.')[0], cents = (number.split('.')[1] || '') + '00';
            php = php.split('').reverse().join('').replace(/(\d{3}(?!$))/g, '$1,').split('').reverse().join('');
            //Concatenate the number with currecny symbol
            objctrl.value = php + '.' + cents.slice(0, 2);
        }

    </script>


    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>


            <div>
                <table width="100%">
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="PageTitle">Documents for Auction
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="right">
                            <span class="column_RightBold">Date : </span>
                            &nbsp;<asp:TextBox runat="server" ID="txtDate" CssClass="txtbox_Date" Width="10%"></asp:TextBox>
                            <span class="CalendarFormat">(MM/DD/YYYY)</span>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <span class="column_RightBold">ISSP Number : </span>
                            &nbsp;<asp:TextBox runat="server" ID="txtSearch" CssClass="txtbox_Var" Width="20%"></asp:TextBox>
                            &nbsp;<asp:Button runat="server" ID="btnSearch" Width="12%" Text="Search" CssClass="CSButton" OnClientClick="StartProgressBar();" />
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:GridView runat="server" ID="grdISSP" SkinID="GridViewAA" Width="65%" EmptyDataText="No Data Found." AllowPaging="true" PageSize="15"
                                DataKeyNames="IsspHdr_ID,AuctionDate">
                                <Columns>
                                    <asp:TemplateField ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:LinkButton runat="server" ID="lnkSelect" OnClick="lnkSelect_Click" CommandName="Select" Text="Select" CssClass="LinkBtnSelect" Visible='<%# Bind("isVisible") %>' OnClientClick="StartProgressBar();"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:BoundField ItemStyle-Width="18%" ItemStyle-HorizontalAlign="Center" DataField="ISSP_Date" DataFormatString="{0:d}" HeaderText="ISSP Date" />
                                    <asp:BoundField ItemStyle-Width="20%" ItemStyle-HorizontalAlign="Center" DataField="ISSP_No" HeaderText="ISSP No." />
                                    <asp:BoundField ItemStyle-Width="18%" ItemStyle-HorizontalAlign="Right" DataField="MinBid_Amt" DataFormatString="{0:N}" HeaderText="Minimum Bid Amount" />
                                    <asp:BoundField ItemStyle-Width="18%" ItemStyle-HorizontalAlign="Center" DataField="AuctionDate" DataFormatString="{0:d}" HeaderText="Auction Date" />

                                    <asp:TemplateField ItemStyle-Width="16%" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:LinkButton runat="server" ID="lnkClose" OnClick="lnkClose_Click" CommandName="Select" Text="Close Auction" CssClass="LinkBtnCancel" Visible='<%# Bind("isVisible") %>' OnClientClick="StartProgressBar();"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                </Columns>
                            </asp:GridView>
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
                        <td style="width: 98%" class="DivTitle">List of Interested Bidders
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <table width="60%">
                                <tr>
                                    <td style="width: 20%" class="column_RightBold">Bidder's Name :</td>
                                    <td style="width: 80%" class="column_Left">
                                        <asp:DropDownList runat="server" ID="drpSuppliers" CssClass="drpdownCSS" Width="80%">
                                            <asp:ListItem Value="0" Text="Select" Selected="True"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 20%" class="column_RightBold">OP Amount :</td>
                                    <td style="width: 80%" class="column_Left">
                                        <asp:TextBox runat="server" ID="txtOP_Amt" CssClass="txtbox_Amt" Width="20%" Text="0.00" onblur="toPeso(this)"></asp:TextBox>
                                        <cc1:FilteredTextBoxExtender runat="server" ID="FilteredTextBoxExtender1" TargetControlID="txtOP_Amt" ValidChars="0123456789.,"></cc1:FilteredTextBoxExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 20%" class="column_RightBold"></td>
                                    <td style="width: 80%; height: 10px" class="column_Left"></td>
                                </tr>
                                <tr>
                                    <td style="width: 100%" colspan="2" align="center">
                                        <asp:Button runat="server" ID="btnAddBidder" Text="Add" Width="20%" Enabled="false" CssClass="CSButton" OnClientClick="StartProgressBar();" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 20%" class="column_RightBold"></td>
                                    <td style="width: 80%" class="column_Left"></td>
                                </tr>
                            </table>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:GridView runat="server" ID="grdBidders" SkinID="GridViewAA" Width="90%" EmptyDataText="No Data Found." AllowPaging="false"
                                DataKeyNames="SuppName,op1_Amt">
                                <Columns>
                                     <asp:BoundField ItemStyle-Width="5%" ItemStyle-HorizontalAlign="Center" DataField="ID" HeaderText="No." />

                                    <asp:TemplateField ItemStyle-Width="15%" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:LinkButton runat="server" ID="lnkSelect" CommandName="Select" Text="Order of Payment" CssClass="LinkBtnSelect" Visible='<%# Bind("isVisible") %>' OnClientClick="StartProgressBar();"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:BoundField ItemStyle-Width="40%" ItemStyle-HorizontalAlign="Left" DataField="SuppName" HeaderText="Bidder's Name" />
                                    <asp:BoundField ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Right" DataField="op1_Amt" DataFormatString="{0:N}" HeaderText="OP Amount" />
           
                                    <asp:TemplateField ItemStyle-Width="7%" ItemStyle-HorizontalAlign="Center" HeaderText="Is Paid?">
                                        <ItemTemplate>
                                            <asp:CheckBox runat="server" ID="cbPaid" CssClass="rbCS_Horizontal" Text=""  Checked='<%# Bind("isPaid") %>' Visible='<%# Bind("isVisible") %>'/>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField ItemStyle-Width="7%" ItemStyle-HorizontalAlign="Center" HeaderText="Attended?">
                                        <ItemTemplate>
                                            <asp:CheckBox runat="server" ID="cbAttend" CssClass="rbCS_Horizontal" Text=""  Checked='<%# Bind("isAttend") %>' Visible='<%# Bind("isVisible") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField ItemStyle-Width="16%" ItemStyle-HorizontalAlign="Center" HeaderText="OR Number">
                                        <ItemTemplate>
                                            <asp:TextBox runat="server" ID="txtOR" CssClass="txtbox_Middle" Width="95%" Text='<%# Bind("OR_No") %>' Visible='<%# Bind("isVisible") %>'></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                      <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:Button runat="server" ID="btnUpdateBidders" CssClass="CSButton" Width="12%" Text="Update" OnClientClick="StartProgressBar();" Enabled="false"/>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%; height: 15px"></td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:Button runat="server" ID="btnPreview_InterestedBidder" CssClass="CSButton" Width="20%" Enabled="false" Text="List of Interested Bidder" OnClientClick="StartProgressBar();" />
                            &nbsp;<asp:Button runat="server" ID="btnPreview_Abstract" CssClass="CSButton" Width="20%" Enabled="false" Text="Abstract of Proposal" OnClientClick="StartProgressBar();" />
                            &nbsp;<asp:Button runat="server" ID="btnNotice_COA" CssClass="CSButton" Width="15%" Enabled="false" Text="Notice to COA" OnClientClick="StartProgressBar();" />
                            &nbsp;<asp:Button runat="server" ID="btnNotice_Conspicuous" CssClass="CSButton" Width="20%" Enabled="false" Text="Notice to Conspicuous" OnClientClick="StartProgressBar();" />
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center"></td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%; height: 23px;"></td>
                        <td style="width: 98%; height: 23px;"></td>
                        <td style="width: 1%; height: 23px;"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%; height: 30px"></td>
                        <td style="width: 1%"></td>
                    </tr>
                </table>
            </div>


            <asp:Panel runat="server" ID="pnlNoticeCOA" CssClass="Panel_Popup">
                <div>
                    <table width="350px">
                        <tr>
                            <td style="width: 100%; height: 30px" class="DivTitle">Notice to COA
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 100%; height: 5px" align="center"></td>
                        </tr>
                        <tr>
                            <td style="width: 100%" align="center">
                                <span class="column_RightBold">Notice Date :</span>
                                &nbsp;<asp:TextBox runat="server" ID="txtCOA_Date" CssClass="txtbox_Date" Width="40%" Text="" MaxLength="10"></asp:TextBox>
                                <span class="CalendarFormat">(MM/DD/YYYY)</span>
                                <cc1:CalendarExtender runat="server" ID="CalendarExtender1" TargetControlID="txtCOA_Date" PopupButtonID="txtCOA_Date" PopupPosition="TopLeft"></cc1:CalendarExtender>
                                <cc1:FilteredTextBoxExtender runat="server" ID="FilteredTextBoxExtender2" TargetControlID="txtCOA_Date" ValidChars="1234567890/"></cc1:FilteredTextBoxExtender>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 100%; height: 5px" align="center"></td>
                        </tr>
                        <tr>
                            <td style="width: 100%" align="center">
                                <asp:Button runat="server" ID="btnPreviewCOA" CssClass="CSButton" Text="Preview" Width="25%" OnClientClick="StartProgressBar();" />
                                &nbsp;<asp:Button runat="server" ID="btnCancelCOA" CssClass="CSButton" Text="Cancel" Width="25%" OnClientClick="StartProgressBar();" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 100%; height: 10px" align="center">
                                <asp:Label runat="server" ID="lblNoticeCOA"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </div>
            </asp:Panel>
            <cc1:ModalPopupExtender runat="server" ID="ModalPopupExtender1" TargetControlID="lblNoticeCOA" PopupControlID="pnlNoticeCOA" BackgroundCssClass="modalBackground"></cc1:ModalPopupExtender>


            <asp:Panel Style="border-top-width: 1px; border-left-width: 1px; border-left-color: #0033cc; border-bottom-width: 1px; border-bottom-color: #0033cc; border-top-color: #0033cc; background-color: transparent; text-align: center; border-right-width: 1px; border-right-color: #0033cc" ID="PanelProgress" runat="server" Width="109px">
                <img alt="" src="../../images/ajax-loader.gif" />
            </asp:Panel>
            <cc1:ModalPopupExtender ID="ProgressBarModalPopupExtender" runat="server" BackgroundCssClass="modalBackground" TargetControlID="ButtonProgress" PopupControlID="PanelProgress" BehaviorID="ProgressBarModalPopupExtender"></cc1:ModalPopupExtender>
            <asp:Button Style="border-top-style: none; border-right-style: none; border-left-style: none; background-color: transparent; border-bottom-style: none" ID="ButtonProgress" runat="server" Width="16px" Enabled="False"></asp:Button>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>

