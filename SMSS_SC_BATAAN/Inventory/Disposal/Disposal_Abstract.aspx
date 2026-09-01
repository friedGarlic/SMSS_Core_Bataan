<%@ Page Title="Disposal - Abstract" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Disposal_Abstract.aspx.vb"
    Inherits="Inventory_Disposal_Disposal_Abstract" StylesheetTheme="SkinFile" %>

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
                //Split the number between WholeNumber and Decimals
                php = number.split('.')[0], cents = (number.split('.')[1] || '') + '00';
            php = php.split('').reverse().join('').replace(/(\d{3}(?!$))/g, '$1,').split('').reverse().join('');
            //Concatenate the number 
            objctrl.value = php + '.' + cents.slice(0, 2);
        }

    </script>

    <script type="text/javascript">
        // It is important to place this JavaScript code after ScriptManager1
        var xPos, yPos;
        var prm = Sys.WebForms.PageRequestManager.getInstance();

        function BeginRequestHandler(sender, args) {
            if ($get('<%=Panel1.ClientID%>') != null) {
                // Get X and Y positions of scrollbar before the partial postback
                xPos = $get('<%=Panel1.ClientID%>').scrollLeft;
                yPos = $get('<%=Panel1.ClientID%>').scrollTop;
            }
        }


        function EndRequestHandler(sender, args) {
            if ($get('<%=Panel1.ClientID%>') != null) {
                // Set X and Y positions back to the scrollbar
                // after partial postback
                $get('<%=Panel1.ClientID%>').scrollLeft = xPos;
                $get('<%=Panel1.ClientID%>').scrollTop = yPos;
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
                        <td style="width: 98%" class="PageTitle">ABSTRACT OF AUCTION</td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center"></td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%; height: 10px"></td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="DivTitle">List of ISSP
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:GridView runat="server" ID="grdAbstract" SkinID="GridViewAA" Width="80%" EmptyDataText="No Data Found." AllowPaging="true" PageSize="12"
                                DataKeyNames="IsspHdr_ID,Issp_No">
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton runat="server" ID="lnkSelect" Text="Select" CssClass="LinkBtnSelect" Visible='<%#Bind("isVisible") %>' CommandName="Select" OnClientClick="StartProgressBar();"></asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                    </asp:TemplateField>
                                    <asp:BoundField ItemStyle-Width="15%" ItemStyle-HorizontalAlign="Center" DataField="BidType" HeaderText="Bid Type" />
                                    <asp:BoundField ItemStyle-Width="20%" ItemStyle-HorizontalAlign="Center" DataField="Issp_Date" DataFormatString="{0:d}" HeaderText="ISSP Date" />
                                    <asp:BoundField ItemStyle-Width="30%" ItemStyle-HorizontalAlign="Center" DataField="Issp_No" HeaderText="ISSP Number" />
                                    <asp:BoundField ItemStyle-Width="25%" ItemStyle-HorizontalAlign="Right" DataField="MinBid_Amt" DataFormatString="{0:N}" HeaderText="Min. Bid Amount" />
                                </Columns>
                            </asp:GridView>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%; height: 10px">
                             <table width="100%">
                                <tr>
                                    <td style="width: 20%" class="column_RightBold">Date :</td>
                                    <td style="width: 35%" class="column_Left">
                                        <asp:TextBox runat="server" ID="txtDate" CssClass="txtbox_Date" Width="20%" MaxLength="10" style="margin-left: 0px"></asp:TextBox>
                                        &nbsp;<span class="CalendarFormat">(MM/DD/YYYY)</span>
                                        <cc1:CalendarExtender runat="server" ID="CalendarExtender" TargetControlID="txtDate" PopupButtonID="txtDate" PopupPosition="TopLeft"></cc1:CalendarExtender>
                                        <cc1:FilteredTextBoxExtender runat="server" ID="FilteredTextBoxExtender" TargetControlID="txtDate" ValidChars="1234567890/"></cc1:FilteredTextBoxExtender>
                                    </td>
                                    <td style="width: 12%" class="column_RightBold">Total Bid Amount :</td>
                                    <td class="column_Left" style="width: 228px">
                                        <asp:TextBox ID="txtTotalBidAmt" runat="server" CssClass="txtbox_Amt" ReadOnly="true" Text="0.00" Width="50%"></asp:TextBox>
                                    </td>
                                </tr>

                                <tr>
                                    <td style="width: 20%" class="column_RightBold">Mode of Disposal :</td>
                                    <td style="width: 35%" class="column_Left">
                                        <asp:TextBox runat="server" ID="txtMode" CssClass="txtbox_Var" Width="30%" ReadOnly="true"></asp:TextBox>
                                    </td>
                                      <td style="width: 12%" class="column_RightBold">Bid Bond :</td>
                                    <td class="column_Left" style="width: 228px">
                                        <asp:TextBox ID="txtBidBond" runat="server" CssClass="txtbox_Var" ReadOnly="true" Text="" Width="50%"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 20%" class="column_RightBold">ISSP Number :</td>
                                    <td style="width: 35%" class="column_Left">
                                        <asp:TextBox runat="server" ID="txtISSPNo" CssClass="txtbox_Var" Width="30%" ReadOnly="true"></asp:TextBox>
                                    </td>
                                      <td style="width: 12%" class="column_RightBold">Bid Bond Amount :</td>
                                    <td class="column_Left" style="width: 228px">
                                       <asp:TextBox ID="txtBidBondAmt" runat="server" CssClass="txtbox_Amt" onblur="toPeso(this)" Text="0.00" Width="50%" AutoPostBack="true" OnTextChanged="txtBidBondAmt_TextChanged"></asp:TextBox>
                                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtBidBondAmt" ValidChars="1234567890.,">
                                        </cc1:FilteredTextBoxExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 20%; height: 21px;" class="column_RightBold">Bidder Name :</td>
                                    <td style="width: 35%; height: 21px;" class="column_Left">
                                        <asp:DropDownList runat="server" ID="drpBidder" CssClass="drpdownCSS" Width="90%" AutoPostBack="true"></asp:DropDownList>
                                    </td>
                                </tr>
                                 <tr>
                                    <td style="width: 20%" class="column_RightBold">&nbsp;</td>
                                    <td colspan="3" class="column_Left">
                                        <asp:Label ID="lblBidderBondNote" runat="server" 
                                            CssClass="column_LeftBold" 
                                            Visible="false">
                                        </asp:Label>
                                    </td>
                                </tr>

                                <tr>
                                    <td style="width: 20%" class="column_RightBold">&nbsp;</td>
                                    <td style="width: 35%" class="column_Left">
                                        &nbsp;</td>
                                      <td class="column_RightBold" style="width: 12%"></td>
                                    <td class="column_Left" style="width: 228px"></td>
                                </tr>
                                <tr>
                                    <td style="width: 20%" class="column_RightBold">&nbsp;</td>
                                    <td style="width: 35%" class="column_Left">
                                        &nbsp;</td>
                                      <td class="column_RightBold" style="width: 12%"></td>
                                    <td class="column_Left" style="width: 228px"></td>
                                </tr>
                                <tr>
                                    <td style="width: 20%" class="column_RightBold">&nbsp;</td>
                                    <td style="width: 35%" class="column_Left">
                                        &nbsp;</td>
                                      <td class="column_RightBold" style="width: 12%"></td>
                                    <td class="column_Left" style="width: 228px"></td>
                                </tr>
                            </table>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="DivTitle">List of Items
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                                    <asp:Panel ID="Panel1" runat="server" Width="98%" CssClass="PanelSize" ScrollBars="Vertical">

                                        <asp:GridView runat="server" ID="grdItems" SkinID="GridViewAA" Width="100%" EmptyDataText="No Data Found." AllowPaging="true" PageSize="12"
                                            DataKeyNames="IIRUP_No">
                                            <Columns>
                                                <asp:BoundField ItemStyle-Width="13%" ItemStyle-HorizontalAlign="Center" DataField="IIRUP_No" HeaderText="IIRUP Number" />
                                                <asp:BoundField ItemStyle-Width="15%" ItemStyle-HorizontalAlign="Center" DataField="PropertyNo" HeaderText="Property Number" />
                                                <asp:BoundField ItemStyle-Width="50%" ItemStyle-HorizontalAlign="Left" DataField="Item_Desc" HeaderText="Description" HtmlEncode="false" />
                                                <asp:BoundField ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center" DataField="UnitDesc" HeaderText="Unit" />
                                                <asp:BoundField ItemStyle-Width="12%" ItemStyle-HorizontalAlign="Right" DataField="AppraisedVal" HeaderText="Appraised Value" DataFormatString="{0:N}" />                                                
                                            </Columns>
                                        </asp:GridView>

                                    </asp:Panel>
                                </ContentTemplate>
                            </asp:UpdatePanel>
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
                        <td style="width: 98%" align="center">
                            <table width="90%">
                                <tr>
                                    <td style="width: 15%" class="column_RightBold">BAC Member :</td>
                                    <td style="width: 35%" class="column_Left">
                                        <asp:DropDownList runat="server" ID="drpMember1" CssClass="drpdownCSS" Width="90%"></asp:DropDownList>
                                    </td>
                                    <td style="width: 15%" class="column_RightBold">BAC Member :</td>
                                    <td style="width: 35%" class="column_Left">
                                        <asp:DropDownList runat="server" ID="drpMember2" CssClass="drpdownCSS" Width="90%"></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 15%" class="column_RightBold">BAC Member :</td>
                                    <td style="width: 35%" class="column_Left">
                                        <asp:DropDownList runat="server" ID="drpMember3" CssClass="drpdownCSS" Width="90%"></asp:DropDownList>
                                    </td>
                                    <td style="width: 15%" class="column_RightBold">BAC Member :</td>
                                    <td style="width: 35%" class="column_Left">
                                        <asp:DropDownList runat="server" ID="drpMember4" CssClass="drpdownCSS" Width="90%"></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 15%" class="column_RightBold">BAC Member :</td>
                                    <td style="width: 35%" class="column_Left">
                                        <asp:DropDownList runat="server" ID="drpMember5" CssClass="drpdownCSS" Width="90%"></asp:DropDownList>
                                    </td>
                                    <td style="width: 15%" class="column_RightBold">Chairmain :</td>
                                    <td style="width: 35%" class="column_Left">
                                        <asp:DropDownList runat="server" ID="drpChairman" CssClass="drpdownCSS" Width="90%"></asp:DropDownList>
                                    </td>
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
                        <td style="width: 98%" align="center">
                            <asp:Button runat="server" ID="btnSave" CssClass="CSButton" Width="15%" Text="Declare Winner" OnClientClick="StartProgressBar();" Enabled="false" />
                            &nbsp;<asp:Button runat="server" ID="btnPreview" CssClass="CSButton" Width="15%" Text="Preview Abstract" OnClientClick="StartProgressBar();" Enabled="false" />
                            &nbsp;<asp:Button runat="server" ID="btnPreview_OP" CssClass="CSButton" Width="15%" Text="Order of Payment" OnClientClick="StartProgressBar();" Enabled="false" />
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



            <asp:Panel Style="border-top-width: 1px; border-left-width: 1px; border-left-color: #0033cc; border-bottom-width: 1px; border-bottom-color: #0033cc; border-top-color: #0033cc; background-color: transparent; text-align: center; border-right-width: 1px; border-right-color: #0033cc" ID="PanelProgress" runat="server" Width="109px" __designer:wfdid="w1">
                <img alt="" src="../../images/ajax-loader.gif" />
            </asp:Panel>
            <cc1:ModalPopupExtender ID="ProgressBarModalPopupExtender" runat="server" __designer:wfdid="w2" PopupControlID="PanelProgress" BackgroundCssClass="modalBackground" BehaviorID="ProgressBarModalPopupExtender" TargetControlID="ButtonProgress"></cc1:ModalPopupExtender>
            <asp:Button Style="border-top-style: none; border-right-style: none; border-left-style: none; background-color: transparent; border-bottom-style: none" ID="ButtonProgress" runat="server" Width="16px" __designer:wfdid="w3" Enabled="False"></asp:Button>&nbsp; 
        


        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

