<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="t_PR_DBM.aspx.vb"
    Inherits="procurement_t_PR_DBM" Title="PURCHASE REQUEST FOR DBM" EnableEventValidation="false" StylesheetTheme="SkinFile" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>


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
            <table style="width: 1010px">
                <tbody>
                    <tr>
                        <td style="width: 1010px">
                            <table style="width: 1000px">
                                <tbody>
                                    <tr>
                                        <td style="width: 1000px" class="PageTitle" align="center">CREATE PR FOR DBM</td>
                                    </tr>
                                    <tr>
                                        <td style="width: 1000px" align="center">
                                            <table style="width: 1000px">
                                                <tbody>
                                                    <tr>
                                                        <td style="width: 100px; height: 24px" class="column_LeftBold"></td>
                                                        <td style="width: 100px; height: 24px" class="column_LeftBold">Year</td>
                                                        <td style="width: 5px; height: 24px" class="column_LeftBold">:</td>
                                                        <td style="width: 200px" class="text5">
                                                            <asp:DropDownList ID="ddYear" runat="server" Width="150px" AutoPostBack="True" CssClass="txtboxinspection" OnSelectedIndexChanged="ddYear_SelectedIndexChanged"></asp:DropDownList></td>
                                                        <td style="width: 595px" class="text5" rowspan="2">
                                                            <asp:Button ID="btnSearch" OnClick="btnSearch_Click" runat="server" Width="200px" Height="30px" Text="Search" Enabled="False" OnClientClick="StartProgressBar();"></asp:Button></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100px" class="column_LeftBold"></td>
                                                        <td style="width: 100px" class="column_LeftBold">Quarter</td>
                                                        <td style="width: 5px" class="column_LeftBold">:</td>
                                                        <td style="width: 200px" class="text5">
                                                            <asp:DropDownList ID="ddQuarter" runat="server" Width="150px" AutoPostBack="True" CssClass="txtboxinspection" OnSelectedIndexChanged="ddQuarter_SelectedIndexChanged">
                                                                <asp:ListItem Value="1">1st Quarter</asp:ListItem>
                                                                <asp:ListItem Value="2">2nd Quarter</asp:ListItem>
                                                                <asp:ListItem Value="3">3rd Quarter</asp:ListItem>
                                                                <asp:ListItem Value="4">4th Quarter</asp:ListItem>
                                                            </asp:DropDownList></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100px" class="column_LeftBold"></td>
                                                        <td style="width: 100px" class="column_LeftBold"></td>
                                                        <td style="width: 5px" class="column_LeftBold"></td>
                                                        <td style="width: 200px" class="text5"></td>
                                                        <td style="width: 595px" class="text5"></td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 1000px" align="center">
                                            <asp:GridView Style="font-weight: normal; text-align: justify" ID="grdDBMList" runat="server" Width="60%" OnSelectedIndexChanged="grdDBMList_SelectedIndexChanged" SkinID="GridViewAA" PageSize="4" DataKeyNames="Year,Quarter,DBM_ID" EmptyDataText="No Data Found" Font-Size="9pt">
                                                <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NextPreviousFirstLast" NextPageText="Next" PreviousPageText="Previous"></PagerSettings>
                                                <Columns>
                                                    <asp:TemplateField HeaderText="View">
                                                        <EditItemTemplate>
                                                            <asp:TextBox runat="server" ID="TextBox1"></asp:TextBox>
                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkView" OnClick="lnkView_Click" runat="server" CommandName="Select" Visible='<%# bind("isVisible") %>'>View</asp:LinkButton>
                                                        </ItemTemplate>

                                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="Year" HeaderText="Year">
                                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Quarter" HeaderText="Quarter">
                                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="TotalAmount" DataFormatString="{0:N}" HeaderText="Total Amount">
                                                        <ItemStyle HorizontalAlign="Right"></ItemStyle>
                                                    </asp:BoundField>
                                                </Columns>

                                                <FooterStyle BackColor="#669933"></FooterStyle>

                                                <PagerStyle HorizontalAlign="Center" BorderColor="Gray" BorderStyle="None"></PagerStyle>

                                                <SelectedRowStyle BorderColor="Transparent"></SelectedRowStyle>
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 1000px" class="DivTitle" align="center">LIST OF ITEMS</td>
                                    </tr>
                                    <tr>
                                        <td style="width: 1000px" align="center">
                                            <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                                <ContentTemplate>
                                                    <asp:Panel ID="Panel2" runat="server" Width="990px" CssClass="PanelSize" ScrollBars="Vertical">
                                                        <asp:GridView Style="font-weight: normal; text-align: justify" ID="grdItems" runat="server" Width="100%" EmptyDataText="No Data Found." PageSize="15" SkinID="GridViewAA" Font-Size="9pt">
                                                            <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NextPreviousFirstLast" NextPageText="Next" PreviousPageText="Previous"></PagerSettings>

                                                            <EmptyDataRowStyle BorderColor="Gray" BorderStyle="Solid"></EmptyDataRowStyle>
                                                            <Columns>
                                                                <asp:TemplateField>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox runat="server" ID="TextBox2"></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox ID="CheckBox1" runat="server"></asp:CheckBox>
                                                                    </ItemTemplate>

                                                                    <ItemStyle HorizontalAlign="Center" Width="2%"></ItemStyle>
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="Item_Desc" HeaderText="Description">
                                                                    <ItemStyle HorizontalAlign="Left" Width="50%"></ItemStyle>
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="Unit" HeaderText="Unit">
                                                                    <ItemStyle HorizontalAlign="Center" Width="12%"></ItemStyle>
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="Qty" HeaderText="Quantity">
                                                                    <ItemStyle HorizontalAlign="Right" Width="12%"></ItemStyle>
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="UnitCost" DataFormatString="{0:N}" HeaderText="Unit Cost">
                                                                    <ItemStyle HorizontalAlign="Right" Width="12%"></ItemStyle>
                                                                </asp:BoundField>
                                                                <asp:TemplateField HeaderText="Total Cost">
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox runat="server" Text='<%# Bind("TotalCost") %>' ID="TextBox1"></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblTotalCost" runat="server" Text='<%# Bind("TotalCost", "{0:N}") %>'></asp:Label>
                                                                    </ItemTemplate>

                                                                    <ItemStyle HorizontalAlign="Right" Width="12%"></ItemStyle>
                                                                </asp:TemplateField>
                                                            </Columns>

                                                            <FooterStyle BackColor="#669933"></FooterStyle>

                                                            <PagerStyle HorizontalAlign="Center" BorderColor="Gray" BorderStyle="None"></PagerStyle>

                                                            <HeaderStyle BorderColor="Transparent" BorderStyle="Dotted"></HeaderStyle>

                                                            <EditRowStyle BorderColor="White"></EditRowStyle>
                                                        </asp:GridView>
                                                    </asp:Panel>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 1000px" align="center">
                                            <table style="width: 100%">
                                                <tbody>
                                                    <tr>
                                                        <td style="width: 78%" class="column_RightBold">TOTAL (PhP) : </td>
                                                        <td style="width: 20%" class="column_RightBold">
                                                            <asp:TextBox ID="txtTotalAmount" runat="server" Width="95%" Font-Bold="True" CssClass="txtboxAmount" ReadOnly="True"></asp:TextBox></td>
                                                        <td style="width: 2%" class="column_RightBold"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 78%" class="column_RightBold">
                                                            <table style="width: 100%">
                                                                <tbody>
                                                                    <tr>
                                                                        <td style="width: 20%" class="column_RightBold">Requested By :</td>
                                                                        <td style="width: 80%" class="text5">
                                                                            <asp:DropDownList ID="ddRequestedBy" runat="server" Width="450px" AutoPostBack="True" CssClass="txboxinspection" OnSelectedIndexChanged="ddRequestedBy_SelectedIndexChanged"></asp:DropDownList></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 20%" class="column_RightBold">Checked By : </td>
                                                                        <td style="width: 80%" class="text5">
                                                                            <asp:DropDownList ID="ddCheckBy" runat="server" Width="450px" AutoPostBack="True" CssClass="txboxinspection"></asp:DropDownList></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 20%" class="column_RightBold">Noted By :</td>
                                                                        <td style="width: 80%" class="text5">
                                                                            <asp:DropDownList ID="ddNotedBy" runat="server" Width="450px" AutoPostBack="True" CssClass="txboxinspection"></asp:DropDownList></td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>
                                                        </td>
                                                        <td style="width: 20%" class="column_RightBold"></td>
                                                        <td style="width: 2%" class="column_RightBold"></td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 1000px" align="center"><asp:Button ID="btnCreatePR" OnClick="btnCreatePR_Click" runat="server" Width="200px" Text="Create Purchase Request" Enabled="False" OnClientClick="StartProgressBar();"></asp:Button>
                                            <asp:Button ID="btnPreview" OnClick="btnPreview_Click" runat="server" Width="200px" Text="Preview" Enabled="False"></asp:Button></td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                    </tr>
                </tbody>
            </table>
            <asp:Panel Style="border-top-width: 1px; border-left-width: 1px; border-left-color: #0033cc; border-bottom-width: 1px; border-bottom-color: #0033cc; border-top-color: #0033cc; position: relative; background-color: transparent; text-align: center; border-right-width: 1px; border-right-color: #0033cc" ID="PanelProgress" runat="server" Width="109px">
                <img src="../images/ajax-loader.gif" />
            </asp:Panel>
            <cc1:ModalPopupExtender ID="ProgressBarModalPopupExtender" runat="server" TargetControlID="ButtonProgress" PopupControlID="PanelProgress" BehaviorID="ProgressBarModalPopupExtender" BackgroundCssClass="modalBackground"></cc1:ModalPopupExtender>
            <asp:Button Style="border-top-style: none; border-right-style: none; border-left-style: none; position: relative; background-color: transparent; border-bottom-style: none" ID="ButtonProgress" runat="server" Width="16px" Enabled="False"></asp:Button>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

