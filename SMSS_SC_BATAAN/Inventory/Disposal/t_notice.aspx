<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeFile="t_notice.aspx.vb" Inherits="t_notice_of_award" StylesheetTheme="SkinFile" Title="Notice Of Award" %>



<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<script runat="server">


</script>


<asp:Content ID="Contetnt1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <asp:UpdatePanel ID="UpdatePanel21" runat="server" >
        <ContentTemplate>
            <table style="width: 1010px">
                <tbody>
                    <tr>
                        <td style="width: 10px"></td>
                        <td style="width: 1000px" class="PageTitle" align="center">NOTICE <label id="lblNotice" runat="server">OF AWARD</label></td>
                    </tr>
                     <tr>
                        <td style="width: 10px"></td>
                        <td style="width: 1000px">
                             <asp:Button ID="btnNoticeofAward" runat="server" Width="180px" CssClass="Initial" Text="Notice of Award" Visible="true" OnClick="btnNoticeofAward_Click"></asp:Button>                           
                              <asp:Button ID="btnNoticetoProceed" runat="server" Width="180px" CssClass="Initial" Text="Notice to Proceed" Visible="true" OnClick="btnNoticetoProceed_Click"></asp:Button>                           
                     </td>
                    </tr>

                    <tr>
                        <td style="width: 10px"></td>
                        <td style="width: 1000px" align="center">
                            <asp:RadioButtonList ID="rbChoice" runat="server" Width="250px" Font-Bold="True" Font-Size="12pt" Font-Names="Calibri" __designer:wfdid="w63" OnSelectedIndexChanged="rbChoice_SelectedIndexChanged" AutoPostBack="True" RepeatDirection="Horizontal">
                                <asp:ListItem Selected="True" Value="1">PROPERTIES</asp:ListItem>
                                <asp:ListItem Value="2">SUPPLIES</asp:ListItem>
                            </asp:RadioButtonList></td>
                    </tr>
                      <tr>
                        <td style="width: 10px"></td>
                        <td style="width: 1000px" align="center">
                            <table>
                                 <tr>
                        <td style="width: 10px"></td>
                        <td style="width: 1000px" align="center">
                            <asp:MultiView ID="mvCategory" runat="server" __designer:wfdid="w68">
                                <asp:View ID="vwProperty" runat="server" __designer:wfdid="w69">
                                    <table style="width: 100%">
                                        <tbody>
                                            <tr>
                                                <td style="width: 100%" class="DivTitle" align="center">LIST OF TRANSACTION</td>
                                            </tr>
                                            <tr>
                                                <td style="width: 100%" align="center">
                                                    <asp:GridView Style="font-weight: normal" ID="gvnew" runat="server" Width="80%" Font-Size="9pt" __designer:wfdid="w70" OnSelectedIndexChanged="gvopen_SelectedIndexChanged" SkinID="GridViewAA" PageSize="5" DataKeyNames="Disposal_Bid_hdr_id,BidDate,SuppName,description,BidNo,quotation_hdr_id,Supplier_Id" AutoGenerateColumns="False" EmptyDataText="No Data Found.">
                                                        <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NextPreviousFirstLast" NextPageText="Next" PreviousPageText="Previous"></PagerSettings>
                                                        <Columns>
                                                            <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Select"
                                                                        Font-Underline="True" ForeColor="Black" Text="Select" Width="50px"></asp:LinkButton>

                                                                </ItemTemplate>

                                                                <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="Suppname" HeaderText="Bidder">
                                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                                <ItemStyle HorizontalAlign="Left" Width="70%"></ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="BidDate" DataFormatString="{0:MM/dd/yyyy}" HeaderText="Date" HtmlEncode="False">
                                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                                <ItemStyle HorizontalAlign="Center" Width="25%"></ItemStyle>
                                                            </asp:BoundField>
                                                        </Columns>

                                                        <HeaderStyle Font-Names="Arial" Font-Size="8pt"></HeaderStyle>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr>
                                                   <td style="width: 100%" class="DivTitle" align="center">TRANSACTION DETAILS</td>
                                            
                                            </tr>
                                              <tr>
                       
                        <td style="width: 1000px" align="center">
                            <table style="width: 70%" class="panel_border">
                                <tbody>
                                    <tr>
                                        <td style="width: 20%" class="column_RightBold">Mode : </td>
                                        <td style="width: 80%" class="text5">
                                            <asp:TextBox ID="txtPRno" runat="server" Width="200px" __designer:wfdid="w64" CssClass="text" SkinID="text" ReadOnly="True"></asp:TextBox> <strong>Date :</strong>
                                            <asp:TextBox ID="txtcanvassdate" runat="server" Width="110px" __designer:wfdid="w65" CssClass="text" SkinID="text" ></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 20%" class="column_RightBold">Bid / Canvass Number : </td>
                                        <td style="width: 80%" class="text5">
                                            <asp:TextBox ID="txtcanvass" runat="server" Width="200px" __designer:wfdid="w66" CssClass="text" SkinID="text" ReadOnly="True"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 20%" class="column_RightBold">Bidder Name : </td>
                                        <td style="width: 80%" class="text5">
                                            <asp:TextBox ID="txtsupplier" runat="server" Width="320px" __designer:wfdid="w67" ReadOnly="True"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 20%" class="column_RightBold"></td>
                                        <td style="width: 80%" class="text5"></td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                    </tr>
                  
                                            <tr>
                                                <td style="width: 100%" class="DivTitle" align="center">PROPERTY LIST</td>
                                            </tr>
                                            <tr>
                                                <td style="width: 100%" align="center">
                                                    <asp:MultiView ID="mvQuotation" runat="server" __designer:wfdid="w71">
                                                        <asp:View ID="vwPerItems" runat="server" __designer:wfdid="w72">
                                                            <asp:Panel ID="Panel5" runat="server" Width="98%" CssClass="PanelSize" ScrollBars="Vertical" __designer:wfdid="w73">
                                                                <asp:GridView Style="font-weight: normal" ID="gvWinners" runat="server" Width="100%" Font-Size="9pt" SkinID="GridViewAA" EmptyDataText="No Data Found." AutoGenerateColumns="False" ShowFooter="True" __designer:wfdid="w74">
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
                                                        </asp:View>
                                                        <asp:View ID="vwPerLot" runat="server" __designer:wfdid="w75">
                                                            <asp:Panel ID="Panel6" runat="server" Width="98%" CssClass="PanelSize" ScrollBars="Vertical" __designer:wfdid="w76">
                                                                <asp:GridView Style="font-weight: normal" ID="grdPerLot" runat="server" Width="100%" Font-Size="9pt" SkinID="GridViewAA" EmptyDataText="No Data Found." AutoGenerateColumns="False" __designer:wfdid="w77">
                                                                    <Columns>
                                                                        <asp:BoundField DataField="PropertyNo" HeaderText="Description">
                                                                            <ItemStyle HorizontalAlign="Left" Width="70%"></ItemStyle>
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="Unit" HeaderText="Unit">
                                                                            <ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="Cost" DataFormatString="{0:N}" HeaderText="Total Amount" HtmlEncode="False">
                                                                            <FooterStyle HorizontalAlign="Right" Font-Bold="False"></FooterStyle>

                                                                            <ItemStyle HorizontalAlign="Right" Width="15%"></ItemStyle>
                                                                        </asp:BoundField>
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </asp:Panel>
                                                        </asp:View>
                                                    </asp:MultiView></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 100%" align="center">
                                                    <asp:Button ID="btnSave" runat="server" Width="200px" __designer:wfdid="w78" SkinID="ButtonImage" Text="SAVE" Enabled="False" OnClientClick="StartProgressBar();" ValidationGroup="1" CssClass="CSButton"></asp:Button><asp:Button ID="btnPreview" runat="server" CssClass="CSButton" Width="200px" __designer:wfdid="w79" SkinID="ButtonImage" Text="PREVIEW" Enabled="False" OnClientClick="StartProgressBar();"></asp:Button></td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </asp:View>
                                <asp:View ID="vwSupply" runat="server" __designer:wfdid="w80">
                                    <table style="width: 100%">
                                        <tbody>
                                            <tr>
                                                <td style="width: 100%" class="DivTitle" align="center">LIST OF TRANSACTION</td>
                                            </tr>
                                            <tr>
                                                <td style="width: 100%" align="center">
                                                    <asp:GridView Style="font-weight: normal" ID="grdNOA_Supp" runat="server" Width="70%" Font-Size="9pt" __designer:wfdid="w81" OnSelectedIndexChanged="grdNOA_Supp_SelectedIndexChanged" SkinID="GridViewAA" PageSize="5" DataKeyNames="DSupplies_Hdr_ID,IIRUS_ID,Canvass_No,Description,SuppName,Supplier_ID" AutoGenerateColumns="False" EmptyDataText="No Data Found.">
                                                        <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NextPreviousFirstLast" NextPageText="Next" PreviousPageText="Previous"></PagerSettings>
                                                        <Columns>
                                                            <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Select"
                                                                        Font-Underline="True" ForeColor="Black" Text="Select" Width="50px"></asp:LinkButton>

                                                                </ItemTemplate>

                                                                <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="SuppName" HeaderText="Bidder Name">
                                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                                <ItemStyle HorizontalAlign="Left" Width="70%"></ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Quotation_Date" DataFormatString="{0:d}" HeaderText="Date" HtmlEncode="False">
                                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                                <ItemStyle HorizontalAlign="Center" Width="25%"></ItemStyle>
                                                            </asp:BoundField>
                                                        </Columns>

                                                        <HeaderStyle Font-Names="Arial" Font-Size="8pt"></HeaderStyle>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr>
                                                   <td style="width: 100%" class="DivTitle" align="center">TRANSACTION DETAILS</td>
                                            
                                            </tr>
                                              <tr>
                       
                        <td style="width: 1000px" align="center">
                            <table style="width: 70%" class="panel_border">
                                <tbody>
                                    <tr>
                                        <td style="width: 20%" class="column_RightBold">Mode : </td>
                                        <td style="width: 80%" class="text5">
                                            <asp:TextBox ID="txtSupplyPRno" runat="server" Width="200px" __designer:wfdid="w64" CssClass="text" SkinID="text" ReadOnly="True"></asp:TextBox> <strong>Date :</strong>
                                            <asp:TextBox ID="txtSupplycanvassdate" runat="server" Width="110px" __designer:wfdid="w65" CssClass="text" SkinID="text" ></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 20%" class="column_RightBold">Bid / Canvass Number : </td>
                                        <td style="width: 80%" class="text5">
                                            <asp:TextBox ID="txtSupplycanvass" runat="server" Width="200px" __designer:wfdid="w66" CssClass="text" SkinID="text" ReadOnly="True"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 20%" class="column_RightBold">Bidder Name : </td>
                                        <td style="width: 80%" class="text5">
                                            <asp:TextBox ID="txtSupplysupplier" runat="server" Width="320px" __designer:wfdid="w67" ReadOnly="True"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 20%" class="column_RightBold"></td>
                                        <td style="width: 80%" class="text5"></td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                    </tr>
                  
                                            <tr>
                                                <td style="width: 100%" class="DivTitle" align="center">SUPPLY LIST</td>
                                            </tr>
                                            <tr>
                                                <td style="width: 100%" align="center">
                                                    <asp:GridView Style="font-weight: normal" ID="grdSupply" runat="server" Width="95%" Font-Size="9pt" __designer:wfdid="w82" SkinID="GridViewAA" AutoGenerateColumns="False" EmptyDataText="No Data Found." ShowFooter="True">
                                                        <Columns>
                                                            <asp:BoundField DataField="Item_Desc" HeaderText="Description">
                                                                <ItemStyle HorizontalAlign="Left" Width="60%"></ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="qty" HeaderText="Quantity">
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
                                                    <asp:Button ID="btnAwardSupp" OnClick="btnAwardSupp_Click" runat="server" Width="200px" __designer:wfdid="w83" SkinID="ButtonImage" Text="AWARD" Enabled="False" OnClientClick="StartProgressBar();" ValidationGroup="1"></asp:Button><asp:Button ID="btnPreviewSupp" OnClick="btnPreviewSupp_Click" runat="server" Width="200px" __designer:wfdid="w84" SkinID="ButtonImage" Text="PREVIEW" Visible="False" Enabled="False" OnClientClick="StartProgressBar();"></asp:Button></td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </asp:View>
                            </asp:MultiView></td>
                    </tr>
                    <tr>
                        <td style="width: 10px"></td>
                        <td style="width: 1000px" align="center">
                            <asp:Button ID="btnNew" runat="server" Width="100px" __designer:wfdid="w85" SkinID="ButtonImage" Text="NEW" Visible="False"></asp:Button><asp:Button ID="bntOpen" runat="server" Width="100px" __designer:wfdid="w86" SkinID="ButtonImage" Text="OPEN" Visible="False"></asp:Button><cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" __designer:wfdid="w87" TargetControlID="btnSave" ConfirmText="Are you sure you want to save this transaction?">
                            </cc1:ConfirmButtonExtender>
                        </td>
                    </tr>
                            </table>
                            </td>
                          </tr>
                   

                </tbody>
            </table>
            <asp:Panel Style="border-top-width: 1px; border-left-width: 1px; border-left-color: #0033cc; border-bottom-width: 1px; border-bottom-color: #0033cc; border-top-color: #0033cc; background-color: transparent; text-align: center; border-right-width: 1px; border-right-color: #0033cc" ID="PanelProgress" runat="server" Width="109px" __designer:wfdid="w6">
                <img src="../../images/ajax-loader.gif" /></asp:Panel>
            <cc1:ModalPopupExtender ID="ProgressBarModalPopupExtender" runat="server" __designer:wfdid="w7" TargetControlID="ButtonProgress" BehaviorID="ProgressBarModalPopupExtender" BackgroundCssClass="modalBackground" PopupControlID="PanelProgress"></cc1:ModalPopupExtender>
            <asp:Button Style="border-top-style: none; border-right-style: none; border-left-style: none; background-color: transparent; border-bottom-style: none" ID="ButtonProgress" runat="server" Width="16px" __designer:wfdid="w8" Enabled="False"></asp:Button> 
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
