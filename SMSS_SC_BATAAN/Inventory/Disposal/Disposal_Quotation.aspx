<%@ Page Title="Disposal - Quotation" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Disposal_Quotation.aspx.vb"
    Inherits="Inventory_Disposal_Disposal_Quotation" StylesheetTheme="SkinFile" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <script type="text/javascript"> 
        function stopRKey(evt) {
            var evt = (evt) ? evt : ((event) ? event : null);
            var node = (evt.target) ? evt.target : ((evt.srcElement) ? evt.srcElement : null);
            if ((evt.keyCode == 13) && (node.type == "text")) {
                return false; drpBidType
            }
        }
        document.onkeypress = stopRKey;
        

        function bidbond() {
            alert('HELLOW');
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
                        <td style="width: 98%" class="PageTitle">QUOTATION - AUCTION</td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="right">
                            <span class="column_RightBold">Date :</span>
                            &nbsp;<asp:TextBox runat="server" ID="txtDate" CssClass="txtbox_Date" Width="12%" ReadOnly="true"></asp:TextBox>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <span class="column_RightBold">ISSP Number :</span>
                            &nbsp;<asp:TextBox runat="server" ID="txtSearch" CssClass="txtbox_Var" Width="30%"></asp:TextBox>
                            &nbsp;<asp:Button runat="server" ID="btnSearch" CssClass="CSButton" Text="Search" Width="12%" OnClientClick="StartProgressBar();" />
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:GridView runat="server" ID="grdQuotation" SkinID="GridViewAA" Width="80%" EmptyDataText="No Data Found." AllowPaging="true" PageSize="12"
                                DataKeyNames="IsspHdr_ID,BidType,MinBid_Amt">
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton runat="server" ID="lnkSelect" Text="Select" CssClass="LinkBtnSelect" Font-Underline="false" Visible='<%#Bind("isVisible") %>' CommandName="Select" OnClientClick="StartProgressBar();"></asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                    </asp:TemplateField>
                                    <asp:BoundField ItemStyle-Width="20%" ItemStyle-HorizontalAlign="Center" DataField="Issp_Date" DataFormatString="{0:d}" HeaderText="ISSP Date" />
                                    <asp:BoundField ItemStyle-Width="35%" ItemStyle-HorizontalAlign="Center" DataField="Issp_No" HeaderText="ISSP Number" />
                                    <asp:BoundField ItemStyle-Width="35%" ItemStyle-HorizontalAlign="Right" DataField="MinBid_Amt" DataFormatString="{0:N}" HeaderText="Min. Bid Amount" />
                                    <%--  <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton runat="server" ID="lnkClose" Text="Close" CssClass="LinkBtnSelect" Font-Underline="false" Visible='<%#Bind("isVisible") %>' CommandName="Select" OnClientClick="StartProgressBar();"></asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                    </asp:TemplateField>--%>
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
                                            DataKeyNames="IIRUPHdr_ID,Item_ID,PropertyNo">
                                            <Columns>
                                                <asp:BoundField ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center" DataField="IIRUP_No" HeaderText="IIRUP Number" />
                                                <asp:BoundField ItemStyle-Width="15%" ItemStyle-HorizontalAlign="Center" DataField="PropertyNo" HeaderText="Property Number" />
                                                <asp:BoundField ItemStyle-Width="55%" ItemStyle-HorizontalAlign="Left" DataField="Item_Desc" HeaderText="Description" HtmlEncode="false" />
                                                <asp:BoundField ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center" DataField="UnitDesc" HeaderText="Unit" />
                                                <asp:BoundField ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Right" DataField="AppraisedVal" HeaderText="Appraised Value" DataFormatString="{0:N}" />
                                               
                                                <asp:TemplateField HeaderText="Bid Amount" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:TextBox runat="server" ID="txtBidAmount" CssClass="txtbox_Amt" Width="95%" Text="0.00" Visible='<%#Bind("isVisible") %>' OnTextChanged="txtBidAmount_TextChanged" AutoPostBack="true" Enabled="false"></asp:TextBox>
                                                        <cc1:FilteredTextBoxExtender runat="server" ID="FilteredTextBoxExtender1" TargetControlID="txtBidAmount" ValidChars="1234567890.,"></cc1:FilteredTextBoxExtender>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" Width="10%" />
                                                </asp:TemplateField>
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
                        <td style="width: 98%" align="center">
                            <span class="column_RightBold">Bid Type :</span>
                            &nbsp;<asp:DropDownList runat="server" ID="drpBidType" CssClass="drpdownCSS" Width="15%" Enabled="false">
                                <%-- <asp:ListItem Value="1" Text="Per Item"></asp:ListItem>--%>
                                <asp:ListItem Selected="True" Value="2" Text="Per Lot"></asp:ListItem>
                            </asp:DropDownList>
                            &nbsp;<asp:Button runat="server" Visible="false" ID="btnOK" Text="Set" CssClass="CSButton" Width="12%" OnClientClick="StartProgressBar();" Enabled="false" />

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
                        <td style="width: 98%" class="DivTitle">List of Bidders
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:GridView runat="server" ID="grdBidders" SkinID="GridViewAA" Width="80%" EmptyDataText="No Data Found." AllowPaging="false"
                                DataKeyNames="">
                                <Columns>
                                    <asp:BoundField ItemStyle-Width="5%" ItemStyle-HorizontalAlign="Center" DataField="ID" HeaderText="No." />
                                    <asp:BoundField ItemStyle-Width="75%" ItemStyle-HorizontalAlign="Left" DataField="SuppName" HeaderText="Bidder Name" />
                                    <asp:BoundField ItemStyle-Width="20%" ItemStyle-HorizontalAlign="Right" DataField="TotalBidAmt" HeaderText="Bid Amount" DataFormatString="{0:N}" />

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
                        <td style="width: 98%" align="center">

                            <table width="90%">
                                <tr>
                                    <td style="width: 15%" class="column_RightBold">Bidder Name :</td>
                                    <td style="width: 35%" class="column_Left">
                                        <asp:DropDownList runat="server" ID="drpBidder" CssClass="drpdownCSS" Width="87%" Enabled="false" AutoPostBack="true"></asp:DropDownList>
                                        &nbsp;<asp:Button ID="btnAddBid" OnClick="btnAddBid_Click" Enabled="true" Visible="false" runat="server" Width="30px" CssClass="CSButton" Text="+" OnClientClick="StartProgressBar();"></asp:Button>
                                    </td>
                                    <td style="width: 15%" class="column_RightBold">Total Bid Amount :</td>
                                    <td style="width: 35%" class="column_Left">
                                        <asp:TextBox runat="server" ID="txtTotalBidAmount" CssClass="txtbox_Amt" Width="40%" Text="0.00" Enabled="false" AutoPostBack="true"></asp:TextBox>
                                        <cc1:FilteredTextBoxExtender runat="server" ID="FilteredTextBoxExtender1" TargetControlID="txtTotalBidAmount" ValidChars="1234567890.,"></cc1:FilteredTextBoxExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 15%" class="column_RightBold">Bid Bond :</td>
                                    <td style="width: 35%" class="column_Left">
                                        <asp:DropDownList runat="server" ID="drpBidBond" CssClass="drpdownCSS" Width="40%" Enabled="false" AutoPostBack="true">
                                            <asp:ListItem Value="1" Text="Cash" Selected="True"></asp:ListItem>
                                            <asp:ListItem Value="2" Text="Manager’s check"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td style="width: 15%" class="column_RightBold">Bid Bond Amount :</td>
                                    <td style="width: 35%" class="column_Left">
                                        <asp:TextBox runat="server" ID="txtBidBondAmt" OnTextChanged="txtBidBondAmt_TextChanged" AutoPostBack="true" CssClass="txtbox_Amt" Width="40%" Text="0.00"></asp:TextBox>
                                        <cc1:FilteredTextBoxExtender  runat="server" ID="FilteredTextBoxExtender2"  TargetControlID="txtBidBondAmt" ValidChars="1234567890.,"></cc1:FilteredTextBoxExtender>
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
                            <asp:Button runat="server" ID="btnSave" CssClass="CSButton" Width="12%" Text="Save" OnClientClick="StartProgressBar();" Enabled="false" />
                            &nbsp;<asp:Button runat="server" ID="btnClose" CssClass="CSButton" Width="12%" Text="Done" OnClientClick="StartProgressBar();" Enabled="false" />
                            &nbsp;<asp:Button ID="btnpreviewBid" Enabled="false" runat="server" Visible="false" OnClick="btnpreviewBid_Click" Width="150px" CssClass="CSButton" Text="PREVIEW" OnClientClick="StartProgressBar();"></asp:Button>
                            &nbsp;<asp:Button ID="btnGenOP" OnClick="btnGenOP_Click" Enabled="false" Visible="false" runat="server" Width="15%" CssClass="CSButton" Text="Order of Payment" OnClientClick="StartProgressBar();"></asp:Button>
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




            <asp:Panel Style="border-top-width: 1px; border-left-width: 1px; border-left-color: #0033cc; border-bottom-width: 1px; border-bottom-color: #0033cc; border-top-color: #0033cc; background-color: transparent; text-align: center; border-right-width: 1px; border-right-color: #0033cc" ID="PanelProgress" runat="server" Width="109px">
                <img alt="" src="../../images/ajax-loader.gif" />
            </asp:Panel>
            <cc1:ModalPopupExtender ID="ProgressBarModalPopupExtender" runat="server" PopupControlID="PanelProgress" BackgroundCssClass="modalBackground" BehaviorID="ProgressBarModalPopupExtender" TargetControlID="ButtonProgress"></cc1:ModalPopupExtender>
            <asp:Button Style="border-top-style: none; border-right-style: none; border-left-style: none; background-color: transparent; border-bottom-style: none" ID="ButtonProgress" runat="server" Width="16px" Enabled="False"></asp:Button>&nbsp; 
        


            <asp:Panel ID="popupBidrpt" runat="server" Width="400px" CssClass="Panel_Popup" HorizontalAlign="Center">
                <table width="98%">
                    <tr>
                        <td style="width: 100%; height: 10px" colspan="2" align="center"></td>
                    </tr>
                    <tr>
                        <td style="width: 40%" class="column_RightBold">Number of Copies :</td>
                        <td style="width: 60%" class="column_Left">
                            <asp:TextBox ID="txtNumCopies" runat="server" Width="30%" CssClass="txtbox_Qty" Text="1"></asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" TargetControlID="txtNumCopies" ValidChars="0123456789,"></cc1:FilteredTextBoxExtender>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 40%" class="column_RightBold">Price Per Copy :</td>
                        <td style="width: 60%" class="column_Left">
                            <asp:TextBox ID="txtCostPerCop" runat="server" Width="40%" CssClass="txtbox_Amt" Text="0.00"></asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" TargetControlID="txtCostPerCop" ValidChars="0123456789.,"></cc1:FilteredTextBoxExtender>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100%; height: 5px" colspan="2" align="center"></td>
                    </tr>
                    <tr>
                        <td style="width: 100%" colspan="2" align="center">
                            <asp:Button ID="btnPrint" runat="server" Width="40%" CssClass="CSButton" Text="PRINT" OnClientClick="StartProgressBar();"></asp:Button>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100%; height: 10px" colspan="2" align="center">
                            <asp:Label ID="lblBidders" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>

            </asp:Panel>
            <cc1:ModalPopupExtender ID="ModalPopupExtender99" runat="server" BackgroundCssClass="modalBackground" PopupControlID="popupBidrpt" TargetControlID="lblBidders"></cc1:ModalPopupExtender>



            <%-- LIST OF SUPPLIERS --%>
            <asp:Panel ID="popup" runat="server" Width="900px" CssClass="Panel_Popup">
                <table width="100%" cellpadding="0px" cellspacing="0px">
                    <tr>
                        <td style="width: 100%; height: 30px" colspan="3" class="DivTitle">SUPPLIERS / BIDDERS
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="right">
                            <span class="column_RightBold">Date :</span>
                            <asp:TextBox runat="server" ID="txtDateBid" CssClass="txtbox_Date" Width="100px" ReadOnly="true"></asp:TextBox>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <table width="100%">
                                <tr>
                                    <td style="width: 50%" align="center">
                                        <table style="width: 100%">
                                            <tr>
                                                <td style="width: 100%" colspan="2" class="DivTitle">Company Profile
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 25%" class="column_RightBold">Company Name : </td>
                                                <td style="width: 75%" class="column_Left">
                                                    <asp:TextBox ID="txtcompany" runat="server" Width="90%" Enabled="false" CssClass="txtbox_Var"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 25%" class="column_RightBold">Address : </td>
                                                <td style="width: 75%" class="column_Left">
                                                    <asp:TextBox ID="txtadd1" runat="server" Width="90%" Enabled="false" CssClass="txtbox_Var"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 25%" class="column_RightBold">Contact No. : </td>
                                                <td style="width: 75%" class="column_Left">
                                                    <asp:TextBox ID="txtofficeno" runat="server" Width="90%" Enabled="false" CssClass="txtbox_Var"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 25%" class="column_RightBold">Fax Number : </td>
                                                <td style="width: 75%" class="column_Left">
                                                    <asp:TextBox ID="txtfaxno" runat="server" Width="90%" Enabled="false" CssClass="txtbox_Var"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 25%" class="column_RightBold">Tax Type : </td>
                                                <td style="width: 75%" class="column_Left">
                                                    <asp:DropDownList ID="ddtax" runat="server" Width="30%" CssClass="drpdownCSS" Enabled="false">
                                                        <asp:ListItem Value="0" Text=""></asp:ListItem>
                                                        <asp:ListItem Value="1" Text="VAT" Selected="True"></asp:ListItem>
                                                        <asp:ListItem Value="2" Text="None VAT"></asp:ListItem>
                                                    </asp:DropDownList></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 25%" class="column_RightBold">T.I.N. : </td>
                                                <td style="width: 75%" class="column_Left">
                                                    <asp:TextBox ID="txttin" runat="server" Width="90%" CssClass="txtbox_Var" Enabled="false"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 25%" class="column_RightBold">Product & Services : </td>
                                                <td style="width: 75%" class="column_Left">
                                                    <asp:TextBox ID="txtPS" runat="server" Width="90%" CssClass="txtbox_Remarks" TextMode="MultiLine" Enabled="false"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 25%" class="column_RightBold">Ownership Type : </td>
                                                <td style="width: 75%" class="column_Left">
                                                    <asp:DropDownList ID="drpOwnershipType" runat="server" Width="50%" CssClass="drpdownCSS" Enabled="false">
                                                        <asp:ListItem Value="0" Text="" Selected="True"></asp:ListItem>
                                                        <asp:ListItem Value="1" Text="Cooperative"></asp:ListItem>
                                                        <asp:ListItem Value="2" Text="Corporation"></asp:ListItem>
                                                        <asp:ListItem Value="3" Text="Partnership"></asp:ListItem>
                                                        <asp:ListItem Value="4" Text="Single Proprietorship"></asp:ListItem>
                                                    </asp:DropDownList></td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td style="width: 50%" align="center" valign="top" rowspan="2">

                                        <table style="width: 100%">
                                            <tr>
                                                <td style="width: 100%" colspan="2" class="DivTitle">Owner's / Representative Profile</td>
                                            </tr>
                                            <tr>
                                                <td style="width: 25%" class="column_RightBold">Representative 1 : </td>
                                                <td style="width: 75%" class="column_Left">
                                                    <asp:TextBox runat="server" ID="txtRep1_Name" CssClass="txtbox_Var" Width="80%" Text="" Enabled="false"></asp:TextBox>

                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 25%" class="column_RightBold">Position : </td>
                                                <td style="width: 75%" class="column_Left">
                                                    <asp:TextBox runat="server" ID="txtRep1_Position" CssClass="txtbox_Var" Width="80%" Text="" Enabled="false"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 25%" class="column_RightBold">Address : </td>
                                                <td style="width: 75%" class="column_Left">
                                                    <asp:TextBox runat="server" ID="txtRep1_Address" CssClass="txtbox_Var" Width="80%" Text="" Enabled="false"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 25%" class="column_RightBold">Contact No. :</td>
                                                <td style="width: 75%" class="column_Left">
                                                    <asp:TextBox runat="server" ID="txtRep1_Contact" CssClass="txtbox_Var" Width="60%" Text="" Enabled="false"></asp:TextBox>
                                                </td>
                                            </tr>

                                            <tr>
                                                <td style="width: 100%; height: 10px" colspan="2"></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 25%" class="column_RightBold">Representative 2 : </td>
                                                <td style="width: 75%" class="column_Left">
                                                    <asp:TextBox runat="server" ID="txtRep2_Name" CssClass="txtbox_Var" Width="80%" Text="" Enabled="false"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 25%" class="column_RightBold">Position : </td>
                                                <td style="width: 75%" class="column_Left">
                                                    <asp:TextBox runat="server" ID="txtRep2_Position" CssClass="txtbox_Var" Width="80%" Text="" Enabled="false"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 25%" class="column_RightBold">Address : </td>
                                                <td style="width: 75%" class="column_Left">
                                                    <asp:TextBox runat="server" ID="txtRep2_Address" CssClass="txtbox_Var" Width="80%" Text="" Enabled="false"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 25%" class="column_RightBold">Contact No. :</td>
                                                <td style="width: 75%" class="column_Left">
                                                    <asp:TextBox runat="server" ID="txtRep2_Contact" CssClass="txtbox_Var" Width="60%" Text="" Enabled="false"></asp:TextBox>
                                                </td>
                                            </tr>

                                            <tr>
                                                <td style="width: 100%; height: 10px" colspan="2"></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 25%" class="column_RightBold">Representative 3 : </td>
                                                <td style="width: 75%" class="column_Left">
                                                    <asp:TextBox runat="server" ID="txtRep3_Name" CssClass="txtbox_Var" Width="80%" Text="" Enabled="false"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 25%" class="column_RightBold">Position : </td>
                                                <td style="width: 75%" class="column_Left">
                                                    <asp:TextBox runat="server" ID="txtRep3_Position" CssClass="txtbox_Var" Width="80%" Text="" Enabled="false"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 25%" class="column_RightBold">Address : </td>
                                                <td style="width: 75%" class="column_Left">
                                                    <asp:TextBox runat="server" ID="txtRep3_Address" CssClass="txtbox_Var" Width="80%" Text="" Enabled="false"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 25%" class="column_RightBold">Contact No. :</td>
                                                <td style="width: 75%" class="column_Left">
                                                    <asp:TextBox runat="server" ID="txtRep3_Contact" CssClass="txtbox_Var" Width="60%" Text="" Enabled="false"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 50%" align="center">
                                        <table width="100%">
                                            <tr>
                                                <td style="width: 100%" colspan="2" class="DivTitle">Accreditation</td>
                                            </tr>
                                            <tr>
                                                <td style="width: 25%" class="column_RightBold">Supplier No. :</td>
                                                <td style="width: 75%" class="column_Left">
                                                    <asp:TextBox ID="txtSupplierNo" runat="server" Width="90%" Enabled="false" CssClass="txtbox_Var"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 25%" class="column_RightBold">No. of Year/s :</td>
                                                <td style="width: 75%" class="column_Left">
                                                    <asp:TextBox ID="txtYearNo" runat="server" Width="90%" Enabled="false" CssClass="txtbox_Var"></asp:TextBox></td>
                                            </tr>

                                            <tr>
                                                <td style="width: 25%" class="column_RightBold">MOA : 
                                                </td>
                                                <td style="width: 75%" class="column_Left">
                                                    <asp:TextBox runat="server" ID="txtMOA" CssClass="txtbox_Var" Width="40%" Enabled="false"></asp:TextBox>
                                                    &nbsp;<span class="column_RightBold">Expiry:</span>
                                                    &nbsp;<asp:TextBox runat="server" ID="txtMOAExpiry" CssClass="txtbox_Date" Width="20%" Enabled="false"></asp:TextBox>
                                                    <asp:Image runat="server" ID="img1" ImageUrl="~/images/calendar1.jpg" />
                                                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtMOAExpiry"></cc1:CalendarExtender>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 25%" class="column_RightBold">Business Permit : 
                                                </td>
                                                <td style="width: 75%" class="column_Left">
                                                    <asp:TextBox runat="server" ID="txtPermit" CssClass="txtbox_Var" Width="40%" Enabled="false"></asp:TextBox>
                                                    &nbsp;<span class="column_RightBold">Expiry:</span>
                                                    &nbsp;<asp:TextBox runat="server" ID="txtPermitExpiry" CssClass="txtbox_Date" Width="20%" Enabled="false"></asp:TextBox>
                                                    <asp:Image runat="server" ID="Image1" ImageUrl="~/images/calendar1.jpg" />
                                                    <cc1:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtPermitExpiry"></cc1:CalendarExtender>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 25%" class="column_RightBold">Tax Clearance : 
                                                </td>
                                                <td style="width: 75%" class="column_Left">
                                                    <asp:TextBox runat="server" ID="txtTaxClearance" CssClass="txtbox_Var" Width="40%" Enabled="false"></asp:TextBox>
                                                    &nbsp;<span class="column_RightBold">Expiry:</span>
                                                    &nbsp;<asp:TextBox runat="server" ID="txtTaxClearanceExpiry" CssClass="txtbox_Date" Width="20%" Enabled="false"></asp:TextBox>
                                                    <asp:Image runat="server" ID="Image2" ImageUrl="~/images/calendar1.jpg" />
                                                    <cc1:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtTaxClearanceExpiry"></cc1:CalendarExtender>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 25%" class="column_RightBold">PhilGeps : 
                                                </td>
                                                <td style="width: 75%" class="column_Left">
                                                    <asp:TextBox runat="server" ID="txtPhilGeps" CssClass="txtbox_Var" Width="40%" Enabled="false"></asp:TextBox>
                                                    &nbsp;<span class="column_RightBold">Expiry:</span>
                                                    &nbsp;<asp:TextBox runat="server" ID="txtPhilGeps_Expiry" CssClass="txtbox_Date" Width="20%" Enabled="false"></asp:TextBox>
                                                    <asp:Image runat="server" ID="Image3" ImageUrl="~/images/calendar1.jpg" />
                                                    <cc1:CalendarExtender ID="CalendarExtenderCERT" runat="server" TargetControlID="txtPhilGeps_Expiry"></cc1:CalendarExtender>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 25%" class="column_RightBold">FDA Accreditation : 
                                                </td>
                                                <td style="width: 75%" class="column_Left">
                                                    <asp:TextBox runat="server" ID="txtFDAAccreditation" CssClass="txtbox_Var" Width="40%" Enabled="false"></asp:TextBox>
                                                    &nbsp;<span class="column_RightBold">Expiry:</span>
                                                    &nbsp;<asp:TextBox runat="server" ID="txtFDAAccreditationExpiry" CssClass="txtbox_Date" Width="20%" Enabled="false"></asp:TextBox>
                                                    <asp:Image runat="server" ID="Image4" ImageUrl="~/images/calendar1.jpg" />
                                                    <cc1:CalendarExtender ID="CalendarExtender5" runat="server" TargetControlID="txtFDAAccreditationExpiry"></cc1:CalendarExtender>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 25%" class="column_RightBold">PCAB License : 
                                                </td>
                                                <td style="width: 75%" class="column_Left">
                                                    <asp:TextBox runat="server" ID="txtPCAB" CssClass="txtbox_Var" Width="40%" Enabled="false"></asp:TextBox>
                                                    &nbsp;<span class="column_RightBold">Category:</span>
                                                    &nbsp;<asp:TextBox runat="server" ID="txtPCAB_Category" CssClass="txtbox_Var" Width="30%" Enabled="false"></asp:TextBox>
                                                </td>
                                            </tr>

                                        </table>
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
                            <asp:Button ID="btnAdd" Visible="false" runat="server" CssClass="CSButton" Width="15%" Text="ADD" OnClientClick="StartProgressBar();"></asp:Button>
                            &nbsp;<asp:Button ID="btnEdit" Visible="false" runat="server" CssClass="CSButton" Width="15%" Text="EDIT" Enabled="False" OnClientClick="StartProgressBar();"></asp:Button>
                            
                            &nbsp;<asp:Button ID="btnSaveBid" runat="server" CssClass="CSButton" Width="15%" Text="SAVE" Enabled="False" ValidationGroup="save" OnClientClick="StartProgressBar();"></asp:Button>
                            &nbsp;<asp:Button ID="btnDelete" runat="server" CssClass="CSButton" Width="15%" Text="DELETE" Enabled="False" ValidationGroup="save" Visible="False"></asp:Button>
                            &nbsp;<asp:Button runat="server" ID="btnCloseGoods" Width="120px" CssClass="CSButton" Text="Close" />
                            <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" TargetControlID="btnsave" ConfirmText="Are you sure you want to save this transaction?"></cc1:ConfirmButtonExtender>
                            <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender2" runat="server" TargetControlID="btnDelete" ConfirmText="Are you sure you want to delete this transaction?"></cc1:ConfirmButtonExtender>

                        </td>
                        <td style="width: 1%"></td>
                    </tr>


                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%; height: 20px"></td>
                        <td style="width: 1%"></td>
                    </tr>
                </table>
                <asp:Label ID="lblProperty" runat="server"></asp:Label>
            </asp:Panel>
            <cc1:ModalPopupExtender ID="ModalPopupExtenderz" runat="server" BackgroundCssClass="modalBackground" CancelControlID="ImageButton2" PopupControlID="popup" TargetControlID="lblProperty"></cc1:ModalPopupExtender>



        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

