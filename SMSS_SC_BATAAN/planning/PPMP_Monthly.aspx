<%@ Page Title="PPMP Monthly" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="PPMP_Monthly.aspx.vb"
    Inherits="planning_PPMP_Monthly" StylesheetTheme="SkinFile" MaintainScrollPositionOnPostback="true" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<script runat="server">



</script>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <script type="text/javascript">
        function HighlightAll(txtObj) {
            txtObj.select();
        }
    </script>

    <%--<script type="text/javascript">
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

    </script>--%>

    <script type="text/javascript">
        // It is important to place this JavaScript code after ScriptManager1
        var xPos2, yPos2;
        var prm2 = Sys.WebForms.PageRequestManager.getInstance();

        function BeginRequestHandler(sender, args) {
            if ($get('<%=PanelQty.ClientID%>') != null) {
                // Get X and Y positions of scrollbar before the partial postback
                xPos2 = $get('<%=PanelQty.ClientID%>').scrollLeft;
                yPos2 = $get('<%=PanelQty.ClientID%>').scrollTop;
            }
        }

        function EndRequestHandler(sender, args) {
            if ($get('<%=PanelQty.ClientID%>') != null) {
                // Set X and Y positions back to the scrollbar
                // after partial postback
                $get('<%=PanelQty.ClientID%>').scrollLeft = xPos2;
                $get('<%=PanelQty.ClientID%>').scrollTop = yPos2;
            }
        }

        prm2.add_beginRequest(BeginRequestHandler);
        prm2.add_endRequest(EndRequestHandler);


    </script>

    <script type="text/javascript">
        // It is important to place this JavaScript code after ScriptManager1
        var xPos3, yPos3;
        var prm3 = Sys.WebForms.PageRequestManager.getInstance();

        function BeginRequestHandler3(sender, args) {
            if ($get('<%=PnlPopItems.ClientID%>') != null) {
                // Get X and Y positions of scrollbar before the partial postback
                xPos3 = $get('<%=PnlPopItems.ClientID%>').scrollLeft;
                yPos3 = $get('<%=PnlPopItems.ClientID%>').scrollTop;
            }
        }

        function EndRequestHandler3(sender, args) {
            if ($get('<%=PnlPopItems.ClientID%>') != null) {
                // Set X and Y positions back to the scrollbar
                // after partial postback
                $get('<%=PnlPopItems.ClientID%>').scrollLeft = xPos3;
                $get('<%=PnlPopItems.ClientID%>').scrollTop = yPos3;
            }
        }

        prm3.add_beginRequest(BeginRequestHandler3);
        prm3.add_endRequest(EndRequestHandler3);

    </script>


    <script type="text/javascript"> 

        function stopRKey(evt) {
            var evt = (evt) ? evt : ((event) ? event : null);
            var node = (evt.target) ? evt.target : ((evt.srcElement) ? evt.srcElement : null);
            if ((evt.keyCode == 13) && (node.type == "text")) {
                return false;
            }
        }

        document.onkeypress = stopRKey;

    </script>


    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <div runat="server" id="divContent">
                <table width="100%">
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
                                    <tr>
                                        <td style="width: 20%" class="column_RightBold">Calendar Year : </td>
                                        <td style="width: 80%" class="column_Left">
                                            <asp:DropDownList ID="ddyear" runat="server" CssClass="drpdownCSS" Width="100px" AutoPostBack="true">
                                            </asp:DropDownList>
                                            &nbsp;<span class="column_RightBold">Date : </span>
                                            &nbsp;<asp:TextBox ID="txtDate" runat="server" Width="100px" CssClass="txtbox_Date" Enabled="False"></asp:TextBox>
                                            &nbsp;<span class="column_RightBold">Status : </span>
                                            &nbsp;<asp:Label ID="lblappstatus" runat="server" CssClass="column_LeftBold" ForeColor="Red"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr style="color: #000000">
                                        <td style="width: 20%" class="column_RightBold">Department : </td>
                                        <td style="width: 80%" class="column_Left">
                                            <asp:DropDownList ID="ddRC" runat="server" Width="75%" AutoPostBack="true" CssClass="drpdownCSS" Enabled="False">
                                                <asp:ListItem Value="0">Select</asp:ListItem>
                                            </asp:DropDownList></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 20%" class="column_RightBold">Function : </td>
                                        <td style="width: 80%" class="column_Left">
                                            <asp:DropDownList ID="ddFunction" runat="server" Width="75%" AutoPostBack="true" CssClass="drpdownCSS" Enabled="False">
                                                <asp:ListItem Value="0">Select</asp:ListItem>
                                            </asp:DropDownList></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 20%" class="column_RightBold">Programs/ Projects/ Activities :</td>
                                        <td style="width: 80%" class="column_Left">
                                            <asp:DropDownList ID="ddPPA" runat="server" CssClass="drpdownCSS" Width="75%" AutoPostBack="true" Enabled="False">
                                                <asp:ListItem Value="0">Select</asp:ListItem>
                                            </asp:DropDownList></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 20%" class="column_RightBold">Expense Class :</td>
                                        <td style="width: 80%" class="column_Left">
                                            <asp:DropDownList ID="ddAllotmentType" runat="server" CssClass="drpdownCSS" Width="20%" AppendDataBoundItems="true" AutoPostBack="true" Enabled="False">
                                                <asp:ListItem Value="0">Select</asp:ListItem>
                                                <asp:ListItem Value="2">MOOE</asp:ListItem>
                                                <asp:ListItem Value="3">Capital Outlay</asp:ListItem>
                                            </asp:DropDownList>
                                            &nbsp;<asp:CheckBox ID="chkOOE" runat="server" AutoPostBack="true" CssClass="rbCS_Horizontal" Text="OOE" Enabled="false"></asp:CheckBox>
                                            &nbsp; |
                                            &nbsp;<asp:CheckBox ID="cbWOGoods" runat="server" AutoPostBack="true" CssClass="rbCS_Horizontal" Text="Without Goods" Enabled="false"></asp:CheckBox>
                                            &nbsp; |
                                            &nbsp;<asp:CheckBox ID="cbInfra" runat="server" AutoPostBack="true" CssClass="rbCS_Horizontal" Text="Infra" Enabled="false"></asp:CheckBox>

                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 20%" class="column_RightBold">Account Title : </td>
                                        <td style="width: 80%" class="column_Left">
                                            <div>
                                                
                                                <asp:DropDownList ID="ddGenAccount"  runat="server" AutoPostBack="true" CssClass="drpdownCSS" Width="75%"  Enabled="False">
                                                    <asp:ListItem Value="0">Select</asp:ListItem>
                                                </asp:DropDownList>
                                                &nbsp;<asp:LinkButton ID="lnkView" runat="server" ForeColor="#00C000" CssClass="LinkBtnPreview" Text="View List of Goods" Enabled="true"></asp:LinkButton>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 20%" class="column_RightBold">General Description :
                                        </td>
                                        <td style="width: 80%" class="column_Left">
                                            <asp:TextBox runat="server" ID="txtGenDesc" Width="75%" CssClass="txtbox_Var" Enabled="false"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 20%; height: 10px" class="column_RightBold"></td>
                                        <td style="width: 80%" class="column_Left"></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100%" colspan="100%" class="column_RightBold">
                                            <table width="100%">
                                                <tr>
                                                    <td style="width: 20%" class="column_RightBold">Appropriate Budget :</td>
                                                    <td style="width: 30%" class="column_Left">
                                                        <asp:TextBox ID="txtBudgetCeiling" runat="server" Visible="false" CssClass="txtbox_Amt" Width="120px" ReadOnly="true" Text="0.00"></asp:TextBox>
                                                        <asp:TextBox ID="txtbudget" runat="server" CssClass="txtbox_Amt" ReadOnly="False" Text="0.00" Width="120px" Visible="True"></asp:TextBox>
                                                        <asp:Label ID="lblpromt" runat="server" Font-Italic="true" Font-Size="8pt" ForeColor="Red" Text="No Allocated Budget" Visible="false"></asp:Label>
                                                    </td>
                                                    <td style="width: 20%" class="column_RightBold">&nbsp;</td>
                                                    <td style="width: 30%" class="column_Left">
                                                        &nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 20%" class="column_RightBold">Available Budget :</td>
                                                    <td style="width: 30%" class="column_Left">
                                                        <asp:TextBox ID="txtAvailableAmt" runat="server" Visible="false" CssClass="txtbox_Amt" Width="120px" ReadOnly="true" Text="0.00"></asp:TextBox>
                                                        &nbsp;<asp:TextBox ID="txtAvailableBudget" runat="server" CssClass="txtbox_Amt" ReadOnly="true" Text="0.00" Width="120px"></asp:TextBox>
                                                        <asp:Label ID="lblAvailableAmt" runat="server" ForeColor="Red" Font-Size="8pt" Text="Adjust your PPMP." Font-Italic="true" Visible="false"></asp:Label>
                                                        <asp:Label ID="lblAvailableBudget" runat="server" Font-Italic="true" Font-Size="8pt" ForeColor="Red" Text="Adjust your PPMP." Visible="false"></asp:Label>
                                                    </td>
                                                    <td style="width: 20%" class="column_RightBold">&nbsp;</td>
                                                    <td style="width: 30%" class="column_Left">
                                                        &nbsp;</td>
                                                </tr>

                                            </table>
                                            <asp:HiddenField ID="hdfppaprojId" runat="server" />
                                            <asp:HiddenField ID="hdfppaprogId" runat="server" />
                                        </td>
                                    </tr>

                                </tbody>
                            </table>

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
                        <td style="width: 98%" class="DivTitle">Schedule / Milestone Of Activities                          
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="left">
                            <asp:Label runat="server" ID="lblItemsDesc" Visible="false" Text="" CssClass="column_LeftBold"></asp:Label>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>




                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <table width="80%">
                                <tr>
                                    <td style="width: 25%" align="right">
                                        <asp:RadioButtonList runat="server" ID="rbQty" CssClass="rbCS_Horizontal" RepeatDirection="Horizontal" Enabled="false">
                                            <asp:ListItem>Quantity</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                    <td style="width: 20%" align="left">
                                        <asp:TextBox runat="server" ID="txtTotalQty" Width="60%" CssClass="txtbox_Amt" Enabled="false" AutoPostBack="true"  Text="0" OnTextChanged="txtTotalQty_TextChanged"></asp:TextBox>
                                        <cc1:FilteredTextBoxExtender runat="server" ID="FilteredTextBoxExtender1_txtTotalQty" TargetControlID="txtTotalQty" ValidChars="1234567890.,"></cc1:FilteredTextBoxExtender>

                                    </td>
                                    <td style="width: 20%" align="right">
                                        <asp:RadioButtonList runat="server" ID="rbAmount" CssClass="rbCS_Horizontal" RepeatDirection="Horizontal" Enabled="false">
                                            <asp:ListItem>Amount</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                    <td style="width: 35%" align="left">
                                        <asp:TextBox runat="server" ID="txtTotalAmt" Width="40%" CssClass="txtbox_Amt" Enabled="false" AutoPostBack="true" OnTextChanged="txtTotalAmt_TextChanged" Text="0.00"></asp:TextBox>
                                        <cc1:FilteredTextBoxExtender runat="server" ID="FilteredTextBoxExtender_txtTotalAmt" TargetControlID="txtTotalAmt" ValidChars="1234567890.,"></cc1:FilteredTextBoxExtender>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>

                                    <asp:MultiView runat="server" ID="mvSchedule">
                                        <asp:View runat="server" ID="vwWithGoods">
                                            <asp:Panel runat="server" ID="PanelQty" ScrollBars="Vertical">
                                                <asp:GridView ID="grdQty" runat="server" Width="100%" AutoGenerateColumns="False" SkinID="GridViewAA" CaptionAlign="Left"
                                                    EmptyDataText="No Data Found.">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Jan">
                                                            <HeaderTemplate>
                                                                <span>Jan</span>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <table width="100%">
                                                                    <tr>
                                                                        <td style="width: 100%" align="center">
                                                                            <asp:TextBox ID="txtJan" runat="server" OnTextChanged="txtJan_TextChanged" Width="95%" AutoPostBack="true" CssClass="txtbox_Amt" Text='<%#Bind("Jan") %>' SkinID="text"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr runat="server" id="trJan">
                                                                        <td style="width: 100%" align="center">
                                                                            <asp:Label ID="lblJan" runat="server" CssClass="column_Right" Font-Size="8pt" Width="95%" Text='<%#Bind("JanAmt", "{0:N}") %>'></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtJan" ValidChars="0123456789."></cc1:FilteredTextBoxExtender>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" Width="7.69%"></ItemStyle>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Feb">
                                                            <HeaderTemplate>
                                                                <span>Feb</span>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <table width="100%">
                                                                    <tr>
                                                                        <td style="width: 100%" align="center">
                                                                            <asp:TextBox ID="txtFeb" runat="server" OnTextChanged="txtFeb_TextChanged" Width="95%" AutoPostBack="true" CssClass="txtbox_Amt" Text='<%#Bind("Feb") %>' SkinID="text"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr runat="server" id="trFeb">
                                                                        <td style="width: 100%" align="center">
                                                                            <asp:Label ID="lblFeb" runat="server" CssClass="column_Right" Font-Size="8pt" Width="95%" Text='<%#Bind("FebAmt", "{0:N}") %>'></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtFeb" ValidChars="0123456789."></cc1:FilteredTextBoxExtender>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" Width="7.69%"></ItemStyle>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Mar">
                                                            <HeaderTemplate>
                                                                <span>Mar</span>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <table width="100%">
                                                                    <tr>
                                                                        <td style="width: 100%" align="center">
                                                                            <asp:TextBox ID="txtMar" runat="server" Width="95%" OnTextChanged="txtMar_TextChanged" AutoPostBack="true" CssClass="txtbox_Amt" Text='<%#Bind("Mar") %>' SkinID="text"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr runat="server" id="trMar">
                                                                        <td style="width: 100%" align="center">
                                                                            <asp:Label ID="lblMar" runat="server" CssClass="column_Right" Font-Size="8pt" Width="95%" Text='<%#Bind("MarAmt", "{0:N}") %>'></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" TargetControlID="txtMar" ValidChars="0123456789."></cc1:FilteredTextBoxExtender>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" Width="7.69%"></ItemStyle>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Apr">
                                                            <HeaderTemplate>
                                                                <span>Apr</span>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <table width="100%">
                                                                    <tr>
                                                                        <td style="width: 100%" align="center">
                                                                            <asp:TextBox ID="txtApr" runat="server" Width="95%" OnTextChanged="txtApr_TextChanged" AutoPostBack="true" CssClass="txtbox_Amt" Text='<%#Bind("Apr") %>' SkinID="text"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr runat="server" id="trApr">
                                                                        <td style="width: 100%" align="center">
                                                                            <asp:Label ID="lblApr" runat="server" CssClass="column_Right" Font-Size="8pt" Width="95%" Text='<%#Bind("AprAmt", "{0:N}") %>'></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" TargetControlID="txtApr" ValidChars="0123456789."></cc1:FilteredTextBoxExtender>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" Width="7.69%"></ItemStyle>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="May">
                                                            <HeaderTemplate>
                                                                <span>May</span>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <table width="100%">
                                                                    <tr>
                                                                        <td style="width: 100%" align="center">
                                                                            <asp:TextBox ID="txtMay" runat="server" Width="95%" OnTextChanged="txtMay_TextChanged" AutoPostBack="true" CssClass="txtbox_Amt" Text='<%#Bind("May") %>' SkinID="text"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr runat="server" id="trMay">
                                                                        <td style="width: 100%" align="center">
                                                                            <asp:Label ID="lblMay" runat="server" CssClass="column_Right" Font-Size="8pt" Width="95%" Text='<%#Bind("MayAmt", "{0:N}") %>'></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" TargetControlID="txtMay" ValidChars="0123456789."></cc1:FilteredTextBoxExtender>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" Width="7.69%"></ItemStyle>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Jun">
                                                            <HeaderTemplate>
                                                                <span>Jun</span>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <table width="100%">
                                                                    <tr>
                                                                        <td style="width: 100%" align="center">
                                                                            <asp:TextBox ID="txtJun" runat="server" Width="95%" OnTextChanged="txtJun_TextChanged" AutoPostBack="true" CssClass="txtbox_Amt" Text='<%#Bind("Jun") %>' SkinID="text"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr runat="server" id="trJun">
                                                                        <td style="width: 100%" align="center">
                                                                            <asp:Label ID="lblJun" runat="server" CssClass="column_Right" Font-Size="8pt" Width="95%" Text='<%#Bind("JunAmt", "{0:N}") %>'></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server" TargetControlID="txtJun" ValidChars="0123456789."></cc1:FilteredTextBoxExtender>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" Width="7.69%"></ItemStyle>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Jul">
                                                            <HeaderTemplate>
                                                                <span>Jul</span>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <table width="100%">
                                                                    <tr>
                                                                        <td style="width: 100%" align="center">
                                                                            <asp:TextBox ID="txtJul" runat="server" Width="95%" OnTextChanged="txtJul_TextChanged" AutoPostBack="true" CssClass="txtbox_Amt" Text='<%#Bind("Jul") %>' SkinID="text"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr runat="server" id="trJul">
                                                                        <td style="width: 100%" align="center">
                                                                            <asp:Label ID="lblJul" runat="server" CssClass="column_Right" Font-Size="8pt" Width="95%" Text='<%#Bind("JulAmt", "{0:N}") %>'></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" runat="server" TargetControlID="txtJul" ValidChars="0123456789."></cc1:FilteredTextBoxExtender>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" Width="7.69%"></ItemStyle>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Aug">
                                                            <HeaderTemplate>
                                                                <span>Aug</span>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <table width="100%">
                                                                    <tr>
                                                                        <td style="width: 100%" align="center">
                                                                            <asp:TextBox ID="txtAug" runat="server" Width="95%" OnTextChanged="txtAug_TextChanged" AutoPostBack="true" CssClass="txtbox_Amt" Text='<%#Bind("Aug") %>' SkinID="text"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr runat="server" id="trAug">
                                                                        <td style="width: 100%" align="center">
                                                                            <asp:Label ID="lblAug" runat="server" CssClass="column_Right" Font-Size="8pt" Width="95%" Text='<%#Bind("AugAmt", "{0:N}") %>'></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" runat="server" TargetControlID="txtAug" ValidChars="0123456789."></cc1:FilteredTextBoxExtender>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" Width="7.69%"></ItemStyle>
                                                        </asp:TemplateField>


                                                        <asp:TemplateField HeaderText="Sep">
                                                            <HeaderTemplate>
                                                                <span>Sep</span>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <table width="100%">
                                                                    <tr>
                                                                        <td style="width: 100%" align="center">
                                                                            <asp:TextBox ID="txtSep" runat="server" Width="95%" OnTextChanged="txtSep_TextChanged" AutoPostBack="true" CssClass="txtbox_Amt" Text='<%#Bind("Sep") %>' SkinID="text"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr runat="server" id="trSep">
                                                                        <td style="width: 100%" align="center">
                                                                            <asp:Label ID="lblSep" runat="server" CssClass="column_Right" Font-Size="8pt" Width="95%" Text='<%#Bind("SepAmt", "{0:N}") %>'></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender9" runat="server" TargetControlID="txtSep" ValidChars="0123456789."></cc1:FilteredTextBoxExtender>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" Width="7.69%"></ItemStyle>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Oct">
                                                            <HeaderTemplate>
                                                                <span>Oct</span>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <table width="100%">
                                                                    <tr>
                                                                        <td style="width: 100%" align="center">
                                                                            <asp:TextBox ID="txtOct" runat="server" Width="95%" OnTextChanged="txtOct_TextChanged" AutoPostBack="true" CssClass="txtbox_Amt" Text='<%#Bind("Oct") %>' SkinID="text"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr runat="server" id="trOct">
                                                                        <td style="width: 100%" align="center">
                                                                            <asp:Label ID="lblOct" runat="server" CssClass="column_Right" Font-Size="8pt" Width="95%" Text='<%#Bind("OctAmt", "{0:N}") %>'></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender10" runat="server" TargetControlID="txtOct" ValidChars="0123456789."></cc1:FilteredTextBoxExtender>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" Width="7.69%"></ItemStyle>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Nov">
                                                            <HeaderTemplate>
                                                                <span>Nov</span>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <table width="100%">
                                                                    <tr>
                                                                        <td style="width: 100%" align="center">
                                                                            <asp:TextBox ID="txtNov" runat="server" Width="95%" OnTextChanged="txtNov_TextChanged" AutoPostBack="true" CssClass="txtbox_Amt" Text='<%#Bind("Nov") %>' SkinID="text"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr runat="server" id="trNov">
                                                                        <td style="width: 100%" align="center">
                                                                            <asp:Label ID="lblNov" runat="server" CssClass="column_Right" Font-Size="8pt" Width="95%" Text='<%#Bind("NovAmt", "{0:N}") %>'></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender11" runat="server" TargetControlID="txtNov" ValidChars="0123456789."></cc1:FilteredTextBoxExtender>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" Width="7.69%"></ItemStyle>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Dec">
                                                            <HeaderTemplate>
                                                                <span>Dec</span>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <table width="100%">
                                                                    <tr>
                                                                        <td style="width: 100%" align="center">
                                                                            <asp:TextBox ID="txtDec" runat="server" Width="95%" OnTextChanged="txtDec_TextChanged" AutoPostBack="true" CssClass="txtbox_Amt" Text='<%#Bind("Dec") %>' SkinID="text"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr runat="server" id="trDec">
                                                                        <td style="width: 100%" align="center">
                                                                            <asp:Label ID="lblDec" runat="server" CssClass="column_Right" Font-Size="8pt" Width="95%" Text='<%#Bind("DecAmt", "{0:N}") %>'></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender12" runat="server" TargetControlID="txtDec" ValidChars="0123456789."></cc1:FilteredTextBoxExtender>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" Width="7.69%"></ItemStyle>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Reserved">
                                                            <HeaderTemplate>
                                                                <span>Reserved</span>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <table width="100%">
                                                                    <tr>
                                                                        <td style="width: 100%" align="center">
                                                                            <asp:TextBox ID="txtRQty" runat="server" Width="95%" CssClass="txtbox_Amt" Text='<%#Bind("RQty") %>' SkinID="text" ReadOnly="true"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr runat="server" id="trRQty">
                                                                        <td style="width: 100%" align="center">
                                                                            <asp:Label ID="lblRQty" runat="server" CssClass="column_Right" Font-Size="8pt" Width="95%" Text='<%#Bind("RQtyAmt", "{0:N}") %>'></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender13" runat="server" TargetControlID="txtRQty" ValidChars="0123456789."></cc1:FilteredTextBoxExtender>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" Width="7.69%"></ItemStyle>
                                                        </asp:TemplateField>

                                                    </Columns>
                                                </asp:GridView>

                                            </asp:Panel>
                                        </asp:View>

                                        <asp:View runat="server" ID="vwWithOutGoods">
                                            <asp:GridView ID="grdAmounts" runat="server" Width="100%" AutoGenerateColumns="False" SkinID="GridViewAA" CaptionAlign="Left"
                                                EmptyDataText="No Data Found.">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Jan">
                                                        <HeaderTemplate>
                                                            <span>Jan</span>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <table width="100%">
                                                                <tr>
                                                                    <td style="width: 100%" align="center">
                                                                        <asp:TextBox ID="txtJanAmt" runat="server" OnTextChanged="txtJanAmt_TextChanged" Width="95%" AutoPostBack="true" CssClass="txtbox_Amt" Text='<%#Bind("JanAmt") %>' SkinID="text"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtJanAmt" ValidChars="0123456789,."></cc1:FilteredTextBoxExtender>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" Width="7.69%"></ItemStyle>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Feb">
                                                        <HeaderTemplate>
                                                            <span>Feb</span>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <table width="100%">
                                                                <tr>
                                                                    <td style="width: 100%" align="center">
                                                                        <asp:TextBox ID="txtFebAmt" runat="server" OnTextChanged="txtFebAmt_TextChanged" Width="95%" AutoPostBack="true" CssClass="txtbox_Amt" Text='<%#Bind("FebAmt") %>' SkinID="text"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtFebAmt" ValidChars="0123456789,."></cc1:FilteredTextBoxExtender>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" Width="7.69%"></ItemStyle>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Mar">
                                                        <HeaderTemplate>
                                                            <span>Mar</span>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <table width="100%">
                                                                <tr>
                                                                    <td style="width: 100%" align="center">
                                                                        <asp:TextBox ID="txtMarAmt" runat="server" Width="95%" OnTextChanged="txtMarAmt_TextChanged" AutoPostBack="true" CssClass="txtbox_Amt" Text='<%#Bind("MarAmt") %>' SkinID="text"></asp:TextBox>
                                                                    </td>
                                                                </tr>

                                                            </table>
                                                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" TargetControlID="txtMarAmt" ValidChars="0123456789,."></cc1:FilteredTextBoxExtender>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" Width="7.69%"></ItemStyle>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Apr">
                                                        <HeaderTemplate>
                                                            <span>Apr</span>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <table width="100%">
                                                                <tr>
                                                                    <td style="width: 100%" align="center">
                                                                        <asp:TextBox ID="txtAprAmt" runat="server" Width="95%" OnTextChanged="txtAprAmt_TextChanged" AutoPostBack="true" CssClass="txtbox_Amt" Text='<%#Bind("AprAmt") %>' SkinID="text"></asp:TextBox>
                                                                    </td>
                                                                </tr>

                                                            </table>
                                                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" TargetControlID="txtAprAmt" ValidChars="0123456789,."></cc1:FilteredTextBoxExtender>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" Width="7.69%"></ItemStyle>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="May">
                                                        <HeaderTemplate>
                                                            <span>May</span>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <table width="100%">
                                                                <tr>
                                                                    <td style="width: 100%" align="center">
                                                                        <asp:TextBox ID="txtMayAmt" runat="server" Width="95%" OnTextChanged="txtMayAmt_TextChanged" AutoPostBack="true" CssClass="txtbox_Amt" Text='<%#Bind("MayAmt") %>' SkinID="text"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" TargetControlID="txtMayAmt" ValidChars="0123456789,."></cc1:FilteredTextBoxExtender>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" Width="7.69%"></ItemStyle>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Jun">
                                                        <HeaderTemplate>
                                                            <span>Jun</span>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <table width="100%">
                                                                <tr>
                                                                    <td style="width: 100%" align="center">
                                                                        <asp:TextBox ID="txtJunAmt" runat="server" Width="95%" OnTextChanged="txtJunAmt_TextChanged" AutoPostBack="true" CssClass="txtbox_Amt" Text='<%#Bind("JunAmt") %>' SkinID="text"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server" TargetControlID="txtJunAmt" ValidChars="0123456789,."></cc1:FilteredTextBoxExtender>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" Width="7.69%"></ItemStyle>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Jul">
                                                        <HeaderTemplate>
                                                            <span>Jul</span>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <table width="100%">
                                                                <tr>
                                                                    <td style="width: 100%" align="center">
                                                                        <asp:TextBox ID="txtJulAmt" runat="server" Width="95%" OnTextChanged="txtJulAmt_TextChanged" AutoPostBack="true" CssClass="txtbox_Amt" Text='<%#Bind("JulAmt") %>' SkinID="text"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" runat="server" TargetControlID="txtJulAmt" ValidChars="0123456789,."></cc1:FilteredTextBoxExtender>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" Width="7.69%"></ItemStyle>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Aug">
                                                        <HeaderTemplate>
                                                            <span>Aug</span>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <table width="100%">
                                                                <tr>
                                                                    <td style="width: 100%" align="center">
                                                                        <asp:TextBox ID="txtAugAmt" runat="server" Width="95%" OnTextChanged="txtAugAmt_TextChanged" AutoPostBack="true" CssClass="txtbox_Amt" Text='<%#Bind("AugAmt") %>' SkinID="text"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" runat="server" TargetControlID="txtAugAmt" ValidChars="0123456789,."></cc1:FilteredTextBoxExtender>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" Width="7.69%"></ItemStyle>
                                                    </asp:TemplateField>


                                                    <asp:TemplateField HeaderText="Sep">
                                                        <HeaderTemplate>
                                                            <span>Sep</span>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <table width="100%">
                                                                <tr>
                                                                    <td style="width: 100%" align="center">
                                                                        <asp:TextBox ID="txtSepAmt" runat="server" Width="95%" OnTextChanged="txtSepAmt_TextChanged" AutoPostBack="true" CssClass="txtbox_Amt" Text='<%#Bind("SepAmt") %>' SkinID="text"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender9" runat="server" TargetControlID="txtSepAmt" ValidChars="0123456789,."></cc1:FilteredTextBoxExtender>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" Width="7.69%"></ItemStyle>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Oct">
                                                        <HeaderTemplate>
                                                            <span>Oct</span>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <table width="100%">
                                                                <tr>
                                                                    <td style="width: 100%" align="center">
                                                                        <asp:TextBox ID="txtOctAmt" runat="server" Width="95%" OnTextChanged="txtOctAmt_TextChanged" AutoPostBack="true" CssClass="txtbox_Amt" Text='<%#Bind("OctAmt") %>' SkinID="text"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender10" runat="server" TargetControlID="txtOctAmt" ValidChars="0123456789,."></cc1:FilteredTextBoxExtender>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" Width="7.69%"></ItemStyle>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Nov">
                                                        <HeaderTemplate>
                                                            <span>Nov</span>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <table width="100%">
                                                                <tr>
                                                                    <td style="width: 100%" align="center">
                                                                        <asp:TextBox ID="txtNovAmt" runat="server" Width="95%" OnTextChanged="txtNovAmt_TextChanged" AutoPostBack="true" CssClass="txtbox_Amt" Text='<%#Bind("NovAmt") %>' SkinID="text"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender11" runat="server" TargetControlID="txtNovAmt" ValidChars="0123456789,."></cc1:FilteredTextBoxExtender>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" Width="7.69%"></ItemStyle>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Dec">
                                                        <HeaderTemplate>
                                                            <span>Dec</span>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <table width="100%">
                                                                <tr>
                                                                    <td style="width: 100%" align="center">
                                                                        <asp:TextBox ID="txtDecAmt" runat="server" Width="95%" OnTextChanged="txtDecAmt_TextChanged" AutoPostBack="true" CssClass="txtbox_Amt" Text='<%#Bind("DecAmt") %>' SkinID="text"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender12" runat="server" TargetControlID="txtDecAmt" ValidChars="0123456789,."></cc1:FilteredTextBoxExtender>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" Width="7.69%"></ItemStyle>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Reserved">
                                                        <HeaderTemplate>
                                                            <span>Reserved</span>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <table width="100%">
                                                                <tr>
                                                                    <td style="width: 100%" align="center">
                                                                        <asp:TextBox ID="txtRQtyAmt" runat="server" ReadOnly="true" Width="95%" CssClass="txtbox_Amt" Text='<%#Bind("RQtyAmt") %>' SkinID="text"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender13" runat="server" TargetControlID="txtRQtyAmt" ValidChars="0123456789,."></cc1:FilteredTextBoxExtender>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" Width="7.69%"></ItemStyle>
                                                    </asp:TemplateField>

                                                </Columns>
                                            </asp:GridView>
                                        </asp:View>
                                    </asp:MultiView>



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
                        <td style="width: 98%" align="center">
                            <asp:Label runat="server" ID="lblTotalQtyAmt" Text="Total Available Quantity :" CssClass="column_RightBold"></asp:Label>
                            &nbsp;<asp:TextBox runat="server" ID="txtTotalQtyAmt" Width="8%" CssClass="txtbox_Amt" Text="0" ReadOnly="true"></asp:TextBox>
                            &nbsp; &nbsp;<span class="column_RightBold">Reserved Percentage :</span>
                            &nbsp;<asp:TextBox runat="server" ID="txtReservedPercentage" Width="8%" CssClass="txtbox_Amt" AutoPostBack="true" Text="0" Enabled="false"></asp:TextBox>
                            <span class="column_RightBold" style="font-size: 11pt">%</span>
                            <%--&nbsp; &nbsp;<span class="column_RightBold">Reserved Quantity :</span>
                            &nbsp;<asp:TextBox runat="server" ID="txtReservedQty" Width="8%" CssClass="txtbox_Amt" AutoPostBack="true" Text="0.00"></asp:TextBox>--%>
                            <%--&nbsp; &nbsp;<span class="column_RightBold">Reserved Amount :</span>
                            &nbsp;<asp:TextBox runat="server" ID="txtReservedAmt" Width="8%" CssClass="txtbox_Amt" ReadOnly="true" Text="0.00"></asp:TextBox>--%>
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
                        <td style="width: 98%" class="DivTitle">List Of Goods
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">

                            <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                <ContentTemplate>
                                   <%-- <asp:Panel ID="Panel2" runat="server" Width="98%" CssClass="PanelSize" BorderStyle="Solid" BorderColor="#5c85d6" BorderWidth="1px" HorizontalAlign="Center" ScrollBars="Vertical">
                                        
                                    </asp:Panel>--%>
                                    <asp:GridView ID="grdBody" runat="server" DataKeyNames="Item_ID,ppmp_monthly_dtl_ID"  ShowFooter="True" SkinID="GridViewAA" Width="100%">
                                            <Columns>
                                                <asp:TemplateField ShowHeader="False"><%--ROW 0--%>
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkSelect" runat="server" CausesValidation="False" OnClick="lnkSelect_Click" CommandName="Select" Enabled='<%#Bind("id") %>' Visible='<%# Bind("isVisible") %>' CssClass="LinkBtnSelect" Font-Underline="False" Text="Select"></asp:LinkButton>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" Width="5%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Description"><%--ROW 1--%>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbldesc" runat="server" Text='<%# Bind("Item_Desc") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Left" Width="57%" Height="10px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Unit"><%--ROW 2--%>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblunit" runat="server" Text='<%# Bind("Unit") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" Width="10%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Quantity"><%--ROW 3--%>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblqty" runat="server" Text='<%#Bind("Qty", "{0:#,##0.##}") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Right" Width="7%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField FooterText="TOTAL :" HeaderText="Unit Cost"><%--ROW 4--%>
                                                    <FooterTemplate>
                                                        TOTAL :
                                                    </FooterTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblamount" runat="server" Text='<%# Bind("UnitPrice", "{0:N}") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <FooterStyle Font-Bold="True" HorizontalAlign="Right" />
                                                    <HeaderStyle />
                                                    <ItemStyle HorizontalAlign="Right" Width="8%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Total Amount"><%--ROW 5--%>
                                                    <FooterTemplate>
                                                        <asp:Label ID="lblTotal" runat="server" Font-Bold="true" ForeColor="White" Text="0.00"></asp:Label>
                                                    </FooterTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbltotal0" runat="server" Text='<%# Bind("TotalAmt", "{0:N}") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <FooterStyle Font-Bold="true" ForeColor="White" HorizontalAlign="Right" />
                                                    <HeaderStyle Font-Bold="True" HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Right" Width="10%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField><%--ROW 6--%>
                                                    <ItemTemplate>
                                                        <%--<asp:ImageButton ID="imgDelete" runat="server" OnClick="imgDelete_Click" CommandName="Select" Visible='<%# Bind("isVisible") %>' Height="15px" ImageUrl="~/images/delete.png" OnClientClick="StartProgressBar();" Width="15px" />
                                                        --%>

                                                        <asp:LinkButton runat="server" ID="lnkDelete" CommandName="Select" Text="Delete" CssClass="LinkBtnCancel" Font-Underline="false" OnClick="lnkDelete_Click" Visible='<%# Bind("isVisible") %>' OnClientClick="StartProgressBar();"></asp:LinkButton>
                                                        <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" ConfirmText="Are you sure you want to delete this item?" TargetControlID="lnkDelete">
                                                        </cc1:ConfirmButtonExtender>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" Width="3%" />
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
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
                        <td style="width: 98%" align="center">
                            <table width="90%">
                                <tr>
                                    <td style="width: 15%" class="column_RightBold">Procurement Method :
                                    </td>
                                    <td style="width: 35%" class="column_Left">
                                        <asp:DropDownList runat="server" ID="drpProcurement" Width="75%" CssClass="drpdownCSS">
                                            <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                        </asp:DropDownList>
                                        <span style="color:red"> Optional</span>
                                    </td>
                                    <td style="width: 15%" class="column_LeftBold"></td>
                                    <td style="width: 35%" class="column_Left"></td>
                                </tr>
                                <tr>
                                    <td style="width: 15%; height: 10px" class="column_RightBold"></td>
                                    <td style="width: 35%; height: 10px" class="column_Left"></td>
                                    <td style="width: 15%; height: 10px" class="column_RightBold"></td>
                                    <td style="width: 35%; height: 10px" class="column_Left"></td>
                                </tr>
                                <tr>
                                    <td style="width: 15%" class="column_RightBold">Checked By :
                                    </td>
                                    <td style="width: 35%" class="column_Left">
                                        <asp:DropDownList runat="server" ID="drpCheckedBy" Width="90%" CssClass="drpdownCSS">
                                            <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td style="width: 15%" class="column_RightBold">Noted By :
                                    </td>
                                    <td style="width: 35%" class="column_Left">
                                        <asp:DropDownList runat="server" ID="drpNotedBy" Width="90%" CssClass="drpdownCSS">
                                            <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 15%" class="column_RightBold">Prepared By :
                                    </td>
                                    <td style="width: 35%" class="column_Left">
                                        <asp:DropDownList runat="server" ID="drpPreparedBy" Width="90%" CssClass="drpdownCSS">
                                            <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td style="width: 15%" class="column_RightBold">Approved By :
                                    </td>
                                    <td style="width: 35%" class="column_Left">
                                        <asp:DropDownList runat="server" ID="drpApprovedBy" Width="90%" CssClass="drpdownCSS">
                                            <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>

                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:Button runat="server" ID="btnSave" Width="150px" CssClass="CSButton" Text="SAVE" OnClientClick="StartProgressBar();" />
                            &nbsp;<asp:Button runat="server" ID="btnSubmit" Width="150px" CssClass="CSButton" Text="SUBMIT" Enabled="false" OnClientClick="StartProgressBar();" />
                            &nbsp;<asp:Button runat="server" ID="btnPreview" Width="150px" CssClass="CSButton" Text="PREVIEW" Enabled="false" OnClientClick="StartProgressBar();" />
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
                        <td style="width: 98%" class="DivTitle">Project Procurement Management Plan List
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <cc1:TabContainer Style="text-align: left" ID="TabContainer1" runat="server" Width="98%" ActiveTabIndex="1">


                                <cc1:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
                                    <HeaderTemplate>
                                        <span class="column_RightBold">Office Operational Expense </span>
                                    </HeaderTemplate>
                                    <ContentTemplate>
                                        <asp:GridView ID="gvppmp" runat="server" Width="100%" SkinID="GridViewAA" AutoGenerateColumns="False"
                                            DataKeyNames="GA_Code2,GA_Title,GA_ID,BGA_ID,AllotmentClass_ID,isGoods,forRevision,ReservedPercentage,isInfra,TotalAmt,ppmp_monthly_dtl_ID" EmptyDataText="No Data Found."
                                            AllowPaging="True" PageSize="5">
                                            <Columns>                                                                                           

                                                <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="5%">
                                                    <ItemTemplate>
                                                        <asp:LinkButton runat="server" ID="lnkOOESelect" Text="Select" OnClick="lnkOOESelect_Click" CssClass="LinkBtnSelect" CommandName="Select" OnClientClick="StartProgressBar();"></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="5%">
                                                    <ItemTemplate>
                                                        <asp:LinkButton runat="server" ID="lnkOOEDelete" Text="Remove" OnClick="lnkOOEDelete_Click" CssClass="LinkBtnCancel" CommandName="Select" OnClientClick="StartProgressBar();"></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:BoundField DataField="ga_title" HeaderText="Account Title">
                                                    <ItemStyle HorizontalAlign="Left" Width="55%"></ItemStyle>
                                                </asp:BoundField>

                                                <asp:BoundField DataField="GA_CODE2" HeaderText="Account Code">
                                                    <ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
                                                </asp:BoundField>

                                                <asp:BoundField DataField="TotalAmt" DataFormatString="{0:N}" HeaderText="Amount">
                                                    <ItemStyle HorizontalAlign="Right" Width="20%"></ItemStyle>
                                                </asp:BoundField>
                                            </Columns>
                                        </asp:GridView>
                                    </ContentTemplate>
                                </cc1:TabPanel>



                                <cc1:TabPanel runat="server" HeaderText="TabPanel2" ID="TabPanel2">
                                    <HeaderTemplate>
                                        <span class="column_RightBold">Programs / Projects / Activities </span>
                                    </HeaderTemplate>
                                    <ContentTemplate>
                                        <asp:GridView ID="gvPPA" runat="server" Width="100%" CssClass="text" AutoGenerateColumns="False"
                                            SkinID="GridViewAA" DataKeyNames="GA_Code2,GA_Title,PPA,GA_ID,BGA_ID,Program_ID,Project_ID,AllotmentClass_ID,isGoods,forRevision,ReservedPercentage,isInfra,TotalAmt,ppmp_monthly_dtl_ID" EmptyDataText="No Data Found."
                                            AllowPaging="True" PageSize="5">
                                            <Columns>

                                                <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="5%">
                                                    <ItemTemplate>
                                                        <asp:LinkButton runat="server" ID="lnkPPASelect" Text="Select" OnClick="lnkPPASelect_Click" CssClass="LinkBtnSelect" CommandName="Select" OnClientClick="StartProgressBar();"></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="5%">
                                                    <ItemTemplate>
                                                        <asp:LinkButton runat="server" ID="lnkPPADelete" Text="Remove" OnClick="lnkPPADelete_Click" CssClass="LinkBtnCancel" CommandName="Select" OnClientClick="StartProgressBar();"></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:BoundField DataField="PPA" HeaderText="PPA">
                                                    <ItemStyle HorizontalAlign="Left" Width="30%"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="ga_title" HeaderText="Account Title">
                                                    <ItemStyle HorizontalAlign="Left" Width="38%"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="GA_CODE2" HeaderText="Account Code">
                                                    <ItemStyle HorizontalAlign="Center" Width="12%"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="TotalAmt" DataFormatString="{0:N}" HeaderText="Amount">
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
                                        <asp:GridView ID="gvConsolidated" runat="server" Width="100%" AutoGenerateColumns="False"
                                            SkinID="GridViewAA" DataKeyNames="GA_CODE2,GA_ID,BGA_ID" AllowPaging="True" PageSize="5" EmptyDataText="No Data Found.">
                                            <Columns>
                                                <%--<asp:CommandField ShowSelectButton="True">
                                                    <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                                </asp:CommandField>--%>
                                                <asp:BoundField DataField="ga_title" HeaderText="Account Title">
                                                    <ItemStyle HorizontalAlign="Left" Width="60%"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="GA_CODE2" HeaderText="Account Code">
                                                    <ItemStyle HorizontalAlign="Center" Width="20%"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="TotalAmt" DataFormatString="{0:N}" HeaderText="Amount">
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
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%"></td>
                        <td style="width: 1%"></td>
                    </tr>
                </table>
            </div>



            <%-- POPUP PANEL FOR MESSAGE --%>
            <div>
                <asp:Panel runat="server" ID="pnlMessage" CssClass="PanelMessage" DefaultButton="btnMsgOK">
                    <table width="100%" cellpadding="0px" cellspacing="0px">
                        <tr>
                            <td style="width: 100%; height: 30px" class="DivTitle">Alert!
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 100%; height: 15px"></td>
                        </tr>
                        <tr>
                            <td style="width: 100%" align="center">
                                <asp:Label runat="server" ID="lblMessagePopup" Text="" CssClass="AlertMsg"></asp:Label>
                                <asp:TextBox runat="server" ID="txtHide" Width="0%" Height="0%" BorderStyle="None" BorderColor="Transparent" BackColor="Transparent"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 100%; height: 25px"></td>
                        </tr>
                        <tr>
                            <td style="width: 100%" align="center">
                                <asp:Button runat="server" ID="btnMsgOK" Width="100px" CssClass="CSButton" Text="OK" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 100%; height: 10px">
                                <asp:Label runat="server" ID="lblMessage"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <cc1:ModalPopupExtender ID="ModalPopupExtender_PnlMessage" runat="server" PopupControlID="pnlMessage" BackgroundCssClass="modalBackground" TargetControlID="lblMessage"></cc1:ModalPopupExtender>
            </div>



            <%-- POPUP PANEL FOR LIST OF ITEMS --%>
            <div>
                <asp:Panel runat="server" ID="pnlItems" Width="900px" BackColor="White" CssClass="Panel_Popup">
                    <table width="100%" cellpadding="0px" cellspacing="0px">
                        <tr>
                            <td style="width: 100%; height: 30px" colspan="3" class="DivTitle">List Of Items
                            </td>

                        </tr>
                        <tr>
                            <td style="width: 100%; height: 10px" colspan="3"></td>
                        </tr>
                        <tr>
                            <td style="width: 1%"></td>
                            <td style="width: 98%" align="center">
                                <span class="column_RightBold">Search : </span>
                                &nbsp;<asp:TextBox runat="server" ID="txtSearchItem" Width="200px" CssClass="txtbox_Var"></asp:TextBox>
                                &nbsp;<asp:Button runat="server" ID="btnSearchItem" Width="150px" CssClass="CSButton" Text="SEARCH" />
                            </td>
                            <td style="width: 1%"></td>
                        </tr>
                        <tr>
                            <td style="width: 100%; height: 10px" colspan="3"></td>
                        </tr>

                        <tr>
                            <td style="width: 1%"></td>
                            <td style="width: 98%" align="center">
                                <asp:UpdatePanel ID="UpdatePanel_Items" runat="server">
                                    <ContentTemplate>
                                        <asp:Panel ID="PnlPopItems" runat="server" Width="98%" CssClass="PanelSize_Popup" BorderStyle="Solid" BorderColor="#5c85d6" BorderWidth="1px" HorizontalAlign="Center" ScrollBars="Vertical">
                                            <asp:GridView ID="grdItems" runat="server" Width="100%" EmptyDataText="No Data Found."
                                                SkinID="GridViewAA" BackColor="White" PageSize="10" DataKeyNames="Item_ID" AllowPaging="true">
                                                <Columns>
                                                    <asp:TemplateField><%--ROW 0--%>
                                                        <HeaderTemplate>
                                                            <asp:CheckBox ID="cbAll" runat="server" ForeColor="White" AutoPostBack="true" Text="All" OnCheckedChanged="cbAll_CheckedChanged"></asp:CheckBox>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="cbItem" runat="server" AutoPostBack="true" OnCheckedChanged="cbItem_CheckedChanged"></asp:CheckBox>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                        <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="Item_Desc" HeaderText="Description"><%--ROW 1--%>
                                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                        <ItemStyle HorizontalAlign="Left" Width="70%"></ItemStyle>
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Unit" HeaderText="Unit"><%--ROW 2--%>
                                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="UnitPrice" DataFormatString="{0:N}" HeaderText="Price"><%--ROW 3--%>
                                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                        <ItemStyle HorizontalAlign="Right" Width="15%"></ItemStyle>
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Item_ID" HeaderText="CodeNo" Visible="false"><%--ROW 4--%>
                                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="ID" HeaderText="ID" Visible="false"><%--ROW 5--%>
                                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                    </asp:BoundField>
                                                </Columns>
                                            </asp:GridView>
                                        </asp:Panel>
                                    </ContentTemplate>
                                </asp:UpdatePanel>


                            </td>
                            <td style="width: 1%"></td>
                        </tr>
                        <tr>
                            <td style="width: 100%; height: 10px" colspan="3"></td>
                        </tr>
                        <tr>
                            <td style="width: 1%"></td>
                            <td style="width: 98%" align="center">
                                <asp:Button runat="server" ID="btnLoad" Width="150px" CssClass="CSButton" Text="LOAD" OnClientClick="StartProgressBar();" />
                                &nbsp;<asp:Button runat="server" ID="btnCancel" Width="150px" CssClass="CSButton" Text="CLOSE" OnClientClick="StartProgressBar();" />
                            </td>
                            <td style="width: 1%"></td>
                        </tr>
                        <tr>
                            <td style="width: 1%"></td>
                            <td style="width: 98%" align="center">
                                <asp:Label runat="server" ID="lblItems"></asp:Label>
                            </td>
                            <td style="width: 1%"></td>
                        </tr>
                        <tr>
                            <td style="width: 1%"></td>
                            <td style="width: 98%; height: 20px" align="center"></td>
                            <td style="width: 1%"></td>
                        </tr>
                    </table>
                </asp:Panel>

                <cc1:ModalPopupExtender ID="ModalPopupExtender_Items" runat="server" PopupControlID="pnlItems" BackgroundCssClass="modalBackground" TargetControlID="lblItems"></cc1:ModalPopupExtender>

            </div>







            <asp:Panel Style="border-top-width: 1px; border-left-width: 1px; border-left-color: #0033cc; border-bottom-width: 1px; border-bottom-color: #0033cc; border-top-color: #0033cc; background-color: transparent; text-align: center; border-right-width: 1px; border-right-color: #0033cc" ID="PanelProgress" runat="server" Width="109px">
                <img alt="" src="../images/ajax-loader.gif" />
            </asp:Panel>
            <cc1:ModalPopupExtender ID="ProgressBarModalPopupExtender" runat="server" PopupControlID="PanelProgress" BackgroundCssClass="modalBackground" TargetControlID="ButtonProgress" BehaviorID="ProgressBarModalPopupExtender"></cc1:ModalPopupExtender>
            <asp:Button Style="border-top-style: none; border-right-style: none; border-left-style: none; background-color: transparent; border-bottom-style: none" ID="ButtonProgress" runat="server" Width="16px" Enabled="False"></asp:Button>&nbsp;&nbsp; 
       
            


        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

