<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="t_DBM_APR.aspx.vb" EnableEventValidation="false"
    Inherits="procurement_t_DBM_APR" Title="DBM - AGENCY PROCUREMENT REQUEST" StylesheetTheme="SkinFile" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>


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
            <table style="width: 100%">
                <tbody>
                    <tr>
                        <td align="center" style="width: 10px"></td>
                        <td style="width: 1010px" align="center"></td>
                    </tr>
                    <tr>
                        <td align="center" style="width: 10px"></td>
                        <td style="width: 1010px" class="PageTitle" align="center">DBM - AGENCY PROCUREMENT REQUEST</td>
                    </tr>
                    <tr>
                        <td align="center" class="text4" style="width: 10px"></td>
                        <td style="width: 1010px" class="text4" align="center">Date :
                            <asp:TextBox ID="txtDate" runat="server" Width="100px" CssClass="txtboxinspection"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" style="width: 10px"></td>
                        <td style="width: 1010px" align="center">
                            <asp:GridView Style="font-weight: normal; text-align: justify" ID="grdAPR" runat="server" Width="600px" OnSelectedIndexChanged="grdAPR_SelectedIndexChanged" DataKeyNames="DBM_ID,Quarter,Year" EmptyDataText="No Data Found." SkinID="GridViewAA" AutoGenerateColumns="False" PageSize="4" Font-Size="9pt">
                                <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NextPreviousFirstLast" NextPageText="Next" PreviousPageText="Previous"></PagerSettings>

                                <EmptyDataRowStyle BorderColor="Gray" BorderStyle="Solid"></EmptyDataRowStyle>
                                <Columns>
                                    <asp:TemplateField>
                                        <EditItemTemplate>
                                            <asp:TextBox runat="server" ID="TextBox1"></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkView" OnClick="lnkView_Click" runat="server" CommandName="Select" Visible='<%# bind("isVisible") %>'>View</asp:LinkButton>
                                        </ItemTemplate>

                                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Year" HeaderText="Year">
                                        <ItemStyle HorizontalAlign="Center" Width="20%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Quarter" HeaderText="Quarter">
                                        <ItemStyle HorizontalAlign="Center" Width="20%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="TotalAmount" DataFormatString="{0:N}" HeaderText="Total Amount">
                                        <ItemStyle HorizontalAlign="Right" Width="45%"></ItemStyle>
                                    </asp:BoundField>
                                </Columns>

                                <FooterStyle BackColor="#2977DC"></FooterStyle>

                                <PagerStyle HorizontalAlign="Center" BorderColor="Gray" BorderStyle="None"></PagerStyle>

                                <SelectedRowStyle BorderColor="Transparent"></SelectedRowStyle>

                                <HeaderStyle BackColor="#2977DC" BorderColor="Transparent" BorderStyle="None" ForeColor="White"></HeaderStyle>

                                <EditRowStyle BorderColor="White"></EditRowStyle>
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" style="width: 10px"></td>
                        <td style="width: 1010px" class="DivTitle" align="center">LIST OF ITEMS</td>
                    </tr>
                    <tr>
                        <td align="center" style="width: 10px"></td>
                        <td style="width: 1010px" align="center">
                            <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                <ContentTemplate>
                                    <asp:Panel ID="Panel1" runat="server" Width="990px" CssClass="PanelSize" ScrollBars="Vertical">
                                        <asp:GridView Style="font-weight: normal; text-align: justify" ID="grdAPRItems" runat="server" Width="100%" EmptyDataText="No Data Found." SkinID="GridViewAA" AutoGenerateColumns="False" PageSize="15" BackColor="White" ShowFooter="True" Font-Size="9pt">
                                            <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NextPreviousFirstLast" NextPageText="Next" PreviousPageText="Previous"></PagerSettings>

                                            <EmptyDataRowStyle BorderColor="Gray" BorderStyle="Solid"></EmptyDataRowStyle>
                                            <Columns>
                                                <asp:BoundField DataField="Item_Desc" HeaderText="Description">
                                                    <ItemStyle HorizontalAlign="Left" Width="40%"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Unit" HeaderText="Unit">
                                                    <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Qty" HeaderText="Total Qty">
                                                    <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="Unit Price">
                                                    <EditItemTemplate>
                                                        <asp:TextBox runat="server" Text='<%# Bind("UnitPrice") %>' ID="TextBox3"></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtUnitPrice" runat="server" Width="80%" CssClass="txtboxAmount" Text='<%# Bind("UnitPrice", "{0:N}") %>' OnTextChanged="txtUnitPrice_TextChanged" AutoPostBack="True" Visible='<%# bind("isVisible") %>'></asp:TextBox>
                                                    </ItemTemplate>

                                                    <ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Available Qty">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("AvailableQty") %>'></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <strong>TOTAL:</strong>
                                                    </FooterTemplate>
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtAvailableQty" runat="server" Width="80%" CssClass="txtboxAmount" Text='<%# Bind("Qty") %>' OnTextChanged="txtAvailableQty_TextChanged" AutoPostBack="True" Visible='<%# bind("isVisible") %>'></asp:TextBox>
                                                    </ItemTemplate>

                                                    <FooterStyle HorizontalAlign="Right"></FooterStyle>

                                                    <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Total Cost">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("TotalCost") %>'></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:Label ID="lblTotalAmount" runat="server" Font-Bold="True"></asp:Label>
                                                    </FooterTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblTotalCost" runat="server" Text='<%# Bind("TotalCost", "{0:N}") %>'></asp:Label>
                                                    </ItemTemplate>

                                                    <FooterStyle HorizontalAlign="Right"></FooterStyle>

                                                    <ItemStyle HorizontalAlign="Right" Width="15%"></ItemStyle>
                                                </asp:TemplateField>
                                            </Columns>

                                            <FooterStyle BackColor="#2977DC"></FooterStyle>

                                            <PagerStyle HorizontalAlign="Center" BorderColor="Gray" BorderStyle="None"></PagerStyle>

                                            <SelectedRowStyle BorderColor="Transparent"></SelectedRowStyle>

                                            <HeaderStyle BackColor="#2977DC" BorderColor="Transparent" BorderStyle="None" ForeColor="White"></HeaderStyle>

                                            <EditRowStyle BorderColor="White"></EditRowStyle>
                                        </asp:GridView>
                                    </asp:Panel>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" style="width: 10px"></td>
                        <td style="width: 1010px" align="center"></td>
                    </tr>
                    <tr>
                        <td align="center" style="width: 10px"></td>
                        <td style="width: 1010px" class="DivTitle" align="center">SIGNATORIES</td>
                    </tr>
                    <tr>
                        <td align="center" style="width: 10px"></td>
                        <td style="width: 1010px" align="center">
                            <table style="width: 80%">
                                <tbody>
                                    <tr>
                                        <td style="width: 30%" class="column_LeftBold">Agency Property / Supply Officer :</td>
                                        <td style="width: 70%" class="text5">
                                            <asp:TextBox ID="txtGSO" runat="server" Width="270px" CssClass="txtboxinspection" ReadOnly="True"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 30%" class="column_LeftBold">Agency Head Treasurer :</td>
                                        <td style="width: 70%" class="text5">
                                            <asp:TextBox ID="txtAccounting" runat="server" Width="270px" CssClass="txtboxinspection" ReadOnly="True"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 30%" class="column_LeftBold">Agency Head / Authorized Signature :</td>
                                        <td style="width: 70%" class="text5">
                                            <asp:TextBox ID="txtMayor" runat="server" Width="270px" CssClass="txtboxinspection" ReadOnly="True"></asp:TextBox></td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" style="width: 10px"></td>
                        <td style="width: 1010px" align="center">
                            <asp:Button ID="btnSave" OnClick="btnSave_Click" runat="server" Width="200px" OnClientClick="StartProgressBar();" Enabled="False" Text="SAVE"></asp:Button><asp:Button ID="btnPreview" OnClick="btnPreview_Click" runat="server" Width="200px" OnClientClick="StartProgressBar();" Enabled="False" Text="PREVIEW"></asp:Button></td>
                    </tr>
                    <tr>
                        <td align="center" style="width: 10px"></td>
                        <td style="width: 1010px" align="center"></td>
                    </tr>
                    <tr>
                        <td align="center" style="width: 10px"></td>
                        <td style="width: 1010px" class="DivTitle" align="center">AGENCY PROCUREMENT REQUEST</td>
                    </tr>
                    <tr>
                        <td align="center" style="width: 10px"></td>
                        <td style="width: 1010px" align="center">
                            <asp:GridView Style="font-weight: normal; text-align: justify" ID="grdAPRList" runat="server" Width="750px" OnSelectedIndexChanged="grdAPRList_SelectedIndexChanged" DataKeyNames="DBM_ID,Quarter,Year" EmptyDataText="No Data Found." SkinID="GridViewAA" AutoGenerateColumns="False" PageSize="4" Font-Size="9pt">
                                <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NextPreviousFirstLast" NextPageText="Next" PreviousPageText="Previous"></PagerSettings>
                                <Columns>
                                    <asp:TemplateField>
                                        <EditItemTemplate>
                                            <asp:TextBox runat="server" ID="TextBox1"></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkView" runat="server" CommandName="Select" OnClick="lnkView_Click1">Preview</asp:LinkButton>
                                        </ItemTemplate>

                                        <ItemStyle HorizontalAlign="Center" Width="100px"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Year" HeaderText="Year">
                                        <ItemStyle HorizontalAlign="Center" Width="150px"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Quarter" HeaderText="Quarter">
                                        <ItemStyle HorizontalAlign="Center" Width="150px"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="NoItems" HeaderText="No. of Items">
                                        <ItemStyle HorizontalAlign="Center" Width="150px"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="TotalAmount" DataFormatString="{0:N}" HeaderText="Total Amount">
                                        <ItemStyle HorizontalAlign="Right" Width="200px"></ItemStyle>
                                    </asp:BoundField>
                                </Columns>

                                <FooterStyle BackColor="#2977DC"></FooterStyle>

                                <PagerStyle HorizontalAlign="Center" BorderColor="Gray" BorderStyle="None"></PagerStyle>

                                <SelectedRowStyle BorderColor="Transparent"></SelectedRowStyle>

                                <HeaderStyle BackColor="#2977DC" BorderColor="Transparent" BorderStyle="None" ForeColor="White"></HeaderStyle>

                                <EditRowStyle BorderColor="White"></EditRowStyle>
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" style="width: 10px"></td>
                        <td style="width: 1010px" align="center">
                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDate"></cc1:CalendarExtender>
                        </td>
                    </tr>
                </tbody>
            </table>

            <asp:Panel ID="Panel4" runat="server" Width="800px" Height="528px" BackImageUrl ="~/images/POPUP/PopupBG.png">
                <table style="width: 100%"  >
                    <tr style="width: 100%" align="center">
                        <td></td>
                    </tr>

                    <tr align="center" style="width: 100%">
                        <td>
                            <asp:GridView ID="grdItems" runat="server" AllowPaging="True" AutoGenerateColumns="False" BackColor="White" EmptyDataText="No Data Found." Font-Size="9pt" OnPageIndexChanging="grdItems_PageIndexChanging" SkinID="GridViewAA" Style="font-weight: normal; text-align: justify" Width="95%" PageSize="12">
                                <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NextPreviousFirstLast" NextPageText="Next" PreviousPageText="Previous" />
                                <EmptyDataRowStyle BorderColor="Gray" BorderStyle="Solid" />
                                <Columns>
                                    <asp:TemplateField>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="True" OnCheckedChanged="CheckBox1_CheckedChanged" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="5%" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Item_Desc" HeaderText="Description">
                                    <ItemStyle HorizontalAlign="Left" Width="55%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Unit" HeaderText="Unit">
                                    <ItemStyle HorizontalAlign="Center" Width="15%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Qty" HeaderText="Quantity">
                                    <ItemStyle HorizontalAlign="Center" Width="10%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="UnitPrice" DataFormatString="{0:N}" HeaderText="Unit Price">
                                    <ItemStyle HorizontalAlign="Right" Width="15%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ID" HeaderText="ID" />
                                </Columns>
                                <FooterStyle BackColor="#2977DC" />
                                <PagerStyle BorderStyle="None" HorizontalAlign="Center" />
                                <SelectedRowStyle BorderColor="Transparent" />
                                <HeaderStyle BackColor="#2977DC" BorderColor="Transparent" BorderStyle="None" ForeColor="White" />
                                <EditRowStyle BorderColor="White" />
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr align="center" style="width: 100%">
                        <td>
                            <asp:Button ID="btnLoad" runat="server" OnClick="btnLoad_Click" OnClientClick="StartProgressBar();" Text="LOAD" Width="100px" />
                            &nbsp;<asp:Button ID="btnCancel" runat="server" Text="CANCEL" Width="100px" />
                        </td>
                    </tr>
                    <tr align="center" style="width: 100%">
                        <td><asp:Label ID="Label1" runat="server"></asp:Label>
                            <cc1:ModalPopupExtender ID="ModalPopupExtender2" runat="server" BackgroundCssClass="modalBackground" PopupControlID="Panel4" TargetControlID="Label1">
                            </cc1:ModalPopupExtender>
                        </td>
                    </tr>

                </table>

            </asp:Panel>




            <asp:Panel Style="border-top-width: 1px; border-left-width: 1px; border-left-color: #0033cc; border-bottom-width: 1px; border-bottom-color: #0033cc; border-top-color: #0033cc; background-color: transparent; text-align: center; border-right-width: 1px; border-right-color: #0033cc" ID="PanelProgress" runat="server" Width="109px">
                <img src="../images/ajax-loader.gif" />
            </asp:Panel>
            <cc1:ModalPopupExtender ID="ProgressBarModalPopupExtender" runat="server" TargetControlID="ButtonProgress" BackgroundCssClass="modalBackground" PopupControlID="PanelProgress" BehaviorID="ProgressBarModalPopupExtender"></cc1:ModalPopupExtender>
            <asp:Button Style="border-top-style: none; border-right-style: none; border-left-style: none; background-color: transparent; border-bottom-style: none" ID="ButtonProgress" runat="server" Width="16px" Enabled="False"></asp:Button>&nbsp;&nbsp; 
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

