<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" EnableEventValidation="false"
    CodeFile="t_encoding_supplies.aspx.vb" Inherits="Inventory_t_encoding_supplies"
    Title="Encoding of Supplies" StylesheetTheme="SkinFile" %>

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

            <div>
                <table width="1020px">
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="PageTitle">MANUAL ENCODING OF SUPPLIES
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="right">
                            <span class="column_RightBold">Date :</span>
                            &nbsp;<asp:TextBox ID="txtDate" runat="server" Width="100px"  CssClass="txtbox_Date"></asp:TextBox>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <span class="column_RightBold">General Account :</span>
                            &nbsp;<asp:DropDownList ID="ddGA" runat="server" Width="250px" CssClass="drpdownCSS" AutoPostBack="True" OnSelectedIndexChanged="ddGA_SelectedIndexChanged">
                            </asp:DropDownList>
                            &nbsp;<asp:DropDownList ID="ddSearch" runat="server" Width="120px" CssClass="drpdownCSS">
                                <asp:ListItem Selected="True" Value="1">Description</asp:ListItem>
                                <asp:ListItem Value="2">Item Code</asp:ListItem>
                            </asp:DropDownList>
                            &nbsp;<asp:TextBox ID="txtSearch" runat="server" Width="200px" CssClass="txtbox_Var"></asp:TextBox>
                            &nbsp;<asp:Button ID="btnSearch" OnClick="btnSearch_Click" runat="server" Width="150px" CssClass="CSButton" OnClientClick="StartProgressBar();" Text="Search" Enabled="False"></asp:Button>

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
                            <asp:GridView ID="grdGoods" runat="server" Width="95%" EmptyDataText="No Data Found" SkinID="GridViewAA" OnPageIndexChanging="grdGoods_PageIndexChanging"
                                AllowPaging="True" AutoGenerateColumns="False" PageSize="10">
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="CheckBox1" runat="server" Visible='<%# Bind("isVisible") %>'></asp:CheckBox>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Item_Code" HeaderText="Item Code">
                                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Description">
                                        <ItemTemplate>
                                            <asp:Label ID="lblItem_Desc" runat="server" Text='<%# Bind("Item_Desc") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="65%"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Unit">
                                        <ItemTemplate>
                                            <asp:Label ID="lblUnit" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                                        </ItemTemplate>

                                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Price">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPrice" runat="server" Text='<%# Bind("price", "{0:N}") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Right" Width="10%"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Item_ID" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblItem_ID" runat="server" Text='<%# Bind("Item_ID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Unit_ID" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblUnit_ID" runat="server" Text='<%# Bind("Unit_ID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>

                                <HeaderStyle Font-Names="Arial" Font-Size="8pt"></HeaderStyle>
                            </asp:GridView>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:Button ID="btnAddGoods" OnClick="btnAddGoods_Click" runat="server" Width="150px" CssClass="CSButton" Text="ADD GOODS"></asp:Button>
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
                        <td style="width: 98%" class="DivTitle">Goods For Inventory
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                <ContentTemplate>
                                    <asp:Panel ID="Panel1" runat="server" Width="98%" CssClass="PanelSize" ScrollBars="Vertical" HorizontalAlign="Center">
                                        <asp:GridView ID="grdItems" runat="server" Width="100%" EmptyDataText="No Data Found" SkinID="GridViewAA"
                                            AutoGenerateColumns="False" PageSize="5" ShowFooter="True">
                                            <Columns>
                                                <asp:BoundField DataField="Item_Desc" HeaderText="Description">
                                                    <ItemStyle HorizontalAlign="Left" Width="44%"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Unit" HeaderText="Unit">
                                                    <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="price" DataFormatString="{0:N}" HeaderText="Price">
                                                    <ItemStyle HorizontalAlign="Right" Width="10%"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="PO Price">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtPOPrice" runat="server" Width="98%" CssClass="txtbox_Amt" AutoPostBack="True" Text='<%#Bind("price") %>' OnTextChanged="txtPOPrice_TextChanged"></asp:TextBox>
                                                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtPOPrice" ValidChars="0123456789.,"></cc1:FilteredTextBoxExtender>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" Width="8%"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Quantity">
                                                    <FooterTemplate>
                                                        <strong>TOTAL :</strong>
                                                    </FooterTemplate>
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtPOQty" runat="server" Width="98%" CssClass="txtbox_Amt" AutoPostBack="True" OnTextChanged="txtPOQty_TextChanged" Text="0"></asp:TextBox>
                                                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtPOQty" ValidChars="0123456789.,"></cc1:FilteredTextBoxExtender>
                                                    </ItemTemplate>
                                                    <FooterStyle HorizontalAlign="Right"></FooterStyle>
                                                    <ItemStyle HorizontalAlign="Center" Width="8%"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Total">
                                                    <FooterTemplate>
                                                        <asp:Label ID="lblTotalAmount" runat="server" Font-Bold="True" Text="0.00"></asp:Label>
                                                    </FooterTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblTotal" runat="server" Text="0.00"></asp:Label>
                                                    </ItemTemplate>
                                                    <FooterStyle HorizontalAlign="Right"></FooterStyle>
                                                    <ItemStyle HorizontalAlign="Right" Width="10%"></ItemStyle>
                                                </asp:TemplateField>
                                            </Columns>

                                            <HeaderStyle Font-Names="Arial"></HeaderStyle>
                                        </asp:GridView>
                                    </asp:Panel>
                                </ContentTemplate>
                            </asp:UpdatePanel>
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
                        <td style="width: 98%" class="DivTitle">Details
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <table width="98%">
                                <tr>
                                    <td style="width: 12%" class="column_RightBold">Department :</td>
                                    <td style="width: 35%" align="left">
                                        <asp:DropDownList ID="ddDepartment" runat="server" Width="98%" CssClass="drpdownCSS" AutoPostBack="True" OnSelectedIndexChanged="ddDepartment_SelectedIndexChanged"></asp:DropDownList>
                                    </td>
                                    <td style="width: 12%" class="column_RightBold">PO Number :</td>
                                    <td style="width: 41%" align="left">
                                        <asp:TextBox ID="txtPONumber" runat="server" Width="150px" CssClass="txtbox_Var"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 12%" class="column_RightBold">Function :</td>
                                    <td style="width: 35%" align="left">
                                        <asp:DropDownList ID="ddFunction" runat="server" Width="98%" CssClass="drpdownCSS" AutoPostBack="True" OnSelectedIndexChanged="ddFunction_SelectedIndexChanged" Enabled="False"></asp:DropDownList>
                                    </td>
                                    <td style="width: 12%" class="column_RightBold">Date Delivered :</td>
                                    <td style="width: 41%" align="left">
                                        <asp:TextBox ID="txtDeliveredDate" runat="server" Width="100px" CssClass="txtbox_Date"></asp:TextBox>
                                        &nbsp;<asp:ImageButton ID="ImageButton1" runat="server" Width="20px" ImageUrl="~/images/Calendar_scheduleHS.png" Height="15px"></asp:ImageButton>

                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 12%" class="column_RightBold">Requested By :</td>
                                    <td style="width: 35%" align="left">
                                        <asp:DropDownList ID="ddPRrequestedby" runat="server" Width="98%" CssClass="drpdownCSS" AutoPostBack="True" OnSelectedIndexChanged="ddPRrequestedby_SelectedIndexChanged" Enabled="False"></asp:DropDownList>
                                    </td>
                                    <td style="width: 12%" class="column_RightBold">Supplier :</td>
                                    <td style="width: 41%" align="left">
                                        <asp:DropDownList ID="ddSupplier" runat="server" Width="95%" CssClass="drpdownCSS" AutoPostBack="True" OnSelectedIndexChanged="ddSupplier_SelectedIndexChanged" Enabled="False"></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 12%" class="column_RightBold">Approved By :</td>
                                    <td style="width: 35%" align="left">
                                        <asp:DropDownList ID="ddApprovedby" runat="server" Width="98%" CssClass="drpdownCSS" AutoPostBack="True" OnSelectedIndexChanged="ddApprovedby_SelectedIndexChanged" Enabled="False"></asp:DropDownList>
                                    </td>
                                    <td style="width: 12%" class="column_RightBold"></td>
                                    <td style="width: 41%" align="left"></td>
                                </tr>
                                <tr>
                                    <td style="width: 12%" class="column_RightBold">Invoice Number :</td>
                                    <td style="width: 35%" align="left">
                                        <asp:TextBox ID="txtInvoice" runat="server" Width="150px" CssClass="txtbox_Var"></asp:TextBox>
                                    </td>
                                    <td style="width: 12%" class="column_RightBold"></td>
                                    <td style="width: 41%" align="left">
                                        <asp:RadioButtonList ID="rbChoice" runat="server" Width="200px" CssClass="rbCS_Horizontal" AutoPostBack="True" OnSelectedIndexChanged="rbChoice_SelectedIndexChanged" RepeatDirection="Horizontal">
                                            <asp:ListItem Value="1">Partial</asp:ListItem>
                                            <asp:ListItem Value="2" Selected="True">Complete</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 12%" class="column_RightBold">Received By :</td>
                                    <td style="width: 35%" align="left">
                                        <asp:DropDownList ID="ddReceivedBy" runat="server" Width="98%" CssClass="drpdownCSS" AutoPostBack="True" OnSelectedIndexChanged="ddReceivedBy_SelectedIndexChanged" Enabled="False"></asp:DropDownList>
                                    </td>
                                    <td style="width: 12%" class="column_RightBold">Date Received :</td>
                                    <td style="width: 41%" align="left">
                                        <asp:TextBox ID="txtDateRecieved" runat="server" Width="100px" CssClass="txtbox_Date"></asp:TextBox>
                                        &nbsp;<asp:ImageButton ID="ImageButton2" runat="server" Width="20px" ImageUrl="~/images/Calendar_scheduleHS.png" Height="15px"></asp:ImageButton>
                                        &nbsp;<span class="CalendarFormat">(MM/DD/YYYY)</span>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 12%" class="column_RightBold">Inspected By :</td>
                                    <td style="width: 35%" align="left">
                                        <asp:DropDownList ID="ddInspectedby" runat="server" Width="98%" CssClass="drpdownCSS" AutoPostBack="True" OnSelectedIndexChanged="ddInspectedby_SelectedIndexChanged" Enabled="False"></asp:DropDownList>
                                    </td>
                                    <td style="width: 12%" class="column_RightBold">Date Inspected :</td>
                                    <td style="width: 41%" align="left">
                                        <asp:TextBox ID="txtDateInspected" runat="server" Width="100px" CssClass="txtbox_Date"></asp:TextBox>
                                        &nbsp;<asp:ImageButton ID="ImageButton3" runat="server" Width="20px" ImageUrl="~/images/Calendar_scheduleHS.png" Height="15px"></asp:ImageButton>
                                        &nbsp;<span class="CalendarFormat">(MM/DD/YYYY)</span>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 12%" class="column_RightBold">Accepted By :</td>
                                    <td style="width: 35%" align="left">
                                        <asp:DropDownList ID="ddacceptedby" runat="server" Width="98%" CssClass="drpdownCSS" AutoPostBack="True" Enabled="False"></asp:DropDownList>
                                    </td>
                                    <td style="width: 12%" class="column_RightBold">Date Accepted :</td>
                                    <td style="width: 41%" align="left">
                                        <asp:TextBox ID="txtDateAccepted" runat="server" Width="100px" CssClass="txtbox_Date"></asp:TextBox>
                                        &nbsp;<asp:ImageButton ID="ImageButton4" runat="server" Width="20px" ImageUrl="~/images/Calendar_scheduleHS.png" Height="15px"></asp:ImageButton>
                                        &nbsp;<span class="CalendarFormat">(MM/DD/YYYY)</span>
                                    </td>
                                </tr>

                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="ImageButton1" TargetControlID="txtDeliveredDate"></cc1:CalendarExtender>
                                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" PopupButtonID="ImageButton2" TargetControlID="txtDateRecieved"></cc1:CalendarExtender>
                                <cc1:CalendarExtender ID="CalendarExtender3" runat="server" PopupButtonID="ImageButton3" TargetControlID="txtDateInspected"></cc1:CalendarExtender>
                                <cc1:CalendarExtender ID="CalendarExtender4" runat="server" PopupButtonID="ImageButton4" TargetControlID="txtDateAccepted"></cc1:CalendarExtender>

                            </table>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%;height:10px"></td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:Button ID="btnSave" OnClick="btnSave_Click" runat="server" Width="150px" CssClass="CSButton"  OnClientClick="StartProgressBar();" Text="SAVE"></asp:Button>
                            &nbsp;<asp:Button ID="btnPreview" OnClick="btnPreview_Click" runat="server" Width="150px" CssClass="CSButton" Text="PREVIEW" Enabled="False"></asp:Button>
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

            
           

            <asp:Panel Style="border-top-width: 1px; border-left-width: 1px; border-left-color: #0033cc; border-bottom-width: 1px; border-bottom-color: #0033cc; border-top-color: #0033cc; background-color: transparent; text-align: center; border-right-width: 1px; border-right-color: #0033cc" ID="PanelProgress" runat="server" Width="109px">
                <img alt="" src="../images/ajax-loader.gif" />
            </asp:Panel>
            <cc1:ModalPopupExtender ID="ProgressBarModalPopupExtender" runat="server" TargetControlID="ButtonProgress" BehaviorID="ProgressBarModalPopupExtender" BackgroundCssClass="modalBackground" PopupControlID="PanelProgress"></cc1:ModalPopupExtender>
            <asp:Button Style="border-top-style: none; border-right-style: none; border-left-style: none; background-color: transparent; border-bottom-style: none" ID="ButtonProgress" runat="server" Width="16px" Enabled="False"></asp:Button> 
       
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

