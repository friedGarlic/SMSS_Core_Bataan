<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
    StylesheetTheme="SkinFile" CodeFile="t_quotation.aspx.vb" Inherits="t_quotation"
    Title="Quotation" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<script runat="server">


</script>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <asp:UpdatePanel ID="upCollapse" runat="server">
        <ContentTemplate>




            <div>
                <table width="1020px">
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="PageTitle">QUOTATION</td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="left">
                            <table width="100%">
                                <tr>
                                    <td style="width: 5%" class="column_RightBold">Goods :</td>
                                    <td style="width: 95%" align="left">
                                        <asp:RadioButtonList ID="rbChoice" runat="server" Width="220px" CssClass="rbCS_Horizontal" OnSelectedIndexChanged="rbChoice_SelectedIndexChanged" AutoPostBack="True" RepeatDirection="Horizontal">
                                            <asp:ListItem Selected="True" Value="1">Properties</asp:ListItem>
                                            <asp:ListItem Value="2">Supplies</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:MultiView ID="mvCategory" runat="server">
                                <asp:View ID="vwProperty" runat="server">
                                    <table width="100%">
                                        <tr>
                                            <td style="width: 100%" align="center">
                                                <asp:GridView ID="gvPublic_bidding" runat="server" Width="90%" OnSelectedIndexChanged="gvPublic_bidding_SelectedIndexChanged" 
                                                    SkinID="GridViewAA" DataKeyNames="IIRUPHdr_ID,BidDate,Disposal_id,Description,Bidders" PageSize="5" 
                                                    AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="gvPublic_bidding_PageIndexChanging">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Select" ShowHeader="False">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="LinkButton1" OnClick="LinkButton1_Click" runat="server" CssClass="LinkBtnSelect" CausesValidation="False" Text="Select" Visible='<%#Bind("isVisible") %>' Font-Underline="False" CommandName="Select"></asp:LinkButton>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                        </asp:TemplateField>

                                                        <asp:BoundField DataField="Description" HeaderText="Mode of Disposal">
                                                            <ItemStyle HorizontalAlign="Center" Width="40%"></ItemStyle>
                                                        </asp:BoundField>

                                                        <asp:TemplateField HeaderText="Date">
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("BidDate", "{0:d}") %>' Visible='<%# bind("isVisible") %>'></asp:Label>
                                                            </ItemTemplate>

                                                            <HeaderStyle CssClass="textGrdHeader"></HeaderStyle>
                                                            <ItemStyle HorizontalAlign="Center" Width="20%"></ItemStyle>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="No. of Bidder">
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("Bidders") %>' Visible='<%# bind("isVisible") %>'></asp:Label>
                                                            </ItemTemplate>

                                                            <HeaderStyle CssClass="textGrdHeader"></HeaderStyle>

                                                            <ItemStyle HorizontalAlign="Center" Width="20%"></ItemStyle>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lbApprove" OnClick="lbApprove_Click1" runat="server" CausesValidation="False" Font-Bold="False" Visible='<%#Bind("isVisible") %>' Font-Underline="False" CommandName="Select">Close</asp:LinkButton>
                                                                <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender2" runat="server" TargetControlID="lbApprove" ConfirmText="Are you sure you want to close this transaction?"></cc1:ConfirmButtonExtender>
                                                            </ItemTemplate>

                                                            <HeaderStyle CssClass="textGrdHeader"></HeaderStyle>

                                                            <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100%" align="center">
                                                <asp:RadioButtonList ID="RadioButtonList1" runat="server" Width="250px" CssClass="rbCS_Horizontal" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" AutoPostBack="True" RepeatDirection="Horizontal" Enabled="False">
                                                    <asp:ListItem Value="1">BID PER ITEMS</asp:ListItem>
                                                    <asp:ListItem Value="2">BID PER LOT</asp:ListItem>
                                                </asp:RadioButtonList></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100%" class="DivTitle">Goods</td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100%" align="center">
                                                <asp:MultiView ID="mvType" runat="server">
                                                    <asp:View ID="vwPerItems" runat="server">
                                                        <asp:Panel ID="Panel2" runat="server" Width="98%" CssClass="PanelSize" ScrollBars="Vertical">
                                                            <asp:GridView ID="gvitems" runat="server" Width="100%" SkinID="GridViewAA" PageSize="5" AutoGenerateColumns="False" CaptionAlign="Left" EmptyDataText="No Data Found." >
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Description">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblunit" runat="server"  Text='<%# Bind("Item_Desc") %>' Visible='<%# bind("isVisible") %>'></asp:Label>
                                                                        </ItemTemplate>

                                                                        <ItemStyle HorizontalAlign="Left" Width="55%"></ItemStyle>
                                                                    </asp:TemplateField>

                                                                    <asp:BoundField DataField="PropertyNo" HeaderText="Property Number">
                                                                        <ItemStyle HorizontalAlign="Center" Width="20%"></ItemStyle>
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="Unit" HeaderText="Unit">
                                                                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                                    </asp:BoundField>

                                                                    <asp:TemplateField HeaderText="Details" Visible="False">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblqty" runat="server" Text='<%#Bind("Details") %>' Visible='<%# bind("isVisible") %>'></asp:Label>
                                                                        </ItemTemplate>

                                                                        <ItemStyle HorizontalAlign="Left" Width="20%"></ItemStyle>
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField HeaderText="Price">
                                                                        <ItemTemplate>
                                                                            <asp:TextBox ID="txtCost" runat="server" Width="98%" AutoPostBack="True" CssClass="txtbox_Amt" Enabled='<%#Bind("enable") %>' Text='<%# bind("Cost", "{0:N}") %>' Visible='<%# bind("isVisible") %>' OnTextChanged="txtCost_TextChanged"></asp:TextBox><cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtCost" ValidChars=".0123456789,">
                                                                            </cc1:FilteredTextBoxExtender>
                                                                        </ItemTemplate>

                                                                        <ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
                                                                    </asp:TemplateField>
                                                                </Columns>

                                                                <HeaderStyle Font-Names="Arial" Font-Size="8pt"></HeaderStyle>
                                                            </asp:GridView>
                                                        </asp:Panel>
                                                    </asp:View>

                                                    <asp:View ID="vwPerLot" runat="server">
                                                        <asp:Panel ID="Panel1" runat="server" Width="98%" CssClass="PanelSize" ScrollBars="Vertical">
                                                            <asp:GridView  ID="grdPerLot" runat="server" Width="100%" SkinID="GridViewAA" PageSize="5" AutoGenerateColumns="False" 
                                                                CaptionAlign="Left">
                                                                <Columns>
                                                                    <asp:BoundField DataField="ItemNo" HeaderText="No.">
                                                                        <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                                                    </asp:BoundField>
                                                                    <asp:TemplateField HeaderText="Description">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblunit" runat="server"  Text='<%# Bind("Item_Desc") %>'></asp:Label>
                                                                        </ItemTemplate>

                                                                        <ItemStyle HorizontalAlign="Left" Width="70%"></ItemStyle>
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="Qty" HeaderText="Quantity">
                                                                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="Unit" HeaderText="Unit">
                                                                        <ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
                                                                    </asp:BoundField>
                                                                </Columns>

                                                                <HeaderStyle Font-Names="Arial"></HeaderStyle>
                                                            </asp:GridView>
                                                        </asp:Panel>
                                                        <table style="width: 100%">
                                                            <tbody>
                                                                <tr>
                                                                    <td style="width: 20%" class="column_RightBold">Total Amount Bid :</td>
                                                                    <td style="width: 80%" class="column_Left">
                                                                        <asp:TextBox ID="txtTotalAmount" runat="server" Width="200px" AutoPostBack="True" CssClass="txtbox_Amt" OnTextChanged="txtTotalAmount_TextChanged"></asp:TextBox></td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 20%" class="column_RightBold"></td>
                                                                    <td style="width: 80%" class="column_Left"></td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                    </asp:View>
                                                </asp:MultiView></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100%" class="DivTitle">Bidders</td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100%" align="center">
                                                <asp:GridView ID="gvsupplier" runat="server" Width="100%" OnSelectedIndexChanged="gvsupplier_SelectedIndexChanged" SkinID="GridViewAA" 
                                                    DataKeyNames="Supplier_Id,isOld,quotation_hdr_id" PageSize="5">
                                                    <Columns>
                                                        
                                                        <asp:TemplateField HeaderText="Name of Bidder">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lbSupplier" OnClick="lbSupplier_Click" runat="server" CssClass="LinkBtnSelect" CausesValidation="False" Text='<%# Bind("SuppName") %>' Font-Underline="False" CommandName="Select"></asp:LinkButton>
                                                            </ItemTemplate>

                                                            <HeaderStyle CssClass="textGrdHeader"></HeaderStyle>
                                                            <ItemStyle HorizontalAlign="Left" Width="60%"></ItemStyle>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="Supplier_Id" Visible="true"  HeaderText="Supplier_Id">
                                                            <ItemStyle HorizontalAlign="Right" Width="15%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:TemplateField HeaderText="Date Submitted">
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("date", "{0:MM/dd/yyyy}") %>' Visible='<%# bind("isVisible") %>'></asp:Label>
                                                            </ItemTemplate>

                                                            <HeaderStyle CssClass="textGrdHeader"></HeaderStyle>
                                                            <ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
                                                        </asp:TemplateField>

                                                        <asp:BoundField DataField="cost" DataFormatString="{0:N}" HeaderText="Amount">
                                                            <ItemStyle HorizontalAlign="Right" Width="15%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Status" HeaderText="Status">
                                                            <HeaderStyle CssClass="textGrdHeader"></HeaderStyle>
                                                            <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                        </asp:BoundField>
                                                        
                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100%" align="center">
                                                <span class="column_RightBold">Bidder Name : </span>
                                                <asp:DropDownList ID="ddSupplier" runat="server" Width="350px" CssClass="drpdownCSS" OnSelectedIndexChanged="ddSupplier_SelectedIndexChanged" AutoPostBack="True" Enabled="False" AppendDataBoundItems="True">
                                                    <asp:ListItem Value="0">Select</asp:ListItem>
                                                </asp:DropDownList>                                                
                                                &nbsp;<asp:Button ID="btnsupplier" OnClick="btnsupplier_Click" runat="server" Width="150px" CssClass="CSButton" Enabled="False" Text="ADD BIDDER" OnClientClick="StartProgressBar();"></asp:Button></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100%" align="center">
                                                <asp:Button ID="btnsubmit" runat="server" Width="150px" CssClass="CSButton" Text="SAVE" OnClientClick="StartProgressBar();" OnClick="btnsubmit_Click"></asp:Button>
                                                <asp:Button ID="btnPreview" runat="server" Width="150px" Text="PREVIEW" OnClientClick="StartProgressBar();" Visible="False"></asp:Button>
                                                <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" TargetControlID="btnsubmit" ConfirmText="Are you sure you want to save  this transaction?">
                                                </cc1:ConfirmButtonExtender>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:View>




                                <asp:View ID="vwSupply" runat="server">
                                    <table style="width: 100%">
                                        <tbody>
                                            <tr>
                                                <td style="width: 100%" align="center">
                                                    <asp:GridView Style="font-weight: normal" ID="grdSuppList" runat="server" Width="80%" Font-Size="9pt" OnSelectedIndexChanged="grdSuppList_SelectedIndexChanged" SkinID="GridViewAA" DataKeyNames="IIRUS_ID,Disposal_id" PageSize="5" AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="grdSuppList_PageIndexChanging" EmptyDataText="No Data Found." CaptionAlign="Left">
                                                        <EmptyDataRowStyle HorizontalAlign="Left"></EmptyDataRowStyle>
                                                        <Columns>
                                                            <asp:TemplateField ShowHeader="False">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Select"
                                                                        Font-Underline="True" ForeColor="Black" Text="Select"></asp:LinkButton>

                                                                </ItemTemplate>

                                                                <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="IIRUS_ID" HeaderText="Transaction ID">
                                                                <ItemStyle HorizontalAlign="Center" Width="20%"></ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="DisposalDesc" HeaderText="Mode of Disposal">
                                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                                <ItemStyle HorizontalAlign="Center" Width="30%"></ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="InspectionDate" DataFormatString="{0:d}" HeaderText="Inspection Date">
                                                                <ItemStyle HorizontalAlign="Center" Width="20%"></ItemStyle>
                                                            </asp:BoundField>
                                                        </Columns>

                                                        <HeaderStyle Font-Names="Arial" Font-Size="8pt"></HeaderStyle>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 100%" class="DivTitle" align="center">LIST OF ITEMS</td>
                                            </tr>
                                            <tr>
                                                <td style="width: 100%" align="center">
                                                    <asp:GridView Style="font-weight: normal" ID="grdItemList" runat="server" Width="100%" Font-Size="9pt" SkinID="GridViewGL" PageSize="5" AutoGenerateColumns="False" EmptyDataText="No Data Found." CaptionAlign="Left" ShowFooter="True">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Mode of Disposal" Visible="False">
                                                                <EditItemTemplate>
                                                                    <asp:TextBox runat="server" Text='<%# Bind("DisposalDesc") %>' ID="TextBox5"></asp:TextBox>
                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblDisposalMode" runat="server" Text='<%# Bind("DisposalDesc") %>'></asp:Label>
                                                                </ItemTemplate>

                                                                <HeaderStyle CssClass="textGrdHeader"></HeaderStyle>

                                                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Item Description">
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Description") %>'></asp:TextBox>
                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblItem_Desc" runat="server" Text='<%# Bind("Item_Desc") %>'></asp:Label>
                                                                </ItemTemplate>

                                                                <ItemStyle HorizontalAlign="Left" Width="50%"></ItemStyle>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Quantity">
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Qty") %>'></asp:TextBox>

                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label Style="text-align: center" ID="lblqty" runat="server" Text='<%#Bind("Qty") %>'></asp:Label>
                                                                </ItemTemplate>

                                                                <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Appraised Value">
                                                                <EditItemTemplate>
                                                                    <asp:TextBox runat="server" ID="TextBox1"></asp:TextBox>
                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblAppraised" runat="server" Text='<%#Bind("AppraisedVal") %>'></asp:Label>
                                                                </ItemTemplate>

                                                                <FooterStyle HorizontalAlign="Right" Font-Bold="True"></FooterStyle>

                                                                <ItemStyle HorizontalAlign="Right" Width="10%"></ItemStyle>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Bid Price">
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("Cost") %>'></asp:TextBox>
                                                                </EditItemTemplate>
                                                                <FooterTemplate>
                                                                    &nbsp;TOTAL :
                                                                </FooterTemplate>
                                                                <ItemTemplate>
                                                                    <asp:TextBox Style="text-align: right" ID="txtBidPrice" runat="server" Width="98%" AutoPostBack="True" CssClass="txtboxAmount" Text='<%#Bind("AppraisedVal", "{0:N}") %>' OnTextChanged="txtBidPrice_TextChanged"></asp:TextBox><cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtBidPrice" ValidChars=".0123456789,"></cc1:FilteredTextBoxExtender>
                                                                </ItemTemplate>

                                                                <FooterStyle HorizontalAlign="Right" Font-Bold="True"></FooterStyle>

                                                                <ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Total Amount">
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("TotalAmount") %>'></asp:TextBox>
                                                                </EditItemTemplate>
                                                                <FooterTemplate>
                                                                    <asp:Label ID="lblTotalAmount" runat="server" Font-Bold="True"></asp:Label>
                                                                </FooterTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblTotal" runat="server"></asp:Label>
                                                                </ItemTemplate>

                                                                <FooterStyle HorizontalAlign="Right" Font-Bold="True"></FooterStyle>

                                                                <HeaderStyle HorizontalAlign="Right"></HeaderStyle>

                                                                <ItemStyle HorizontalAlign="Right" Width="15%"></ItemStyle>
                                                            </asp:TemplateField>
                                                        </Columns>

                                                        <HeaderStyle Font-Names="Arial" Font-Size="8pt"></HeaderStyle>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 100%" class="DivTitle" align="center">BIDDERS</td>
                                            </tr>
                                            <tr>
                                                <td style="width: 100%" align="center">
                                                    <asp:GridView Style="font-weight: normal" ID="grdBidders" runat="server" Width="80%" Font-Size="9pt" SkinID="GridViewAA" PageSize="5" AutoGenerateColumns="False" EmptyDataText="NO DATA FOUND" CaptionAlign="Left">
                                                        <EmptyDataRowStyle HorizontalAlign="Left"></EmptyDataRowStyle>
                                                        <Columns>
                                                            <asp:BoundField DataField="SuppName" HeaderText="Bidder Name">
                                                                <ItemStyle HorizontalAlign="Left" Width="70%"></ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="TotalAmount" DataFormatString="{0:N}" HeaderText="Total Bid Amount">
                                                                <ItemStyle HorizontalAlign="Right" Width="30%"></ItemStyle>
                                                            </asp:BoundField>
                                                        </Columns>

                                                        <HeaderStyle Font-Names="Arial" Font-Size="8pt"></HeaderStyle>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 100%" align="center">
                                                    <table style="width: 100%">
                                                        <tbody>
                                                            <tr>
                                                                <td style="width: 20%" class="column_RightBold">Select Bidders : </td>
                                                                <td style="width: 80%" class="column_Left">
                                                                    <asp:DropDownList ID="ddSupplier2" runat="server" Width="500px" OnSelectedIndexChanged="ddSupplier2_SelectedIndexChanged" CssClass="txtboxinspection"></asp:DropDownList><asp:Button ID="btnAdd" OnClick="btnAdd_Click" CssClass="CSButton" runat="server" Width="150px" Text="SAVE BIDDER" OnClientClick="StartProgressBar();"></asp:Button></td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 100%" align="center">
                                                    <asp:Button ID="btnSaveSupp" OnClick="btnSaveSupp_Click" runat="server" CssClass="CSButton" Width="200px" Enabled="False" Text="DONE" OnClientClick="StartProgressBar();"></asp:Button><asp:Button ID="btnPreviewSupp" runat="server" Width="200px" Text="PREVIEW" OnClientClick="StartProgressBar();" Visible="False"></asp:Button></td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </asp:View>
                            </asp:MultiView>
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
            <asp:Button Style="border-top-style: none; border-right-style: none; border-left-style: none; background-color: transparent; border-bottom-style: none" ID="ButtonProgress" runat="server" Width="16px" __designer:wfdid="w3" Enabled="False"></asp:Button>
        
        
        
        
        
        </ContentTemplate>
    </asp:UpdatePanel>


</asp:Content>
