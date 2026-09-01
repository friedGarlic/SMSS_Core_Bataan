<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="t_Agency2Agency.aspx.vb"
    Inherits="bidding_t_Agency2Agency" Title="Agency to Agency" StylesheetTheme="SkinFile" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="upEmployeeDetail" runat="server">
        <ContentTemplate>
            <table style="width: 1010px">
                <tbody>
                    <tr>
                        <td style="width: 1010px">
                            <table style="width: 1000px">
                                <tbody>
                                    <tr>
                                        <td style="width: 1000px">
                                            <table class="PageTitle" __designer:dtid="3659174697238533">
                                                <tbody>
                                                    <tr __designer:dtid="3659174697238534">
                                                        <td style="width: 1000px" __designer:dtid="3659174697238535">AGENCY TO AGENCY</td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 1000px" class="column_RightBold">Date :&nbsp;<asp:TextBox ID="txtDate" runat="server" Width="100px" ReadOnly="True" CssClass="txtboxinspection" __designer:wfdid="w1"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 1000px">
                                            <asp:GridView Style="font-weight: normal; text-align: justify" ID="grdAgency" runat="server" Width="100%" __designer:wfdid="w2" SkinID="GridViewAA" OnSelectedIndexChanged="grdDirectContract_SelectedIndexChanged" AutoGenerateColumns="False" PageSize="8" DataKeyNames="prhdr_id">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="PR Number" ShowHeader="False">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" Text='<%# bind("pr_no") %>' CommandName="Select" Font-Underline="False" __designer:wfdid="w48"></asp:LinkButton>
                                                        </ItemTemplate>

                                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="OBR_No" HeaderText="OBR Number">
                                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="ABC" DataFormatString="{0:N}" HeaderText="ABC">
                                                        <ItemStyle HorizontalAlign="Right"></ItemStyle>
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="rc_name" HeaderText="Department">
                                                        <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Function_Desc" HeaderText="Function">
                                                        <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="DateApproved" DataFormatString="{0:d}" HeaderText="Date Approved">
                                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    </asp:BoundField>
                                                </Columns>

                                                <FooterStyle BackColor="#2977DC"></FooterStyle>

                                                <HeaderStyle BackColor="#2977DC" ForeColor="White"></HeaderStyle>
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 1000px" class="DivTitle">ITEMS</td>
                                    </tr>
                                    <tr>
                                        <td style="width: 1000px">
                                            <asp:Panel ID="Panel1" runat="server" Width="1000px" CssClass="PanelSize" __designer:wfdid="w13" ScrollBars="Vertical">
                                                <asp:GridView Style="font-weight: normal" ID="grdAItems" runat="server" Width="98%" __designer:wfdid="w14" SkinID="GridViewAA" PageSize="5" ShowFooter="True" EmptyDataText="No Data Found">
                                                    <Columns>
                                                        <asp:TemplateField>
                                                            <EditItemTemplate>
                                                                <asp:TextBox runat="server" ID="TextBox2"></asp:TextBox>
                                                            </EditItemTemplate>
                                                            <HeaderTemplate>
                                                                <asp:CheckBox ID="cbALL" runat="server" __designer:wfdid="w29" Enabled="False" OnCheckedChanged="cbALL_CheckedChanged"></asp:CheckBox>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="CheckBox1" runat="server" __designer:wfdid="w15" OnCheckedChanged="CheckBox1_CheckedChanged" Enabled="False" AutoPostBack="True"></asp:CheckBox>
                                                            </ItemTemplate>

                                                            <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <EditItemTemplate>
                                                                &nbsp;
                                                            </EditItemTemplate>
                                                            <HeaderTemplate>
                                                                <table class="text" cellspacing="0" cellpadding="0" border="0">
                                                                    <tbody>
                                                                        <tr>
                                                                            <td style="width: 100px; text-align: center">Description</td>
                                                                        </tr>
                                                                    </tbody>
                                                                </table>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label Style="text-align: left" ID="lbldesc" runat="server" CssClass="text" Text='<%# Bind("Item_Desc") %>' __designer:wfdid="w76"></asp:Label>
                                                            </ItemTemplate>

                                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                            <ItemStyle HorizontalAlign="Left" Width="45%"></ItemStyle>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <EditItemTemplate>
                                                                &nbsp;
                                                            </EditItemTemplate>
                                                            <HeaderTemplate>
                                                                <table class="text" cellspacing="0" cellpadding="0" border="0">
                                                                    <tbody>
                                                                        <tr>
                                                                            <td>Unit</td>
                                                                        </tr>
                                                                    </tbody>
                                                                </table>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblunit" runat="server" CssClass="text" Text='<%# Bind("Unit") %>' __designer:wfdid="w53"></asp:Label>
                                                            </ItemTemplate>

                                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                            <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Quantity">
                                                            <EditItemTemplate>
                                                                <asp:TextBox runat="server" Text='<%# Bind("qty") %>' ID="TextBox1"></asp:TextBox>
                                                            </EditItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblqty" runat="server" __designer:wfdid="w31" Text='<%# Bind("qty") %>'></asp:Label>
                                                            </ItemTemplate>

                                                            <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <EditItemTemplate>
                                                                &nbsp;
                                                            </EditItemTemplate>
                                                            <FooterTemplate>
                                                                TOTAL
                                                            </FooterTemplate>
                                                            <HeaderTemplate>
                                                                <table class="text" cellspacing="0" cellpadding="0" border="0">
                                                                    <tbody>
                                                                        <tr>
                                                                            <td>Price</td>
                                                                        </tr>
                                                                    </tbody>
                                                                </table>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:TextBox Style="text-align: right" ID="txtCost" runat="server" Width="100px" __designer:wfdid="w17" Text='<%# Bind("cost", "{0:N}") %>' AutoPostBack="True" OnTextChanged="txtCost_TextChanged"></asp:TextBox><cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtCost" __designer:wfdid="w18" ValidChars="0123456789.,"></cc1:FilteredTextBoxExtender>
                                                            </ItemTemplate>

                                                            <FooterStyle HorizontalAlign="Right"></FooterStyle>

                                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                            <ItemStyle HorizontalAlign="Right" Width="15%"></ItemStyle>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <EditItemTemplate>
                                                                <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("total") %>' __designer:wfdid="w60"></asp:TextBox>
                                                            </EditItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:Label Style="text-align: right" ID="lbltotal" runat="server" Width="100px" CssClass="text" Text='<%# Bind("total", "{0:N}") %>' __designer:wfdid="w71"></asp:Label>
                                                            </FooterTemplate>
                                                            <HeaderTemplate>
                                                                <table class="text" cellspacing="0" cellpadding="0" border="0">
                                                                    <tbody>
                                                                        <tr>
                                                                            <td>Total Amount</td>
                                                                        </tr>
                                                                    </tbody>
                                                                </table>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label Style="text-align: right" ID="lbltotalx" runat="server" Width="100px" __designer:wfdid="w84" Text='<%# bind("total","{0:N}") %>'></asp:Label>
                                                            </ItemTemplate>

                                                            <FooterStyle HorizontalAlign="Right" Font-Bold="False"></FooterStyle>

                                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                            <ItemStyle HorizontalAlign="Right" Width="15%"></ItemStyle>
                                                        </asp:TemplateField>
                                                    </Columns>

                                                    <FooterStyle BackColor="#2977DC"></FooterStyle>

                                                    <HeaderStyle BackColor="#2977DC" Font-Names="Arial" Font-Size="8pt" ForeColor="White"></HeaderStyle>
                                                </asp:GridView>
                                            </asp:Panel>
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 1000px">
                                            <asp:Panel ID="Panel5" runat="server" Width="100%" CssClass="PanelSize" __designer:wfdid="w5" GroupingText="SUPPLIERS">
                                                <table style="width: 100%">
                                                    <tbody>
                                                        <tr>
                                                            <td style="width: 20%; text-align: right" class="DivTitle">Supplier :</td>
                                                            <td style="width: 50%" class="DivTitle">
                                                                <asp:DropDownList ID="ddSupplier" runat="server" Width="98%" OnSelectedIndexChanged="ddSupplier_SelectedIndexChanged" __designer:wfdid="w6" Enabled="False" AutoPostBack="True"></asp:DropDownList></td>
                                                            <td style="width: 40%" class="DivTitle">
                                                                <asp:Button ID="btnsupplier" OnClick="btnsupplier_Click" runat="server" Width="200px" __designer:wfdid="w7" Text="SAVE" Enabled="False" Height="30px" OnClientClick="StartProgressBar();"></asp:Button></td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                            <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" __designer:wfdid="w11" ConfirmText="Are you sure you want to save  this transaction?" TargetControlID="btnsupplier"></cc1:ConfirmButtonExtender>
                            <cc1:CalendarExtender ID="CalendarExtender5" runat="server" __designer:wfdid="w12" TargetControlID="txtDate" PopupButtonID="ImageButton2" Enabled="True"></cc1:CalendarExtender>
                        </td>
                    </tr>
                </tbody>
            </table>
            <asp:Panel Style="border-top-width: 1px; border-left-width: 1px; border-left-color: #0033cc; border-bottom-width: 1px; border-bottom-color: #0033cc; border-top-color: #0033cc; background-color: transparent; text-align: center; border-right-width: 1px; border-right-color: #0033cc" ID="PanelProgress" runat="server" Width="109px" __designer:wfdid="w8">
                <img src="../images/ajax-loader.gif" />
            </asp:Panel>
            <cc1:ModalPopupExtender ID="ProgressBarModalPopupExtender" runat="server" __designer:wfdid="w9" TargetControlID="ButtonProgress" BackgroundCssClass="modalBackground" BehaviorID="ProgressBarModalPopupExtender" PopupControlID="PanelProgress"></cc1:ModalPopupExtender>
            <asp:Button Style="border-top-style: none; border-right-style: none; border-left-style: none; background-color: transparent; border-bottom-style: none" ID="ButtonProgress" runat="server" Width="16px" __designer:wfdid="w10" Enabled="False"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp; 
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

