<%@ Page 
    Language="VB" 
    MasterPageFile="~/MasterPage.master" 
    AutoEventWireup="false" 
    EnableEventValidation="false"
    CodeFile="t_abstract_of_bids_Limited.aspx.vb" 
    Inherits="bidding_t_abstract_of_bids_Limited" 
    Title="Abstract of Bids" 
    StylesheetTheme="SkinFile" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>



            <div>
                <table width="100%">
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="PageTitle">ABSTRACT OF BIDS
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%; display:none" align="right">
                            <span class="column_RightBold">Date :</span>
                            &nbsp;
                            <asp:TextBox ID="txtResDate" runat="server" Width="100px" CssClass="txtbox_Date"></asp:TextBox>
                            &nbsp;<asp:ImageButton ID="ImageButton2" runat="server" Width="18px" ImageUrl="~/images/Calendar_scheduleHS.png" Height="15px"></asp:ImageButton>
                            &nbsp;<span class="CalendarFormat">(MM/DD/YYYY)</span>
                            <cc1:CalendarExtender ID="CalendarExtender5" runat="server" PopupButtonID="ImageButton2" Enabled="True" TargetControlID="txtResDate"></cc1:CalendarExtender>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:GridView ID="grdAbstractBids" runat="server" Width="90%" OnRowDataBound="grdAbstractBids_RowDataBound" AllowPaging="True"
                                OnPageIndexChanging="grdAbstractBids_PageIndexChanging" DataKeyNames="pre_procurement_hdr_id,TotalABC,CountSupplier,obr_evaluation_hdr_id,isPublicInfra"
                                AutoGenerateColumns="False" OnSelectedIndexChanged="grdAbstractBids_SelectedIndexChanged" PageSize="8" SkinID="GridViewAA">
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
                        <td style="width: 98%" class="DivTitle">List Of Goods
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:Panel ID="Panel1" runat="server" Width="98%" Font-Bold="True" CssClass="PanelSize" ScrollBars="Vertical" HorizontalAlign="Center">
                                <asp:GridView ID="grdGoods" runat="server" Width="100%" AutoGenerateColumns="False" PageSize="8" SkinID="GridViewAA" EmptyDataText="No Data Found."
                                    ShowFooter="True">
                                    <Columns>
                                        <asp:BoundField DataField="Item_Desc" HeaderText="Description">
                                            <ItemStyle HorizontalAlign="Left" Width="40%"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Unit" HeaderText="Unit">
                                            <ItemStyle HorizontalAlign="Center" Width="8%"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="PRPrice" DataFormatString="{0:N}" HeaderText="Unit Price">
                                            <ItemStyle HorizontalAlign="Right" Width="8%"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="BidQty" HeaderText="Quantity">
                                            <ItemStyle HorizontalAlign="Center" Width="8%"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="BidderName" HeaderText="Bidder Name">
                                            <ItemStyle HorizontalAlign="Left" Width="20%"></ItemStyle>
                                        </asp:BoundField>

                                        <asp:TemplateField HeaderText="Bid Unit Price">
                                            <FooterTemplate>
                                                TOTAL :
                                            </FooterTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblBidPrice" runat="server" Text='<%# Bind("BidPrice", "{0:N}") %>'></asp:Label>
                                            </ItemTemplate>

                                            <FooterStyle HorizontalAlign="Right" Font-Bold="True"></FooterStyle>
                                            <ItemStyle HorizontalAlign="Right" Width="8%"></ItemStyle>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Total Bid">
                                            <FooterTemplate>
                                                <asp:Label ID="lblTotalBid" runat="server"></asp:Label>
                                            </FooterTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblTotal" runat="server" Text='<%# Bind("TotalBid", "{0:N}") %>'></asp:Label>
                                            </ItemTemplate>

                                            <FooterStyle HorizontalAlign="Right" Font-Bold="False"></FooterStyle>
                                            <ItemStyle HorizontalAlign="Right" Width="8%"></ItemStyle>
                                        </asp:TemplateField>
                                    </Columns>

                                    <FooterStyle BackColor="#2977DC"></FooterStyle>
                                    <HeaderStyle BackColor="#2977DC" ForeColor="White"></HeaderStyle>
                                </asp:GridView>


                            </asp:Panel>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:Button ID="btnPreviewRead" OnClick="btnPreviewRead_Click" runat="server" Width="150px" CssClass="CSButton" Enabled="False" Text="PREVIEW AS READ"></asp:Button>
                            &nbsp;<asp:Button ID="btnSave" OnClick="btnSave_Click" runat="server" Width="150px" CssClass="CSButton" Enabled="False" Text="SAVE" ValidationGroup="1"></asp:Button>
                            &nbsp;<asp:Button ID="btnPreviewCalculated" OnClick="btnPreviewCalculated_Click" runat="server" Width="180px" CssClass="CSButton" Enabled="False" Text="PREVIEW AS CALCULATED"></asp:Button>
                            &nbsp;<asp:Button ID="btnReturn" runat="server" Enabled="False" Text="RETURN" ValidationGroup="1" Width="150px" CssClass="CSButton" OnClientClick="StartProgressBar();" />
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




            <asp:Panel ID="Panel2" runat="server" Width="300px" CssClass="Panel_Popup">
                <table style="width: 100%" cellpadding="0px" cellspacing="0px">
                    <tr>
                        <td style="width: 100%" colspan="2" class="DivTitle">Bac Resolution
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 30%; height: 10px" class="column_RightBold"></td>
                        <td style="width: 70%" align="left"></td>
                    </tr>
                    <tr>
                        <td style="width: 40%" class="column_RightBold">Resolution Date :&nbsp;</td>
                        <td style="width: 70%" align="left">
                            <asp:TextBox runat="server" ID="txtDate" Width="80%" CssClass="txtbox_Date"></asp:TextBox>
                            <cc1:CalendarExtender runat="server" TargetControlID="txtDate" PopupButtonID="txtDate"></cc1:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 30%; height: 5px" class="column_RightBold"></td>
                        <td style="width: 70%" align="left"></td>
                    </tr>
                    <tr>
                        <td style="width: 30%" class="column_RightBold">Resolution No. :&nbsp;</td>
                        <td style="width: 70%" align="left">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <asp:TextBox ID="txtResolutionNumber" runat="server" Width="80%" ReadOnly="True" CssClass="txtbox_Date"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="ok" ErrorMessage="*" ControlToValidate="txtResolutionNumber"></asp:RequiredFieldValidator>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 30%; height: 5px" class="column_RightBold"></td>
                        <td style="width: 70%" align="left"></td>
                    </tr>
                    <tr>
                        <td style="width: 100%" colspan="2" align="center">
                            <asp:Button ID="btnOK" runat="server" Width="80px" CssClass="CSButton" Text="OK" UseSubmitBehavior="False" OnClientClick="StartProgressBar();"></asp:Button>
                            &nbsp;<asp:Button ID="btnEdit" runat="server" Width="80px" Text="EDIT" CssClass="CSButton" OnClientClick="StartProgressBar();" Visible="false"></asp:Button>
                            &nbsp;<asp:Button ID="btnCancel" runat="server" Text="CANCEL" Width="80px" CssClass="CSButton" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 30%;height:10px" class="column_RightBold"></td>
                        <td style="width: 70%" align="left"></td>
                    </tr>
                </table>
                <asp:Label ID="Label2" runat="server"></asp:Label>
            </asp:Panel>


            <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="Label2" BackgroundCssClass="modalBackground" CancelControlID="btnCancel" PopupControlID="Panel2">
            </cc1:ModalPopupExtender>
            <asp:Panel Style="border-top-width: 1px; border-left-width: 1px; border-left-color: #0033cc; border-bottom-width: 1px; border-bottom-color: #0033cc; border-top-color: #0033cc; position: relative; background-color: transparent; text-align: center; border-right-width: 1px; border-right-color: #0033cc" ID="PanelProgress" runat="server" Width="109px">
                <img alt="" src="../images/ajax-loader.gif" />
            </asp:Panel>
            <cc1:ModalPopupExtender ID="ProgressBarModalPopupExtender" runat="server" TargetControlID="ButtonProgress" BackgroundCssClass="modalBackground" PopupControlID="PanelProgress" BehaviorID="ProgressBarModalPopupExtender"></cc1:ModalPopupExtender>
            <asp:Button Style="border-top-style: none; border-right-style: none; border-left-style: none; position: relative; background-color: transparent; border-bottom-style: none" ID="ButtonProgress" runat="server" Width="16px" Enabled="False"></asp:Button><br />



        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
