<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="t_PPMP_Supplemental.aspx.vb"
    Inherits="planning_t_PPMP_Supplemental" Title="PPMP Supplemental" StylesheetTheme="SkinFile" %>

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




            <div>
                <table width="100%">
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="PageTitle">PROJECT PROCUREMENT MANAGEMENT PLAN - SUPPLEMENTAL
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <table style="width: 90%">
                                <tbody>
                                    <tr>
                                        <td style="width: 15%" class="column_RightBold">Date : </td>
                                        <td style="width: 85%" class="column_Left">
                                            <asp:TextBox ID="txtDate" runat="server" Width="100px" ReadOnly="True" CssClass="txtbox_Date"></asp:TextBox></td>
                                    </tr>
                                    <tr style="font-weight: bold">
                                        <td style="width: 15%" class="column_RightBold">Supplemental Budget : </td>
                                        <td style="width: 85%" class="column_Left">
                                            <asp:DropDownList ID="ddSuppBudget" runat="server" Width="40%" CssClass="drpdownCSS" OnSelectedIndexChanged="ddSuppBudget_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList></td>
                                    </tr>
                                    <tr style="color: #000000">
                                        <td style="width: 15%" class="column_RightBold">Department : </td>
                                        <td style="width: 85%" class="column_Left">
                                            <asp:DropDownList ID="ddDepartment" runat="server" Width="75%" CssClass="drpdownCSS" OnSelectedIndexChanged="ddDepartment_SelectedIndexChanged" AutoPostBack="True" Enabled="False"></asp:DropDownList></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 15%" class="column_RightBold">Function : </td>
                                        <td style="width: 85%" class="column_Left">
                                            <asp:DropDownList ID="ddFunction" runat="server" Width="75%" CssClass="drpdownCSS" OnSelectedIndexChanged="ddFunction_SelectedIndexChanged" AutoPostBack="True" Enabled="False" DataTextField="Function_Desc" DataValueField="Function_ID"></asp:DropDownList></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 15%" class="column_RightBold">P/P/A :</td>
                                        <td style="width: 85%" class="column_Left">
                                            <asp:DropDownList ID="ddPPA" runat="server" Width="75%" CssClass="drpdownCSS" OnSelectedIndexChanged="ddPPA_SelectedIndexChanged" AutoPostBack="True" Enabled="False"></asp:DropDownList></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 15%" class="column_RightBold">Allotment Type :</td>
                                        <td style="width: 85%" class="column_Left">
                                            <asp:DropDownList ID="ddAllotmentType" runat="server" Width="40%" CssClass="drpdownCSS" OnSelectedIndexChanged="ddAllotmentType_SelectedIndexChanged" AutoPostBack="True" Enabled="False">
                                                <asp:ListItem Selected="True" Value="1">Select</asp:ListItem>
                                                <asp:ListItem Value="2">MOOE</asp:ListItem>
                                                <asp:ListItem Value="3">CO</asp:ListItem>
                                            </asp:DropDownList></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 15%" class="column_RightBold">Account&nbsp;Title : </td>
                                        <td style="width: 85%" class="column_Left">
                                            <asp:DropDownList ID="ddAccounts" runat="server" Width="75%" CssClass="drpdownCSS" OnSelectedIndexChanged="ddAccounts_SelectedIndexChanged" AutoPostBack="True" Enabled="False"></asp:DropDownList>
                                            &nbsp;<asp:LinkButton ID="lnkListGoods" OnClick="lnkListGoods_Click" runat="server" Enabled="False" Font-Underline="True" CssClass="LinkBtnPreview">View List of Goods</asp:LinkButton></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 15%" class="column_RightBold"></td>
                                        <td style="width: 85%" class="column_Left"></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 15%" class="column_RightBold">Appropriate Budget : </td>
                                        <td style="width: 85%" class="column_Left">
                                            <asp:TextBox ID="txtAppropraiteBudget" runat="server" Width="150px" ReadOnly="True" CssClass="txtbox_Amt">0.00</asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 15%" class="column_RightBold">Available Budget : </td>
                                        <td style="width: 85%" class="column_Left">
                                            <asp:TextBox ID="txtAvailableBudget" runat="server" Width="150px" ReadOnly="True" CssClass="txtbox_Amt">0.00</asp:TextBox><asp:Label ID="lblNoti" runat="server" Font-Bold="False" ForeColor="Red" Font-Size="9pt" Font-Names="Calibri" Font-Italic="True" Visible="False" Text="** Exceed from the approved budget."></asp:Label></td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="DivTitle">Quantity Per Unit
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:GridView ID="gvquarters" runat="server" Width="90%" AutoGenerateColumns="False"
                                SkinID="GridViewAA" CaptionAlign="Left" UseAccessibleHeader="False" BackColor="White" EmptyDataText="No Data Found.">
                                <Columns>
                                    <asp:TemplateField HeaderText="1st Quarter">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                        </EditItemTemplate>
                                        <HeaderTemplate>
                                            <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                                <tr>
                                                    <td colspan="2" style="text-align: center; width: 100%" class="column_Center">First Quarter</td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 50%" align="center">Quantity</td>
                                                    <td style="width: 50%" align="center">Amount</td>
                                                </tr>
                                            </table>

                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                <tbody>
                                                    <tr>
                                                        <td style="width: 50%" align="center">
                                                            <asp:TextBox ID="txtqty1" runat="server" Width="80%" AutoPostBack="true" CssClass="txtbox_Date" Text='<%#Bind("qty1") %>' SkinID="text" OnTextChanged="txtqty1_TextChanged"></asp:TextBox></td>
                                                        <td style="width: 50%" align="center">
                                                            <asp:Label ID="lblprice1" runat="server" Text='<%#Bind("price1", "{0:N}") %>'></asp:Label></td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtqty1" ValidChars="0123456789."></cc1:FilteredTextBoxExtender>
                                        </ItemTemplate>

                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:TemplateField>


                                    <asp:TemplateField HeaderText="2nd Quarter">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                                        </EditItemTemplate>
                                        <HeaderTemplate>
                                            <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                                <tr>
                                                    <td colspan="2" style="text-align: center; width: 100%" class="column_Center">Second Quarter</td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 50%" align="center">Quantity</td>
                                                    <td style="width: 50%" align="center">Amount</td>
                                                </tr>
                                            </table>

                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                <tbody>
                                                    <tr>
                                                        <td style="width: 50%" align="center">
                                                            <asp:TextBox ID="txtqty2" runat="server" Width="80%" CssClass="txtbox_Date" SkinID="text" Text='<%#Bind("qty2") %>' AutoPostBack="true" OnTextChanged="txtqty2_TextChanged"></asp:TextBox></td>
                                                        <td style="width: 50%" align="center">
                                                            <asp:Label ID="lblprice2" runat="server" Text='<%#Bind("price2", "{0:N}") %>'></asp:Label></td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" TargetControlID="txtqty2" ValidChars="0123456789."></cc1:FilteredTextBoxExtender>
                                        </ItemTemplate>
                                    </asp:TemplateField>


                                    <asp:TemplateField HeaderText="3rd Quarter">
                                        <HeaderTemplate>
                                            <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                                <tr>
                                                    <td colspan="2" style="text-align: center; width: 100%" class="column_Center">Third Quarter</td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 50%" align="center">Quantity</td>
                                                    <td style="width: 50%" align="center">Amount</td>
                                                </tr>
                                            </table>

                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                <tbody>
                                                    <tr>
                                                        <td style="width: 50%" align="center">
                                                            <asp:TextBox ID="txtqty3" runat="server" Width="80%" CssClass="txtbox_Date" SkinID="text" Text='<%#Bind("qty3") %>' AutoPostBack="true" OnTextChanged="txtqty3_TextChanged"></asp:TextBox></td>
                                                        <td style="width: 50%" align="center">
                                                            <asp:Label ID="lblprice3" runat="server" Text='<%#Bind("price3", "{0:N}") %>'></asp:Label></td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" TargetControlID="txtqty3" Enabled="False" ValidChars="0123456789."></cc1:FilteredTextBoxExtender>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="4th Quarter">
                                        <HeaderTemplate>
                                            <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                                <tr>
                                                    <td colspan="2" style="text-align: center; width: 100%" class="column_Center">Fourth Quarter</td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 50%" align="center">Quantity</td>
                                                    <td style="width: 50%" align="center">Amount</td>
                                                </tr>
                                            </table>

                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                <tbody>
                                                    <tr>
                                                        <td style="width: 50%" align="center">
                                                            <asp:TextBox ID="txtqty4" runat="server" Width="80%" CssClass="txtbox_Date" SkinID="text" Text='<%#Bind("qty4") %>' AutoPostBack="true" OnTextChanged="txtqty4_TextChanged"></asp:TextBox></td>
                                                        <td style="width: 50%" align="center">
                                                            <asp:Label ID="lblprice4" runat="server" Text='<%#Bind("price4", "{0:N}") %>'></asp:Label></td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" TargetControlID="txtqty4" ValidChars="0123456789."></cc1:FilteredTextBoxExtender>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>

                            <%--<asp:GridView Style="font-weight: normal" ID="gvquarters" runat="server" Width="1000px" EmptyDataText="No Data Found." PageSize="1" SkinID="GridViewAA" CaptionAlign="Left" UseAccessibleHeader="False" BackColor="White" AutoGenerateColumns="False">
                                <Columns>
                                    <asp:TemplateField HeaderText="Quantity">
                                        <HeaderTemplate>
                                            <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                                <tr>
                                                    <td colspan="2" style="text-align: center">First Quarter</td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 100px">Quantity</td>
                                                    <td style="width: 100px; text-align: center">Amount</td>
                                                </tr>
                                            </table>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <table style="width: 200px">
                                                <tbody>
                                                    <tr>
                                                        <td style="width: 100px" class="column_Left">
                                                            <asp:TextBox Style="text-align: right" ID="txtqty1" runat="server" Width="98%" Text='<%#Bind("qty1") %>' CssClass="txtboxAmount" AutoPostBack="True" OnTextChanged="txtqty1_TextChanged"></asp:TextBox></td>
                                                        <td style="width: 100px" class="text4">
                                                            <asp:Label Style="text-align: right" ID="lblprice1" runat="server" Width="98%" Text='<%#Bind("price1", "{0:N}") %>' CssClass="text"></asp:Label></td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtqty1" ValidChars="0123456789">
                                            </cc1:FilteredTextBoxExtender>
                                        </ItemTemplate>

                                        <ItemStyle HorizontalAlign="Center" Width="225px"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="2nd Quarter">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                                        </EditItemTemplate>
                                        <HeaderTemplate>
                                            <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                                <tr>
                                                    <td colspan="2" style="text-align: center">Second Quarter</td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 100px">Quantity</td>
                                                    <td style="width: 100px; text-align: center">Amount</td>
                                                </tr>
                                            </table>

                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <table style="width: 200px">
                                                <tbody>
                                                    <tr>
                                                        <td style="width: 100px" class="column_Left">
                                                            <asp:TextBox Style="text-align: right" ID="txtqty2" runat="server" Width="98%" Text='<%#Bind("qty2") %>' CssClass="txtboxAmount" AutoPostBack="True" OnTextChanged="txtqty2_TextChanged"></asp:TextBox></td>
                                                        <td style="width: 100px" class="text4">
                                                            <asp:Label Style="text-align: right" ID="lblprice2" runat="server" Width="98%" Text='<%#Bind("price2", "{0:N}") %>' CssClass="text"></asp:Label></td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" TargetControlID="txtqty2" ValidChars="0123456789">
                                            </cc1:FilteredTextBoxExtender>
                                        </ItemTemplate>

                                        <ItemStyle HorizontalAlign="Center" Width="225px"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="3rd Quarter">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>

                                        </EditItemTemplate>
                                        <HeaderTemplate>
                                            <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                                <tr>
                                                    <td colspan="2" style="text-align: center">Third Quarter</td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 100px">Quantity</td>
                                                    <td style="width: 100px; text-align: center">Amount</td>
                                                </tr>
                                            </table>

                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <table style="width: 200px">
                                                <tbody>
                                                    <tr>
                                                        <td style="width: 100px" class="column_Left">
                                                            <asp:TextBox Style="text-align: right" ID="txtqty3" runat="server" Width="98%" Text='<%#Bind("qty3") %>' CssClass="txtboxAmount" AutoPostBack="True" OnTextChanged="txtqty3_TextChanged"></asp:TextBox></td>
                                                        <td style="width: 100px" class="text4">
                                                            <asp:Label Style="text-align: right" ID="lblprice3" runat="server" Width="98%" Text='<%#Bind("price3", "{0:N}") %>' CssClass="text"></asp:Label></td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" TargetControlID="txtqty3" Enabled="False" ValidChars="0123456789">
                                            </cc1:FilteredTextBoxExtender>
                                        </ItemTemplate>

                                        <ItemStyle HorizontalAlign="Center" Width="225px"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="4th Quarter">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>

                                        </EditItemTemplate>
                                        <HeaderTemplate>
                                            <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                                <tr>
                                                    <td colspan="2" style="text-align: center">Fourth Quarter</td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 100px">Quantity</td>
                                                    <td style="width: 100px; text-align: center">Amount</td>
                                                </tr>
                                            </table>

                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <table style="width: 200px">
                                                <tbody>
                                                    <tr>
                                                        <td style="width: 100px" class="column_Left">
                                                            <asp:TextBox Style="text-align: right" ID="txtqty4" runat="server" Width="98%" SkinID="text" Text='<%#Bind("qty4") %>' CssClass="txtboxAmount" AutoPostBack="True" OnTextChanged="txtqty4_TextChanged"></asp:TextBox></td>
                                                        <td style="width: 100px" class="text4">
                                                            <asp:Label Style="text-align: right" ID="lblprice4" runat="server" Width="98%" Text='<%#Bind("price4", "{0:N}") %>' CssClass="text"></asp:Label></td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" TargetControlID="txtqty4" ValidChars="0123456789">
                                            </cc1:FilteredTextBoxExtender>
                                        </ItemTemplate>

                                        <ItemStyle HorizontalAlign="Center" Width="225px"></ItemStyle>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>--%>

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
                            <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                <ContentTemplate>
                                    <asp:Panel ID="Panel2" runat="server" Width="98%" CssClass="PanelSize" ScrollBars="Vertical">
                                        <asp:GridView ID="gvbody" runat="server" Width="100%" OnSelectedIndexChanged="gvbody_SelectedIndexChanged" PageSize="5"
                                            SkinID="GridViewAA" UseAccessibleHeader="False" AutoGenerateColumns="False" ShowFooter="True" DataKeyNames="Item_ID,ppmp_dtl_id">
                                            <Columns>
                                                <asp:TemplateField ShowHeader="False">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CssClass="LinkBtnSelect" Text="Select" Enabled='<%#Bind("id") %>' Font-Underline="False" CommandName="Select"></asp:LinkButton>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" Width="40px"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Description">
                                                    <ItemTemplate>
                                                        <asp:Label Style="text-align: left" ID="lbldesc" runat="server" Width="357px" Text='<%# Bind("Item_Desc") %>' CssClass="text"></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Unit">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblunit" runat="server" Style="text-align: right" CssClass="text" Text='<%# Bind("Description") %>'
                                                            Width="100px"></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Quantity">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblqty" runat="server" CssClass="text" Style="text-align: right" Text='<%#Bind("Qty") %>'
                                                            Width="60px"></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Price">
                                                    <FooterTemplate>
                                                        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="11pt" Font-Names="Arial" Text="TOTAL :"></asp:Label>
                                                    </FooterTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblamount" runat="server" CssClass="text" Style="text-align: right"
                                                            Text='<%# Bind("price", "{0:N}") %>' Width="100px"></asp:Label>
                                                    </ItemTemplate>

                                                    <FooterStyle HorizontalAlign="Right"></FooterStyle>
                                                    <ItemStyle HorizontalAlign="Right"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Total Amount">
                                                    <FooterTemplate>
                                                        <asp:Label Style="text-align: right" ID="lblTotal" runat="server" Width="115px" Font-Bold="True" ForeColor="White" Text="0.00" Height="18px"></asp:Label>
                                                    </FooterTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label Style="text-align: right" ID="lbltotal" runat="server" Width="100px" CssClass="text" Text='<%# Bind("total", "{0:N}") %>'></asp:Label>
                                                    </ItemTemplate>

                                                    <FooterStyle HorizontalAlign="Right" Font-Bold="True" ForeColor="White"></FooterStyle>
                                                    <ItemStyle HorizontalAlign="Right"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>

                                            <SelectedRowStyle Font-Bold="False"></SelectedRowStyle>

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
                            <span class="column_RightBold">Prepared By : </span>
                            &nbsp;<asp:DropDownList ID="ddPreparedBy" runat="server" Width="30%" CssClass="drpdownCSS" OnSelectedIndexChanged="ddPreparedBy_SelectedIndexChanged" AutoPostBack="True" Enabled="False"></asp:DropDownList>
                            &nbsp;<span class="column_RightBold">Mode Of Procurement :</span>
                            &nbsp;<asp:DropDownList ID="ddModeProcurement" runat="server" Width="30%" CssClass="drpdownCSS" OnSelectedIndexChanged="ddModeProcurement_SelectedIndexChanged" AutoPostBack="True" Enabled="False"></asp:DropDownList>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:Button ID="btnSave" OnClick="btnSave_Click" runat="server" Width="150px" CssClass="CSButton" Enabled="False" Text="SAVE" OnClientClick="StartProgressBar();"></asp:Button>
                            &nbsp;<asp:Button ID="btnPreview" OnClick="btnPreview_Click" runat="server" Width="150px" CssClass="CSButton" Enabled="False" Text="PREVIEW PPMP"></asp:Button>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%; height: 5px"></td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="DivTitle">Project Procurement Management Plan
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <cc1:TabContainer Style="text-align: left" ID="TabContainer1" runat="server" Width="1000px" ActiveTabIndex="1">
                                <cc1:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
                                    <HeaderTemplate>
                                        <span style="font-size: 9pt; font-family: Arial"><strong>Office Operating Expense </strong>
                                        </span>
                                    </HeaderTemplate>
                                    <ContentTemplate>
                                        <asp:GridView Style="font-weight: normal" ID="gvppmp" runat="server" Width="100%" AutoGenerateColumns="False" SkinID="GridViewAA" DataKeyNames="GA_CODE2,GA_TITLE,GA_ID,BGA_ID" AllowPaging="True">
                                            <Columns>
                                                <asp:CommandField ShowSelectButton="True" Visible="False">
                                                    <ItemStyle Width="8%"></ItemStyle>
                                                </asp:CommandField>
                                                <asp:BoundField DataField="ga_title" HeaderText="Account Title">
                                                    <FooterStyle HorizontalAlign="Left"></FooterStyle>

                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>

                                                    <ItemStyle HorizontalAlign="Left" Width="60%"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="GA_CODE2" HeaderText="Account Code">
                                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                    <ItemStyle HorizontalAlign="Center" Width="12%"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="TotalPPMP" DataFormatString="{0:N}" HeaderText="Amount" HtmlEncode="False">
                                                    <HeaderStyle HorizontalAlign="Right"></HeaderStyle>

                                                    <ItemStyle HorizontalAlign="Right" Width="20%"></ItemStyle>
                                                </asp:BoundField>
                                            </Columns>
                                        </asp:GridView>
                                    </ContentTemplate>
                                </cc1:TabPanel>
                                <cc1:TabPanel runat="server" HeaderText="TabPanel2" ID="TabPanel2">
                                    <HeaderTemplate>
                                        <span style="font-size: 9pt; font-family: Arial"><strong>Programs / Projects / Activities 
                                        </strong></span>
                                    </HeaderTemplate>
                                    <ContentTemplate>
                                        <asp:GridView Style="font-weight: normal" ID="gvPPA" runat="server" Width="100%" AutoGenerateColumns="False" SkinID="GridViewAA" DataKeyNames="GA_CODE2,GA_TITLE,PPA,GA_ID,BGA_ID,Program_ID,Project_ID" CssClass="text" AllowPaging="True">
                                            <Columns>
                                                <asp:CommandField ShowSelectButton="True" Visible="False">
                                                    <ItemStyle Width="8%"></ItemStyle>
                                                </asp:CommandField>
                                                <asp:BoundField DataField="PPA" HeaderText="PPA">
                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>

                                                    <ItemStyle HorizontalAlign="Left" Width="30%"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="ga_title" HeaderText="Account Title">
                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>

                                                    <ItemStyle HorizontalAlign="Left" Width="30%"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="GA_CODE2" HeaderText="Account Code">
                                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                    <ItemStyle HorizontalAlign="Center" Width="12%"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="TotalPPMP" DataFormatString="{0:N}" HeaderText="Amount">
                                                    <HeaderStyle HorizontalAlign="Right"></HeaderStyle>

                                                    <ItemStyle HorizontalAlign="Right" Width="20%"></ItemStyle>
                                                </asp:BoundField>
                                            </Columns>
                                        </asp:GridView>
                                    </ContentTemplate>
                                </cc1:TabPanel>
                            </cc1:TabContainer>
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









            <asp:Panel Style="display: none" ID="popup" runat="server" Width="900px">
                <table id="Table8" height="486" cellspacing="0" cellpadding="0" width="747" border="0">
                    <tbody>
                        <tr>
                            <td colspan="2">

                                <%-- <IMG height=1 alt="" src="../images/modalpopup_01.png" width=747 />--%>
    
                            </td>
                        </tr>
                        <tr>
                            <td style="background-image: url(../images/modalpopup_02.png); width: 772px; height: 39px"></td>
                            <td style="width: 34px; height: 39px">
                                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="../images/modalpopup_03.png"></asp:ImageButton></td>
                        </tr>
                        <tr>
                            <td style="background-image: url(../images/modalpopup_04.png); vertical-align: top; width: 772px" id="Td3">
                                <table style="width: 705px; height: 336px" cellspacing="0" cellpadding="0" border="0">
                                    <tbody>
                                        <tr>
                                            <td style="vertical-align: top; width: 4%; text-align: center"></td>
                                            <td style="vertical-align: top; width: 100%; text-align: center">
                                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                    <ContentTemplate>
                                                        <table style="width: 100%" class="text" cellspacing="0" cellpadding="0" border="0">
                                                            <tbody>
                                                                <tr>
                                                                    <td style="width: 100%; height: 48px; text-align: left" colspan="3">
                                                                        <table style="width: 100%">
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td style="width: 15%" align="right">Search :</td>
                                                                                    <td style="width: 60%">
                                                                                        <asp:TextBox ID="SearchBut" runat="server" Width="98%" CssClass="txtboxinspection"></asp:TextBox></td>
                                                                                    <td style="width: 20%">
                                                                                        <asp:Button ID="btnSearch" runat="server" Width="98%" Text="SEARCH" OnClick="btnSearch_Click"></asp:Button></td>
                                                                                </tr>
                                                                            </tbody>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                        <asp:GridView Style="font-weight: normal" ID="gvitems" runat="server" Width="100%" BackColor="White" SkinID="GridViewAA" DataKeyNames="item_id" PageSize="8" AllowPaging="True" OnPageIndexChanging="gvitems_PageIndexChanging">
                                                            <Columns>
                                                                <asp:TemplateField>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <HeaderTemplate>
                                                                        <asp:CheckBox ID="CheckBox2" runat="server" Width="50px" Font-Bold="True" ForeColor="White" Font-Size="10pt" Font-Names="tahoma" Text="All" AutoPostBack="True" OnCheckedChanged="CheckBox2_CheckedChanged"></asp:CheckBox>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox ID="CheckBox1" runat="server" Width="50px" AutoPostBack="True" OnCheckedChanged="CheckBox1_CheckedChanged"></asp:CheckBox>
                                                                    </ItemTemplate>

                                                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                                    <ItemStyle HorizontalAlign="Center" Width="3%"></ItemStyle>
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="Item_Desc" HeaderText="Description">
                                                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                                    <ItemStyle HorizontalAlign="Left" Width="67%"></ItemStyle>
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="Description" HeaderText="Unit">
                                                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                                    <ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="Item_id">
                                                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                                    <ItemStyle Width="10px"></ItemStyle>
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="id" HeaderText="id">
                                                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="Price" DataFormatString="{0:N}" HeaderText="Price">
                                                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                                    <ItemStyle HorizontalAlign="Right" Width="15%"></ItemStyle>
                                                                </asp:BoundField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="gvitems" EventName="SelectedIndexChanging"></asp:AsyncPostBackTrigger>
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 4%; height: 24px; text-align: center"></td>
                                            <td style="width: 100%; height: 24px; text-align: center" align="center">
                                                <asp:Button ID="Button3" OnClick="Button3_Click" runat="server" Width="200px" Text="LOAD" OnClientClick="StartProgressBar();" Height="30px"></asp:Button></td>
                                        </tr>
                                    </tbody>
                                </table>
                                <span style="color: black"><strong>Contact GSO to add Goods.<asp:Label ID="Label3" runat="server"></asp:Label></strong></span></td>
                            <td style="background-image: url(../images/modalpopup_05.png); width: 34px; height: 446px"></td>
                        </tr>
                    </tbody>
                </table>
            </asp:Panel>
            <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" BackgroundCssClass="modalBackground" TargetControlID="Label3" PopupControlID="popup"></cc1:ModalPopupExtender>
            <asp:Panel Style="border-top-width: 1px; border-left-width: 1px; border-left-color: #0033cc; border-bottom-width: 1px; border-bottom-color: #0033cc; border-top-color: #0033cc; background-color: transparent; text-align: center; border-right-width: 1px; border-right-color: #0033cc" ID="PanelProgress" runat="server" Width="109px">
                <img src="../images/ajax-loader.gif" />
            </asp:Panel>
            <cc1:ModalPopupExtender ID="ProgressBarModalPopupExtender" runat="server" BackgroundCssClass="modalBackground" TargetControlID="ButtonProgress" PopupControlID="PanelProgress" BehaviorID="ProgressBarModalPopupExtender"></cc1:ModalPopupExtender>
            <asp:Button Style="border-top-style: none; border-right-style: none; border-left-style: none; background-color: transparent; border-bottom-style: none" ID="ButtonProgress" runat="server" Width="16px" Enabled="False"></asp:Button>&nbsp;&nbsp; 
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

