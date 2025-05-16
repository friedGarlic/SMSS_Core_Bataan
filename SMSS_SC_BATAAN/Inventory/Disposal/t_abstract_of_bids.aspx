<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeFile="t_abstract_of_bids.aspx.vb" Inherits="t_abstract_of_bids" StylesheetTheme="SkinFile" Title="Abstract Of Bids" %>



<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Contetnt1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <asp:UpdatePanel ID="UpdatePanelbids" runat="server">
        <ContentTemplate>



            <div>
                <table width="1020px">
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="PageTitle">DISPOSAL ABSTRACT OF BIDS</td>
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
                           

                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:MultiView ID="mvCategory" runat="server">
                                <asp:View ID="vwProperty" runat="server">
                                    <table style="width: 100%">
                                        <tr>
                                            <td style="width: 100%" class="DivTitle">Transactions</td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100%" align="center">
                                                <asp:GridView ID="gvnew" runat="server" Width="70%" OnSelectedIndexChanged="gvopen_SelectedIndexChanged" SkinID="GridViewAA" PageSize="5"
                                                    DataKeyNames="quotation_hdr_id,Disposal_id,quotation_date,Description" AutoGenerateColumns="False" AllowPaging="True" EmptyDataText="No Data Found.">
                                                    <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NextPreviousFirstLast" NextPageText="Next" PreviousPageText="Previous"></PagerSettings>
                                                    <Columns>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Select"
                                                                    Font-Underline="True" CssClass="LinkBtnSelect" Text="Select" Width="50px"></asp:LinkButton>

                                                            </ItemTemplate>

                                                            <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="Description" HeaderText="Mode of Disposal">
                                                            <ItemStyle HorizontalAlign="Left" Width="70%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="quotation_date" DataFormatString="{0:MM/dd/yyyy}" HeaderText="Date" HtmlEncode="False">
                                                            <ItemStyle HorizontalAlign="Center" Width="20%"></ItemStyle>
                                                        </asp:BoundField>
                                                    </Columns>

                                                </asp:GridView>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100%" class="DivTitle">Properties</td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100%" align="center">
                                                <asp:MultiView ID="mvQuot" runat="server">
                                                    <asp:View ID="vwItems" runat="server">
                                                        <table style="width: 100%">
                                                            <tr>
                                                                <td style="width: 100%" align="center">
                                                                    <asp:Panel ID="Panel5" runat="server" Width="98%" CssClass="PanelSize" ScrollBars="Vertical">
                                                                        <asp:GridView  ID="gvWinners" runat="server" Width="100%" SkinID="GridViewAA" AutoGenerateColumns="False" EmptyDataText="No Data Found."
                                                                            ShowFooter="True">
                                                                            <Columns>
                                                                                <asp:BoundField DataField="PropertyNo" HeaderText="Property Number">
                                                                                    <ItemStyle HorizontalAlign="Center" Width="25%"></ItemStyle>
                                                                                </asp:BoundField>
                                                                                <asp:BoundField DataField="Item_Desc" HeaderText="Description">
                                                                                    <ItemStyle HorizontalAlign="Left" Width="60%"></ItemStyle>
                                                                                </asp:BoundField>
                                                                                <asp:BoundField DataField="Cost" DataFormatString="{0:N}" HeaderText="Price" HtmlEncode="False">
                                                                                    <FooterStyle HorizontalAlign="Right" Font-Bold="False"></FooterStyle>

                                                                                    <ItemStyle HorizontalAlign="Right" Width="15%"></ItemStyle>
                                                                                </asp:BoundField>
                                                                            </Columns>
                                                                        </asp:GridView>
                                                                    </asp:Panel>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </asp:View>
                                                    <asp:View ID="vwLot" runat="server">
                                                        <table style="width: 100%">
                                                            <tbody>
                                                                <tr>
                                                                    <td style="width: 100%" align="center">
                                                                        <asp:Panel ID="Panel2" runat="server" Width="98%" CssClass="PanelSize" ScrollBars="Vertical">
                                                                            <asp:GridView  ID="grdLotItems" runat="server" Width="100%" SkinID="GridViewAA" AutoGenerateColumns="False" EmptyDataText="No Data Found."
                                                                                >
                                                                                <Columns>
                                                                                    <asp:BoundField DataField="Item_Desc" HeaderText="Description">
                                                                                        <ItemStyle HorizontalAlign="Left" Width="70%"></ItemStyle>
                                                                                    </asp:BoundField>
                                                                                    <asp:BoundField DataField="Unit" HeaderText="Unit">
                                                                                        <ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
                                                                                    </asp:BoundField>
                                                                                    <asp:BoundField DataField="Qty" HeaderText="Qty">
                                                                                        <ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
                                                                                    </asp:BoundField>
                                                                                </Columns>
                                                                            </asp:GridView>
                                                                        </asp:Panel>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 100%" align="center">
                                                                        <table style="width: 100%">
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td style="width: 30%" class="column_RightBold">Total Bid Amount : </td>
                                                                                    <td style="width: 70%" class="column_Left">
                                                                                        <asp:TextBox ID="txtAmount" runat="server" Width="200px" CssClass="txtbox_Amt" ReadOnly="True" ></asp:TextBox></td>
                                                                                </tr>
                                                                            </tbody>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                    </asp:View>
                                                </asp:MultiView></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                 <table style="width: 80%">
                                                    <tbody>
                                                        <tr>
                                                            <td style="width: 20%" class="column_RightBold">Mode : </td>
                                                            <td style="width: 80%" class="column_Left">
                                                                <asp:TextBox ID="txtPRno" runat="server" Width="200px" CssClass="txtbox_Var" ReadOnly="True"></asp:TextBox>
                                                                &nbsp;<span class="column_RightBold">Date :</span>
                                                                &nbsp;<asp:TextBox ID="txtcanvassdate" runat="server" Width="100px" CssClass="txtbox_Date" SkinID="text"></asp:TextBox>
                                                                &nbsp;<asp:ImageButton ID="ImageButton3" runat="server" Width="20px" ImageUrl="~/images/Calendar_scheduleHS.png" Height="15px"></asp:ImageButton>
                                                                <span class="CalendarFormat">(MM/DD/YYYY)</span></td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 20%" class="column_RightBold">Bid / Canvass Number : </td>
                                                            <td style="width: 80%" class="column_Left">
                                                                <asp:TextBox ID="txtcanvass" runat="server" Width="200px" AutoPostBack="True" CssClass="txtbox_Var" ReadOnly="True"></asp:TextBox></td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 20%" class="column_RightBold">Bidder Name : </td>
                                                            <td style="width: 80%" class="column_Left">
                                                                <asp:DropDownList ID="ddSupplier" runat="server" Width="400px" AutoPostBack="True" CssClass="drpdownCSS">
                                                                    <asp:ListItem Value="0">Select</asp:ListItem>
                                                                </asp:DropDownList></td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtcanvassdate" PopupButtonID="ImageButton3"></cc1:CalendarExtender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100%" align="center">
                                                <asp:Button ID="btnSave" runat="server" Width="150px" CssClass="CSButton" Enabled="False" Text="SAVE" OnClientClick="StartProgressBar();"></asp:Button>
                                                <asp:Button ID="btnPreview" runat="server" Width="150px" CssClass="CSButton" Enabled="False" Text="PREVIEW" ></asp:Button></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100%" align="center">
                                                <asp:Button ID="btnNew" runat="server" Width="100px" SkinID="ButtonImage" Visible="False" Text="NEW" ></asp:Button>
                                                <asp:Button ID="bntOpen" runat="server" Width="100px" SkinID="ButtonImage" Visible="False" Text="OPEN" ></asp:Button>
                                                <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" TargetControlID="btnSave" ConfirmText="Are you sure you want to save this transaction?" __designer:wfdid="w62">
                                                </cc1:ConfirmButtonExtender>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:View>











                                <asp:View ID="vwSupply" runat="server" __designer:wfdid="w55">
                                    <table style="width: 100%">
                                        <tbody>
                                            <tr>
                                                <td style="width: 100%" class="DivTitle" align="center">TRANSACTIONS</td>
                                            </tr>
                                            <tr>
                                                <td style="width: 100%" align="center">
                                                    <asp:GridView Style="font-weight: normal" ID="grdSupplies" runat="server" Width="90%" Font-Size="9pt" OnSelectedIndexChanged="grdSupplies_SelectedIndexChanged" SkinID="GridViewAA" PageSize="5" DataKeyNames="Description,IIRUS_ID" AutoGenerateColumns="False" AllowPaging="True" EmptyDataText="No Data Found." AllowSorting="True" __designer:wfdid="w56">
                                                        <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NextPreviousFirstLast" NextPageText="Next" PreviousPageText="Previous"></PagerSettings>
                                                        <Columns>
                                                            <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Select"
                                                                        Font-Underline="True" ForeColor="Black" Text="Select" Width="50px"></asp:LinkButton>

                                                                </ItemTemplate>

                                                                <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="Description" HeaderText="Mode of Disposal">
                                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                                <ItemStyle HorizontalAlign="Left" Width="70%"></ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="quotation_date" DataFormatString="{0:d}" HeaderText="Date" HtmlEncode="False">
                                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                                <ItemStyle HorizontalAlign="Center" Width="20%"></ItemStyle>
                                                            </asp:BoundField>
                                                        </Columns>

                                                        <HeaderStyle Font-Names="Arial" Font-Size="8pt"></HeaderStyle>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 100%" class="DivTitle" align="center">SUPPLIES</td>
                                            </tr>
                                            <tr>
                                                <td style="width: 100%" align="center">
                                                    <asp:GridView Style="font-weight: normal" ID="grdSupply" runat="server" Width="100%" Font-Size="9pt" SkinID="GridViewAA" AutoGenerateColumns="False" EmptyDataText="No Data Found." ShowFooter="True" __designer:wfdid="w57">
                                                        <Columns>
                                                            <asp:BoundField DataField="Item_Desc" HeaderText="Description">
                                                                <ItemStyle HorizontalAlign="Left" Width="60%"></ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Qty" HeaderText="Quantity">
                                                                <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="BidUnit_Price" DataFormatString="{0:N}" HeaderText="Bid Unit Price" HtmlEncode="False">
                                                                <FooterStyle HorizontalAlign="Right" Font-Bold="False"></FooterStyle>

                                                                <ItemStyle HorizontalAlign="Right" Width="15%"></ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="TotalAmount" DataFormatString="{0:N}" HeaderText="Total Amount">
                                                                <FooterStyle HorizontalAlign="Right" Font-Bold="True"></FooterStyle>

                                                                <ItemStyle HorizontalAlign="Right" Width="15%"></ItemStyle>
                                                            </asp:BoundField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 100%" align="center">
                                                    <asp:Button ID="btnSaveSupp" OnClick="btnSaveSupp_Click" runat="server" CssClass="CSButton" Width="200px" SkinID="ButtonImage" Enabled="False" Text="SAVE" OnClientClick="StartProgressBar();" __designer:wfdid="w58"></asp:Button><asp:Button ID="btnPreviewSupp" OnClick="btnPreviewSupp_Click" runat="server" Width="200px" SkinID="ButtonImage" Enabled="False" Visible="False" Text="PREVIEW" __designer:wfdid="w59"></asp:Button></td>
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
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%"></td>
                        <td style="width: 1%"></td>
                    </tr>
                </table>
            </div>






            <asp:Panel Style="border-top-width: 1px; border-left-width: 1px; border-left-color: #0033cc; border-bottom-width: 1px; border-bottom-color: #0033cc; border-top-color: #0033cc; position: relative; background-color: transparent; text-align: center; border-right-width: 1px; border-right-color: #0033cc" ID="PanelProgress" runat="server" Width="109px">
                <img alt="" src="../../images/ajax-loader.gif" />
            </asp:Panel>
            <cc1:ModalPopupExtender ID="ProgressBarModalPopupExtender" runat="server" TargetControlID="ButtonProgress" BehaviorID="ProgressBarModalPopupExtender" PopupControlID="PanelProgress" BackgroundCssClass="modalBackground"></cc1:ModalPopupExtender>
            <asp:Button Style="border-top-style: none; border-right-style: none; border-left-style: none; position: relative; background-color: transparent; border-bottom-style: none" ID="ButtonProgress" runat="server" Width="16px" Enabled="False"></asp:Button>



        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
