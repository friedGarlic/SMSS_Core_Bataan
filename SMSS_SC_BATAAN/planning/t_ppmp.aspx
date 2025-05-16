<%@ Page MaintainScrollPositionOnPostback="true" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="t_ppmp.aspx.vb" Inherits="PLANNING_t_ppmp"
    Title="PROJECT PROCUREMENT MANAGEMENT PLAN" StylesheetTheme="SkinFile" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<script runat="server">



</script>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" ScriptMode="Release">
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



    <%-- <script type="text/javascript">
    var xPos, yPos;
    var prm = Sys.WebForms.PageRequestManager.getInstance();
    prm.add_beginRequest(BeginRequestHandler);
    prm.add_endRequest(EndRequestHandler);
    function BeginRequestHandler(sender, args) {
        xPos = $get('scrollDiv').scrollLeft;
        yPos = $get('scrollDiv').scrollTop;
    }
    function EndRequestHandler(sender, args) {
        $get('scrollDiv').scrollLeft = xPos;
        $get('scrollDiv').scrollTop = yPos;
    }
</script>--%>


    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <div>
                <table width="1020px">
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="PageTitle">PROJECT PROCUREMENT MANAGEMENT PLAN
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%">
                            <table style="width: 95%">
                                <tbody>
                                    <tr style="font-weight: bold">
                                        <td style="width: 20%" class="column_RightBold">Calendar Year : </td>
                                        <td style="width: 80%" class="column_Left">
                                            <asp:DropDownList ID="ddyear" runat="server" CssClass="drpdownCSS" Width="150px" AppendDataBoundItems="true" AutoPostBack="true">
                                                <asp:ListItem>Select</asp:ListItem>
                                            </asp:DropDownList>
                                            &nbsp;<span class="column_RightBold">Date :</span>
                                            <asp:TextBox ID="txtDate" runat="server" Width="120px" CssClass="txtbox_Date" Enabled="False"></asp:TextBox>
                                            &nbsp;<span class="column_RightBold">Status :</span>
                                            &nbsp;<asp:Label ID="lblappstatus" runat="server" CssClass="column_RightBold" ForeColor="Red"></asp:Label></td>
                                    </tr>
                                    <tr style="color: #000000">
                                        <td style="width: 20%" class="column_RightBold">Department : </td>
                                        <td style="width: 80%" class="column_Left">
                                            <asp:DropDownList ID="ddRC" runat="server" Width="75%" AppendDataBoundItems="true" AutoPostBack="true" CssClass="drpdownCSS" Enabled="False">
                                                <asp:ListItem>Select</asp:ListItem>
                                            </asp:DropDownList></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 20%" class="column_RightBold">Function : </td>
                                        <td style="width: 80%" class="column_Left">
                                            <asp:DropDownList ID="ddFunction" runat="server" Width="75%" AppendDataBoundItems="true" AutoPostBack="true" CssClass="drpdownCSS" Enabled="False">
                                                <asp:ListItem Value="0">Select</asp:ListItem>
                                            </asp:DropDownList></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 20%" class="column_RightBold">Programs/ Projects/ Activities :</td>
                                        <td style="width: 80%" class="column_Left">
                                            <asp:DropDownList ID="ddPAPS" runat="server" CssClass="drpdownCSS" Width="75%" AppendDataBoundItems="true" AutoPostBack="true" Enabled="False">
                                                <asp:ListItem>Select</asp:ListItem>
                                            </asp:DropDownList></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 20%" class="column_RightBold">Allotment Type :</td>
                                        <td style="width: 80%" class="column_Left">
                                            <asp:DropDownList ID="DropDownList1" runat="server" CssClass="drpdownCSS" Width="40%" AppendDataBoundItems="true" AutoPostBack="true" Enabled="False">
                                                <asp:ListItem>Select</asp:ListItem>
                                                <asp:ListItem Value="2">MOOE</asp:ListItem>
                                                <asp:ListItem Value="3">Capital Outlay</asp:ListItem>
                                            </asp:DropDownList>
                                            &nbsp;<asp:CheckBox ID="chkOOE" runat="server" CssClass="rbCS_Horizontal" AutoPostBack="true" Text="OOE"></asp:CheckBox>&nbsp;&nbsp;|
                                            <asp:CheckBox ID="CBIsGoods" runat="server" CssClass="rbCS_Horizontal" Width="114px" AutoPostBack="true" Text="Without Goods" Visible="true" OnCheckedChanged="CBIsGoods_CheckedChanged"></asp:CheckBox>|
                                        <asp:CheckBox ID="CBIsInfra" runat="server" CssClass="rbCS_Horizontal" Width="80px" Text="Infra" AutoPostBack="true" Visible="true" OnCheckedChanged="CBIsInfra_CheckedChanged"></asp:CheckBox></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 20%" class="column_RightBold">Account&nbsp;Title : </td>
                                        <td style="width: 80%" class="column_Left">
                                            <div>
                                                <asp:DropDownList ID="ddAccount" runat="server" CssClass="drpdownCSS" Width="75%" AutoPostBack="true" Enabled="False">
                                                    <asp:ListItem>Select</asp:ListItem>
                                                </asp:DropDownList>
                                                &nbsp;<asp:LinkButton ID="lnkView" runat="server" CssClass="LinkBtnPreview" Text="View List of Goods"></asp:LinkButton>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 20%" class="column_RightBold"></td>
                                        <td style="width: 80%" class="column_Left">
                                            <asp:CheckBox ID="chkPrev" runat="server" Width="166px" AutoPostBack="true" Text="Load Previous" Visible="False"></asp:CheckBox></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 20%" class="column_RightBold">Appropriate Budget : </td>
                                        <td style="width: 80%" class="column_Left">
                                            <asp:TextBox Style="text-align: right" ID="txtbudget" runat="server" CssClass="txtbox_Amt" Width="100px" Text="0.00" ReadOnly="true"></asp:TextBox>
                                            &nbsp;<asp:Label ID="lblpromt" runat="server" ForeColor="Red" Font-Size="8pt" Text="No Allocated Budget" Font-Italic="true"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 20%" class="column_RightBold">Available Budget : </td>
                                        <td style="width: 80%" class="column_Left">
                                            <asp:TextBox Style="text-align: right" ID="txtAvailableBudget" runat="server" CssClass="txtbox_Amt" Width="100px" Text="0.00" ReadOnly="true"></asp:TextBox>
                                            &nbsp;<asp:Label ID="lblpromt2" runat="server" ForeColor="Red" Font-Size="8pt" Text="No Allocated Budget" Font-Italic="true"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 20%" class="column_RightBold"></td>
                                        <td style="width: 80%" class="column_Left"></td>
                                    </tr>
                                </tbody>
                            </table>

                            <asp:HiddenField ID="hdfAppstatus" runat="server"></asp:HiddenField>
                            <asp:HiddenField ID="hdfProgID" runat="server"></asp:HiddenField>
                            <asp:HiddenField ID="hdfPcanbedit" runat="server"></asp:HiddenField>
                            <asp:HiddenField ID="hdfhdrID" runat="server"></asp:HiddenField>
                            <asp:HiddenField ID="hdfProjID" runat="server"></asp:HiddenField>
                            <asp:HiddenField ID="hdfppaprojId" runat="server"></asp:HiddenField>
                            <asp:HiddenField ID="hdfppaprogId" runat="server"></asp:HiddenField>
                            <asp:RadioButtonList ID="rbChoice" runat="server" Width="200px" AutoPostBack="true" Visible="False" OnSelectedIndexChanged="rbChoice_SelectedIndexChanged" RepeatDirection="Horizontal">
                                <asp:ListItem Value="1">PPMP - Contingency</asp:ListItem>
                            </asp:RadioButtonList>

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
                                SkinID="GridViewAA" CaptionAlign="Left" UseAccessibleHeader="False" BackColor="White">
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
                                                            <asp:TextBox ID="txtqty1" runat="server" Width="80%" AutoPostBack="true" CssClass="txtbox_Date" Text='<%#Bind("qty1", "{0:N0}") %>' SkinID="text" OnTextChanged="txtqty1_TextChanged"></asp:TextBox></td>
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
                                                            <asp:TextBox ID="txtqty2" runat="server" Width="80%" CssClass="txtbox_Date" SkinID="text" Text='<%#Bind("qty2", "{0:N0}") %>' AutoPostBack="true" OnTextChanged="txtqty2_TextChanged"></asp:TextBox></td>
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
                                                            <asp:TextBox ID="txtqty3" runat="server" Width="80%" CssClass="txtbox_Date" SkinID="text" Text='<%#Bind("qty3", "{0:N0}") %>' AutoPostBack="true" OnTextChanged="txtqty3_TextChanged"></asp:TextBox></td>
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
                                                            <asp:TextBox ID="txtqty4" runat="server" Width="80%" CssClass="txtbox_Date" SkinID="text" Text='<%#Bind("qty4", "{0:N0}") %>' AutoPostBack="true" OnTextChanged="txtqty4_TextChanged"></asp:TextBox></td>
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
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="DivTitle">List Of Items
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                <ContentTemplate>
                                    <asp:Panel ID="Panel2" runat="server" Width="95%" CssClass="PanelSize" ScrollBars="Vertical">
                                        <asp:GridView ID="gvbody" runat="server" Width="100%" AutoGenerateColumns="False" SkinID="GridViewAA" UseAccessibleHeader="False" PageSize="5" DataKeyNames="Item_ID,ppmp_dtl_id" ShowFooter="True" FooterStyle-Wrap="True">
                                            <Columns>
                                                <asp:TemplateField ShowHeader="False">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="LinkButton1" OnClick="LinkButton1_Click" CssClass="LinkBtnSelect" runat="server" CausesValidation="False" Enabled='<%#Bind("id") %>' Text="Select" Font-Underline="False" CommandName="Select"></asp:LinkButton>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" ForeColor="Blue" Width="5%"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="DESCRIPTION">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbldesc" runat="server" Text='<%# Bind("Item_desc") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="57%"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="UNIT">
                                                    <ItemTemplate>
                                                        <asp:Label Style="text-align: right" ID="lblunit" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="QUANTITY">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="TextBox3" runat="server" DataField="Number" DataFormatString="{0:N2}" Text='<%# Bind("Qty") %>'></asp:TextBox>

                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label Style="text-align: right" ID="lblqty" runat="server" Text='<%#Bind("Qty") %>'></asp:Label>
                                                    </ItemTemplate>

                                                    <HeaderStyle HorizontalAlign="Center" Font-Bold="True"></HeaderStyle>

                                                    <ItemStyle HorizontalAlign="Right" Width="7%"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField FooterText="TOTAL :" HeaderText="PRICE">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("Cost") %>'></asp:TextBox>

                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <strong><span style="font-family: Arial; text-align: right">TOTAL :</span></strong>
                                                    </FooterTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label Style="text-align: right" ID="lblamount" runat="server" Text='<%# Bind("price", "{0:N}") %>'></asp:Label>
                                                    </ItemTemplate>

                                                    <FooterStyle HorizontalAlign="Right" Font-Bold="True"></FooterStyle>

                                                    <HeaderStyle Font-Bold="True"></HeaderStyle>

                                                    <ItemStyle HorizontalAlign="Right" Width="8%"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="TOTAL AMOUNT">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("total") %>'></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:Label Style="text-align: right" ID="lblTotal" runat="server" Width="115px" Font-Bold="true" ForeColor="White" Text="0.00" Height="18px"></asp:Label>
                                                    </FooterTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label Style="text-align: right" ID="lbltotal" runat="server" Text='<%# Bind("total", "{0:N}") %>'></asp:Label>
                                                    </ItemTemplate>

                                                    <FooterStyle HorizontalAlign="Right" Font-Bold="False" ForeColor="White"></FooterStyle>

                                                    <HeaderStyle HorizontalAlign="Center" Font-Bold="True"></HeaderStyle>

                                                    <ItemStyle HorizontalAlign="Right" Width="10%"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <EditItemTemplate>
                                                        <asp:TextBox runat="server" ID="TextBox5"></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <HeaderTemplate>
                                                        <asp:Image ID="Image1" runat="server" ImageUrl="~/images/delete.png"></asp:Image>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="ImageButton4" OnClick="ImageButton4_Click" runat="server" Width="15px" ImageUrl="~/images/delete.png" Enabled='<%#Bind("id") %>' Height="15px" OnClientClick="StartProgressBar();" CommandName="Select"></asp:ImageButton>
                                                        <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" TargetControlID="ImageButton4" ConfirmText="Are you sure you want to delete this item?"></cc1:ConfirmButtonExtender>
                                                    </ItemTemplate>

                                                    <ItemStyle HorizontalAlign="Center" Width="3%"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="False">
                                                    <ItemTemplate>
                                                        &nbsp; 
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>

                                            <SelectedRowStyle Font-Bold="False"></SelectedRowStyle>

                                            <HeaderStyle Font-Names="Arial" Font-Size="8pt"></HeaderStyle>
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
                            <asp:Label ID="lblReq1" runat="server" Font-Bold="true" ForeColor="Red" Text="*" Visible="False"></asp:Label>
                            &nbsp;<span class="column_RightBold">Prepared By :</span>
                            &nbsp;<asp:DropDownList ID="ddPreparedBy" runat="server" Width="300px" AutoPostBack="true" CssClass="drpdownCSS"></asp:DropDownList>
                            &nbsp;<asp:Label ID="lblReq2" runat="server" Font-Bold="true" ForeColor="Red" Text="*" Visible="False"></asp:Label>
                            <asp:DropDownList ID="ddmode_of_procurement" runat="server" Width="300px" AutoPostBack="true" CssClass="drpdownCSS" Visible="False" OnSelectedIndexChanged="ddmode_of_procurement_SelectedIndexChanged"></asp:DropDownList>

                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                     <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:Panel runat="server" ID="pnlGPPB" Width="70%" CssClass="panel_border">
                                <table width="100%" cellpadding="0px" cellspacing="0px">
                                    <tr>
                                        <td style="width: 100%" colspan="4" class="DivTitle">For GPPB Report Markings
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100%; height: 10px" colspan="4"></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 25%" align="center">
                                            <span class="column_RightBold">1st Quarter :</span>
                                            &nbsp;<asp:DropDownList runat="server" ID="drp1stQtr" Width="45%" CssClass="drpdownCSS">
                                                <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>
                                                <asp:ListItem Value="1">January</asp:ListItem>
                                                <asp:ListItem Value="2">February</asp:ListItem>
                                                <asp:ListItem Value="3">March</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td style="width: 25%" align="center">
                                            <span class="column_RightBold">2nd Quarter :</span>
                                            &nbsp;<asp:DropDownList runat="server" ID="drp2ndQtr" Width="45%" CssClass="drpdownCSS">
                                                <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>
                                                <asp:ListItem Value="4">April</asp:ListItem>
                                                <asp:ListItem Value="5">May</asp:ListItem>
                                                <asp:ListItem Value="6">June</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td style="width: 25%" align="center">
                                            <span class="column_RightBold">3rd Quarter :</span>
                                            &nbsp;<asp:DropDownList runat="server" ID="drp3rdQtr" Width="45%" CssClass="drpdownCSS">
                                                <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>
                                                <asp:ListItem Value="7">July</asp:ListItem>
                                                <asp:ListItem Value="8">August</asp:ListItem>
                                                <asp:ListItem Value="9">September</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td style="width: 25%" align="center">
                                            <span class="column_RightBold">4th Quarter :</span>
                                            &nbsp;<asp:DropDownList runat="server" ID="drp4thQtr" Width="45%" CssClass="drpdownCSS">
                                                <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>
                                                <asp:ListItem Value="10">October</asp:ListItem>
                                                <asp:ListItem Value="11">November</asp:ListItem>
                                                <asp:ListItem Value="12">December</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100%; height: 10px" colspan="4"></td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:Button ID="btnsubmit" runat="server" CssClass="CSButton" Width="150px" Text="SAVE" OnClientClick="StartProgressBar();"></asp:Button>
                            &nbsp;<asp:Button ID="btnfinal" runat="server" CssClass="CSButton" Width="150px" Visible="false" Text="SUBMIT" OnClientClick="StartProgressBar();"></asp:Button>
                            &nbsp;<asp:Button ID="btnpreview" runat="server" CssClass="CSButton" Width="150px" Text="PREVIEW"></asp:Button>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%; height: 10px"></td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%; height: 23px;"></td>
                        <td style="width: 98%; height: 23px;" class="DivTitle">Project Procurement Management Plan
                        </td>
                        <td style="width: 1%; height: 23px;"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <cc1:TabContainer Style="text-align: left" ID="TabContainer1" runat="server" Width="100%" ActiveTabIndex="1">
                                <cc1:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
                                    <HeaderTemplate>
                                        <span class="column_RightBold">Office Operational Expense</span>
                                    </HeaderTemplate>
                                    <ContentTemplate>
                                        <asp:GridView Style="font-weight: normal" ID="gvppmp" runat="server" Width="100%" SkinID="GridViewAA" AutoGenerateColumns="False"
                                            DataKeyNames="GA_CODE2,GA_TITLE,GA_ID,BGA_ID" EmptyDataText="No Data Found." AllowPaging="True" Font-Size="8pt">
                                            <Columns>
                                                <asp:CommandField ShowSelectButton="True">
                                                    <ItemStyle HorizontalAlign="Center" Width="5%" Font-Underline="false" CssClass="LinkBtnSelect"></ItemStyle>
                                                </asp:CommandField>
                                                <asp:BoundField DataField="ga_title" HeaderText="Account Title">
                                                    <FooterStyle HorizontalAlign="Left"></FooterStyle>

                                                    <ItemStyle HorizontalAlign="Left" Width="60%"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="GA_CODE2" HeaderText="Account Code">
                                                    <ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Amount" DataFormatString="{0:N}" HeaderText="Amount" HtmlEncode="False">
                                                    <ItemStyle HorizontalAlign="Right" Width="20%"></ItemStyle>
                                                </asp:BoundField>
                                            </Columns>
                                        </asp:GridView>
                                    </ContentTemplate>
                                </cc1:TabPanel>
                                <cc1:TabPanel runat="server" HeaderText="TabPanel2" ID="TabPanel2">
                                    <HeaderTemplate>
                                        <span class="column_RightBold">Programs / Projects / Activities</span>
                                    </HeaderTemplate>
                                    <ContentTemplate>
                                        <asp:GridView Style="font-weight: normal" ID="gvPPA" runat="server" Width="100%" CssClass="text" AutoGenerateColumns="False" SkinID="GridViewAA"
                                            DataKeyNames="GA_CODE2,GA_TITLE,PPA,GA_ID,BGA_ID,Program_ID,Project_ID" EmptyDataText="No Data Found." AllowPaging="True" Font-Size="8pt">
                                            <Columns>
                                                <asp:CommandField ShowSelectButton="True">
                                                    <ItemStyle HorizontalAlign="Center" Width="5%" Font-Underline="false" CssClass="LinkBtnSelect"></ItemStyle>
                                                </asp:CommandField>
                                                <asp:BoundField DataField="PPA" HeaderText="PPA">
                                                    <ItemStyle HorizontalAlign="Left" Width="35%"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="ga_title" HeaderText="Account Title">
                                                    <ItemStyle HorizontalAlign="Left" Width="35%"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="GA_CODE2" HeaderText="Account Code">
                                                    <ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Amount" DataFormatString="{0:N}" HeaderText="Amount">
                                                    <ItemStyle HorizontalAlign="Right" Width="10%"></ItemStyle>
                                                </asp:BoundField>
                                            </Columns>
                                        </asp:GridView>
                                    </ContentTemplate>
                                </cc1:TabPanel>
                                <cc1:TabPanel runat="server" HeaderText="TabPanel3" ID="TabPanel3">
                                    <HeaderTemplate>
                                        <span class="column_RightBold">Consolidated</span>
                                    </HeaderTemplate>
                                    <ContentTemplate>
                                        <asp:GridView ID="gvConsolidated" runat="server" Width="100%" Font-Bold="False" CssClass="text" AutoGenerateColumns="False" SkinID="GridViewAA"
                                            DataKeyNames="GA_CODE2,GA_ID,BGA_ID" AllowPaging="True" EmptyDataText="No Data Found." Font-Size="8pt">
                                            <Columns>
                                                <asp:CommandField ShowSelectButton="True">
                                                    <ItemStyle HorizontalAlign="Center" Width="5%" Font-Underline="false" CssClass="LinkBtnSelect"></ItemStyle>
                                                </asp:CommandField>
                                                <asp:BoundField DataField="ga_title" HeaderText="Account Title">
                                                    <ItemStyle HorizontalAlign="Left" Width="60%"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="GA_CODE2" HeaderText="Account Code">
                                                    <ItemStyle HorizontalAlign="Center" Width="20%"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="amount" DataFormatString="{0:N}" HeaderText="Amount">
                                                    <ItemStyle HorizontalAlign="Right" Width="15%"></ItemStyle>
                                                </asp:BoundField>
                                            </Columns>
                                        </asp:GridView>
                                    </ContentTemplate>
                                </cc1:TabPanel>
                            </cc1:TabContainer>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>

                </table>
            </div>




            <%-- PPMP ITEM LIST --%>
            <asp:Panel ID="popup" runat="server" Width="850px" CssClass="Panel_Popup">
                <table width="100%" cellpadding="0px" cellspacing="0px">
                    <tr>
                        <td style="width: 100%; height: 30px" class="DivTitle">Item List
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100%; height: 10px"></td>
                    </tr>
                    <tr>
                        <td style="width: 100%" align="center">
                            <span class="column_RightBold">Search By :</span>
                            &nbsp;<asp:DropDownList runat="server" ID="drpSearchBy" Width="120px" CssClass="drpdownCSS">
                                <asp:ListItem Selected="True" Value="1" Text="Description"></asp:ListItem>
                                <asp:ListItem Value="2" Text="Price"></asp:ListItem>
                            </asp:DropDownList>
                            &nbsp;<asp:TextBox ID="SearchBut" runat="server" Width="200px" CssClass="txtbox_Var"></asp:TextBox>
                            &nbsp;<asp:Button ID="btnSearch" runat="server" Width="120px" CssClass="CSButton" Text="SEARCH"></asp:Button>
                        </td>
                    </tr>
                      <tr>
                        <td style="width: 100%; height: 5px"></td>
                    </tr>
                    <tr>
                        <td style="width: 100%" align="center">
                            <asp:Panel ID="Panel1" runat="server" Width="98%" CssClass="PanelSize_Popup" ScrollBars="Vertical">
                                <asp:GridView ID="gvitems" runat="server" Width="100%" OnSelectedIndexChanged="gvConsolidated_SelectedIndexChanged" 
                                    SkinID="GridViewAA" BackColor="White" PageSize="8" DataKeyNames="item_id" AllowPaging="true" 
                                    OnPageIndexChanging="gvitems_PageIndexChanging" EmptyDataText="No Data Found.">
                                    <Columns>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <asp:CheckBox ID="CheckBox2" runat="server" Font-Bold="true" ForeColor="White" Font-Size="10pt" Font-Names="tahoma" AutoPostBack="true" Text="All" OnCheckedChanged="CheckBox2_CheckedChanged"></asp:CheckBox>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="true" OnCheckedChanged="CheckBox1_CheckedChanged2"></asp:CheckBox>
                                            </ItemTemplate>

                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                            <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                        </asp:TemplateField>

                                        <asp:BoundField DataField="Item_Desc" HeaderText="Description" HtmlEncode="false">
                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                            <ItemStyle HorizontalAlign="Left" Width="70%"></ItemStyle>
                                        </asp:BoundField>

                                        <asp:BoundField DataField="Description" HeaderText="Unit">
                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                            <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
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
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100%;height:10px" align="center"></td>
                    </tr>
                    <tr>
                        <td style="width: 100%" align="center">
                            <asp:Button ID="Button3" runat="server" Width="150px" Text="LOAD" CssClass="CSButton" OnClientClick="StartProgressBar();"></asp:Button>
                            &nbsp;<asp:Button runat="server" ID="btnClose" Width="150px" Text="Close" CssClass="CSButton"/>
                               
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100%; height: 20px"></td>
                    </tr>
                </table>
                 <asp:Label ID="Label3" runat="server"></asp:Label>




               <%-- <table style="width: 747px" cellspacing="0" cellpadding="0" border="0">
                    <tbody>
                        <tr>
                            <td style="background-position: center center; background-image: url(../images/POPUP/modalpopup_02.png); width: 705px; height: 39px" align="center"></td>
                            <td style="background-position: center center; background-image: url(../images/POPUP/modalpopup_03.png); width: 42px; height: 39px">
                                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="../images/modalpopup_03.png"></asp:ImageButton></td>
                        </tr>
                        <tr>
                            <td style="background-image: url(../images/POPUP/modalpopup_04.png); vertical-align: top; width: 705px; height: 446px; text-align: center" align="center">
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>
                                        <table style="width: 695px">
                                            <tbody>
                                                <tr>
                                                    <td style="width: 695px" align="center"><span style="font-size: 9pt; font-family: Arial"><strong>SEARCH :</strong></span>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 695px" align="center"></td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="gvitems" EventName="SelectedIndexChanging"></asp:AsyncPostBackTrigger>
                                    </Triggers>
                                </asp:UpdatePanel>
                                </td>
                            <td style="background-position: center center; background-image: url(../images/POPUP/modalpopup_05.png); width: 42px; height: 446px"></td>
                        </tr>
                    </tbody>
                </table>--%>

            </asp:Panel>
            <cc1:ModalPopupExtender ID="ModalPopupExtender3" runat="server" PopupControlID="popup" BackgroundCssClass="modalBackground" TargetControlID="Label3"></cc1:ModalPopupExtender>
           
            
            
            
            
            <asp:Panel Style="display: none; font-size: 9pt; color: black" ID="pPrintPrev" runat="server" Width="320px" Font-Size="11pt" Font-Names="Tahoma" SkinID="popUpMsgs" HorizontalAlign="Center">
                <br />
                <table style="border-right: gray 1px solid; border-top: gray 1px solid; border-left: gray 1px solid; width: 95%; border-bottom: gray 1px solid; height: 16px" cellspacing="0" cellpadding="0">
                    <tbody>
                        <tr>
                            <td style="width: 30px; text-align: right"><%--<asp:Image id="Image6" runat="server" ImageUrl="~/images/info_image_20px.png"></asp:Image>--%></td>
                            <td style="width: 8px; text-align: left"></td>
                            <td style="text-align: left">
                                <asp:Label Style="background-image: url(images/info_image.jpg)" ID="Label2" runat="server" Font-Bold="true" SkinID="BoldFaced">Print Preview Options</asp:Label></td>
                        </tr>
                    </tbody>
                </table>
                &nbsp;<table style="font-size: 9pt; width: 95%; text-align: left" class="text" cellspacing="1" cellpadding="1">
                    <tbody>
                        <tr>
                            <td style="text-align: center" colspan="4">
                                <asp:RadioButtonList Style="text-align: left" ID="rblPP" runat="server" Width="256px">
                                    <asp:ListItem Value="0">Selected Account</asp:ListItem>
                                    <asp:ListItem Value="1">Consolidated PPMP (OOE)</asp:ListItem>
                                    <asp:ListItem Value="2">Consolidated PPMP (P/P/A)</asp:ListItem>
                                    <asp:ListItem Value="3">Detailed PPMP (OOE &amp; P/P/A)</asp:ListItem>
                                </asp:RadioButtonList></td>
                        </tr>
                        <tr>
                            <td style="height: 15px" colspan="4"></td>
                        </tr>
                        <tr>
                            <td style="height: 15px; text-align: center" colspan="4">
                                <asp:Button ID="btnPrintOK" OnClick="btnPrintOK_Click" runat="server" Width="64px" Text="OK" SkinID="button"></asp:Button>
                                <asp:Button ID="Button4" runat="server" Width="64px" Text="Cancel" SkinID="button"></asp:Button></td>
                        </tr>
                    </tbody>
                </table>
                <br />
                <asp:Label ID="Label5" runat="server"></asp:Label>
            </asp:Panel>
            <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" PopupControlID="pPrintPrev" BackgroundCssClass="modalBackground" TargetControlID="Label5" CancelControlID="Button4">
            </cc1:ModalPopupExtender>



            <%-- FOR REPAIR --%>
            <asp:Panel Style="display: none" ID="PanelRepair" runat="server" Width="900px">
                <table id="table1" cellspacing="0" cellpadding="0" width="747" border="0">
                    <tbody>
                        <tr>
                            <td colspan="2"></td>
                        </tr>
                        <tr>
                            <td style="background-image: url(../images/modalpopup_02.png); width: 772px; height: 39px"></td>
                            <td style="width: 34px; height: 39px">
                                <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="../images/modalpopup_03.png"></asp:ImageButton></td>
                        </tr>
                        <tr>
                            <td style="background-image: url(../images/modalpopup_04.png); vertical-align: top; width: 772px" id="Td1">
                                <table style="width: 705px; height: 336px" cellspacing="0" cellpadding="0" border="0">
                                    <tbody>
                                        <tr>
                                            <td style="vertical-align: top; width: 4%; text-align: center"></td>
                                            <td style="vertical-align: top; width: 100%; text-align: center">
                                                <table style="width: 100%">
                                                    <tbody>
                                                        <tr>
                                                            <td style="width: 100%" class="column_LeftBold">
                                                                <table style="width: 100%" class="PageTitle">
                                                                    <tbody>
                                                                        <tr>
                                                                            <td style="width: 1000px">
                                                                                <asp:Label ID="lblRepairItems" runat="server" Width="500px" Font-Size="12pt"></asp:Label></td>
                                                                        </tr>
                                                                    </tbody>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 100%">
                                                                <asp:GridView ID="gvRepairs" runat="server" Width="90%" CssClass="text" OnSelectedIndexChanged="gvRepairs_SelectedIndexChanged" AutoGenerateColumns="False" SkinID="gvnew" CaptionAlign="Left" UseAccessibleHeader="False" PageSize="8" DataKeyNames="PropertyDetai_ID,PropertyNo,Item_ID" AllowPaging="true" OnPageIndexChanging="gvRepairs_PageIndexChanging">
                                                                    <Columns>
                                                                        <asp:TemplateField ShowHeader="False">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="LinkButton1" runat="server" Width="30px" CausesValidation="False" ForeColor="Blue" Text="Select" CommandName="Select" Font-Underline="False"></asp:LinkButton>
                                                                            </ItemTemplate>

                                                                            <ItemStyle HorizontalAlign="Left" Width="10%"></ItemStyle>
                                                                        </asp:TemplateField>
                                                                        <asp:BoundField DataField="Item_Desc" HeaderText="Item Description">
                                                                            <ItemStyle Width="60%"></ItemStyle>
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="PropertyNo" HeaderText="Property No.">
                                                                            <ItemStyle Width="30%"></ItemStyle>
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="Item_ID" HeaderText="Item_ID" Visible="False"></asp:BoundField>
                                                                    </Columns>

                                                                    <SelectedRowStyle Font-Bold="False"></SelectedRowStyle>

                                                                    <HeaderStyle Font-Names="Arial" Font-Size="8pt"></HeaderStyle>
                                                                </asp:GridView>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 100%">
                                                                <table style="width: 100%">
                                                                    <tbody>
                                                                        <tr>
                                                                            <td style="width: 15%" class="column_LeftBold">Item Description:</td>
                                                                            <td style="width: 35%" class="column_Left">
                                                                                <asp:TextBox ID="txtItemDesc" runat="server" Width="80%" CssClass="txtboxinspection"></asp:TextBox></td>
                                                                            <td style="width: 15%" class="column_LeftBold">Property No. :</td>
                                                                            <td style="width: 35%" class="column_Left">
                                                                                <asp:TextBox ID="txtPropertyNo" runat="server" Width="80%" CssClass="txtboxinspection"></asp:TextBox></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="width: 15%" class="column_LeftBold">Nature of Repair:</td>
                                                                            <td style="width: 35%" class="column_Left">
                                                                                <asp:TextBox ID="txtNatureRepair" runat="server" Width="80%" CssClass="txtboxinspection"></asp:TextBox>
                                                                                <asp:Label Style="position: relative" ID="lblreq" runat="server" ForeColor="Red" Text="*" Visible="False"></asp:Label></td>
                                                                            <td style="width: 15%" class="column_LeftBold">Invoice No. :</td>
                                                                            <td style="width: 35%" class="column_Left">
                                                                                <asp:TextBox ID="txtInvoiceNo" runat="server" Width="80%" CssClass="txtboxinspection"></asp:TextBox></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="width: 15%" class="column_LeftBold">Service Provider:</td>
                                                                            <td style="width: 35%" class="column_Left">
                                                                                <asp:TextBox ID="txtServiceProvider" runat="server" Width="80%" CssClass="txtboxinspection"></asp:TextBox></td>
                                                                            <td style="width: 15%" class="column_LeftBold">Date :</td>
                                                                            <td style="width: 35%" class="column_Left">
                                                                                <asp:TextBox ID="txtrepairDate" runat="server" Width="60%" CssClass="txtboxinspection"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="width: 15%" class="column_LeftBold"></td>
                                                                            <td style="width: 35%" class="column_Left"></td>
                                                                            <td style="width: 15%" class="column_LeftBold"></td>
                                                                            <td style="width: 35%" class="column_Left">
                                                                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtrepairDate" PopupButtonID="ImageButton3"></cc1:CalendarExtender>
                                                                            </td>
                                                                        </tr>
                                                                    </tbody>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 100%">
                                                                <asp:Button ID="btnOK" OnClick="btnOK_Click" runat="server" Width="90px" Text="SAVE" SkinID="button"></asp:Button><asp:Button ID="btnCancel" runat="server" Width="90px" Text="Cancel" SkinID="button"></asp:Button></td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 100%">
                                                                <asp:Label ID="Label1" runat="server"></asp:Label></td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 4%; height: 24px; text-align: center"></td>
                                            <td style="width: 100%; height: 24px; text-align: center"></td>
                                        </tr>
                                    </tbody>
                                </table>
                                <span style="color: black"></span></td>
                            <td style="background-image: url(../images/modalpopup_05.png); width: 34px; height: 446px"></td>
                        </tr>
                    </tbody>
                </table>
            </asp:Panel>
            <cc1:ModalPopupExtender ID="ModalPopupExtender2" runat="server" PopupControlID="PanelRepair" BackgroundCssClass="modalBackground" TargetControlID="Label1" CancelControlID="btnCancel"></cc1:ModalPopupExtender>



            <asp:Panel Style="border-top-width: 1px; border-left-width: 1px; border-left-color: #0033cc; border-bottom-width: 1px; border-bottom-color: #0033cc; border-top-color: #0033cc; background-color: transparent; text-align: center; border-right-width: 1px; border-right-color: #0033cc" ID="PanelProgress" runat="server" Width="109px">
                <img alt="" src="../images/ajax-loader.gif" />
            </asp:Panel>
            <cc1:ModalPopupExtender ID="ProgressBarModalPopupExtender" runat="server" PopupControlID="PanelProgress" BackgroundCssClass="modalBackground" TargetControlID="ButtonProgress" BehaviorID="ProgressBarModalPopupExtender"></cc1:ModalPopupExtender>
            <asp:Button Style="border-top-style: none; border-right-style: none; border-left-style: none; background-color: transparent; border-bottom-style: none" ID="ButtonProgress" runat="server" Width="16px" Enabled="False"></asp:Button>&nbsp; 
        </ContentTemplate>




    </asp:UpdatePanel>
</asp:Content>
