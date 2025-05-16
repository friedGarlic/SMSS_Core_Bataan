<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" EnableEventValidation="false"
    AutoEventWireup="false" CodeFile="t_purchase_request_v2_RepQueries.aspx.vb" Inherits="t_purchase_request_v2_RepQueries"
    StylesheetTheme="SkinFile" Title="Purchase Request" %>

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

    <script language="javascript" type="text/javascript">
        function Table2_onclick() {
        }
        function fun1(e, button1) {
            var evt = e ? e : window.event;
            var bt = document.getElementById(button1);
            if (bt) {
                if (evt.keyCode == 13) {
                    bt.click();
                    return false;
                }
            }
        }

        function HandleBrowseClick() {
            var fileinput = document.getElementById("flbuilding");
            fileinput.click();
        }

        function Handlechange() {
            var fileinput = document.getElementById("flbuilding");
            var hiddenControl = '<%= hdfbuilding.ClientID %>';
            document.getElementById(hiddenControl).value = fileinput.value;
        }

        function calculatePS(ps) {
            var Prop = 0.00;
            var App = 0.00;
            $(document).ready(function () {
                $(".proposedPS").each(function (idx, rel) {
                    var val = $("[id$='" + rel.id + "']").val();
                    val = val.toString().replace(/\$|\,/g, '');
                    Prop = MathRound(parseFloat(Prop) + parseFloat(val));
                    alert("ddd");
                });
                $("[id$='_txtTotal']").val(formatCurrency(Prop));
            });
        }

    </script>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <div>
                <table width="1020px">
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="PageTitle">CREATE PURCHASE REQUEST
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:RadioButtonList ID="RadioButtonList3" runat="server" Visible="false" CssClass="rbCS_Horizontal" Width="200px" RepeatDirection="Horizontal" AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList3_SelectedIndexChanged">
                                <asp:ListItem Selected="True">Create PR</asp:ListItem>
                                <asp:ListItem>PR Table</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <table style="width: 95%">
                                <tbody>
                                    <tr>
                                        <td style="width: 15%" class="column_RightBold">Fund Type : </td>
                                        <td class="column_Left" colspan="3">
                                            <asp:RadioButtonList ID="rbTrustFund" runat="server" CssClass="rbCS_Horizontal" Width="400px" RepeatDirection="Horizontal" AutoPostBack="True" OnSelectedIndexChanged="rbTrustFund_SelectedIndexChanged">
                                                <asp:ListItem Selected="True" Value="1">General Fund</asp:ListItem>
                                                <asp:ListItem Value="2">Special Education Fund</asp:ListItem>
                                                <asp:ListItem Value="3">Trust Fund</asp:ListItem>
                                            </asp:RadioButtonList></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 15%" class="column_RightBold">Transaction Type :</td>
                                        <td style="width: 35%" class="column_Left">
                                            <asp:DropDownList ID="ddTransactionType" runat="server" Width="50%" AutoPostBack="True" CssClass="drpdownCSS" AppendDataBoundItems="True" Enabled="False">
                                                <asp:ListItem>Purchase Request</asp:ListItem>
                                                <asp:ListItem>Reimbursement</asp:ListItem>
                                            </asp:DropDownList></td>
                                        <td style="width: 20%" class="column_Right">
                                            <asp:RadioButtonList ID="RadioButtonList1" runat="server" CssClass="rbCS_Horizontal" Width="174px" RepeatDirection="Horizontal" AutoPostBack="True" Height="30px">
                                                <asp:ListItem Selected="True" Value="0">Current</asp:ListItem>
                                                <asp:ListItem Value="1">Continuing</asp:ListItem>
                                            </asp:RadioButtonList></td>
                                        <td style="width: 30%" class="column_Left">
                                            <span class="column_RightBold">Date : </span>
                                            &nbsp;<asp:TextBox ID="txtprdate" runat="server" Width="100px" CssClass="txtbox_Date"></asp:TextBox>
                                            &nbsp;<span class="CalendarFormat">(MM/DD/YYYY)</span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 15%" class="column_RightBold">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" Width="1px" Height="1px" ValidationGroup="save" InitialValue="Select" ErrorMessage="Responsibility Center" ControlToValidate="ddRC">*</asp:RequiredFieldValidator>Department :</td>
                                        <td style="width: 35%" class="column_Left">
                                            <asp:DropDownList ID="ddRC" runat="server" Width="90%" AutoPostBack="True" CssClass="drpdownCSS" AppendDataBoundItems="True">
                                                <asp:ListItem>Select</asp:ListItem>
                                            </asp:DropDownList></td>
                                        <td style="width: 20%" class="column_RightBold">Items :</td>
                                        <td style="width: 30%" class="column_Left">
                                            <asp:LinkButton ID="LinkButton2" OnClick="LinkButton2_Click1" runat="server" CssClass="LinkBtnPreview" Text="View List of Goods"></asp:LinkButton>
                                            <asp:LinkButton ID="lbmeals" runat="server" ForeColor="#00C000" Visible="false">Meals</asp:LinkButton></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 15%" class="column_RightBold">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ValidationGroup="save" InitialValue="Select" ErrorMessage="Function" ControlToValidate="ddFunction">*</asp:RequiredFieldValidator>Function :</td>
                                        <td style="width: 35%" class="column_Left">
                                            <asp:DropDownList ID="ddFunction" runat="server" Width="90%" AutoPostBack="True" CssClass="drpdownCSS" AppendDataBoundItems="True">
                                                <asp:ListItem Value="0">Select</asp:ListItem>
                                            </asp:DropDownList></td>
                                        <td style="width: 20%" class="column_RightBold">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ValidationGroup="save" ErrorMessage="ObR Title" ControlToValidate="txtOBRpurpose">*</asp:RequiredFieldValidator>
                                            <asp:Label ID="lblreq2" runat="server" ForeColor="Red" Visible="False" Text="** "></asp:Label>
                                            OBR Description / Purpose :</td>
                                        <td style="width: 30%" class="column_Left" rowspan="2">
                                            <asp:TextBox ID="txtOBRpurpose" runat="server" Width="95%" CssClass="txtbox_Remarks" ReadOnly="True" TextMode="MultiLine" SkinID="text"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 15%" class="column_RightBold">P/P/A :</td>
                                        <td style="width: 35%" class="column_Left">
                                            <asp:DropDownList ID="ddPAPS" runat="server" Width="90%" AutoPostBack="True" CssClass="drpdownCSS">
                                                <asp:ListItem>Select</asp:ListItem>
                                            </asp:DropDownList></td>
                                        <td style="width: 20%" class="column_RightBold"></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 15%" class="column_RightBold">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ValidationGroup="save" InitialValue="0" ErrorMessage="Nature of Transaction" ControlToValidate="ddnature">*</asp:RequiredFieldValidator>Nature of Transaction :</td>
                                        <td style="width: 35%" class="column_Left">
                                            <asp:DropDownList ID="ddnature" runat="server" Width="90%" AutoPostBack="True" CssClass="drpdownCSS" AppendDataBoundItems="True">
                                                <asp:ListItem Value="0">Select</asp:ListItem>
                                                <asp:ListItem Value="2">Maintenance and Other Operating Expenses</asp:ListItem>
                                                <asp:ListItem Value="3">Capital Outlays</asp:ListItem>
                                            </asp:DropDownList></td>
                                        <td style="width: 20%" class="column_RightBold">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ValidationGroup="save" ErrorMessage="Payee" ControlToValidate="txtpeyee">*</asp:RequiredFieldValidator>Payee :&nbsp;</td>
                                        <td style="width: 30%" class="column_Left">
                                            <asp:TextBox ID="txtpeyee" runat="server" Width="95%" CssClass="txtbox_Var" Text="Purchae Request"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 15%" class="column_RightBold">Account Title :</td>
                                        <td style="width: 35%" class="column_Left">
                                            <asp:DropDownList ID="ddAccounts" runat="server" Width="90%" AutoPostBack="True" CssClass="drpdownCSS" AppendDataBoundItems="True">
                                                <asp:ListItem Value="0">Select</asp:ListItem>
                                            </asp:DropDownList></td>
                                        <td style="width: 20%" class="column_RightBold">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ValidationGroup="save" ErrorMessage="Address" ControlToValidate="txtaddpeyee">*</asp:RequiredFieldValidator>Address :</td>
                                        <td style="width: 30%" class="column_Left">
                                            <asp:TextBox ID="txtaddpeyee" runat="server" Width="95%" CssClass="txtbox_Var" Text="Balanga City, Bataan"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 15%" class="column_RightBold">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="save" ErrorMessage="Purpose" ControlToValidate="txtpurpose">*</asp:RequiredFieldValidator>
                                            <asp:Label Style="position: relative" ID="lblreq1" runat="server" ForeColor="Red" Visible="False" Text="** "></asp:Label>Purpose :</td>
                                        <td style="width: 35%" class="column_Left" rowspan="2">
                                            <asp:TextBox Style="text-align: left" ID="txtpurpose" runat="server" Width="90%" AutoPostBack="True" CssClass="txtbox_Remarks" TextMode="MultiLine" SkinID="text" OnTextChanged="txtpurpose_TextChanged"></asp:TextBox></td>
                                        <td style="width: 20%" class="column_RightBold">Requesting Person :</td>
                                        <td style="width: 30%" class="column_Left">
                                            <asp:DropDownList ID="ddRequestedBy" runat="server" Width="95%" AutoPostBack="True" OnSelectedIndexChanged="ddRequestedBy_SelectedIndexChanged" CssClass="drpdownCSS" AppendDataBoundItems="True" Enabled="False">
                                            </asp:DropDownList></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 15%" class="column_RightBold"></td>
                                        <td style="width: 20%" class="column_RightBold">Position :</td>
                                        <td style="width: 30%" class="column_Left">
                                            <asp:TextBox ID="txtposition" runat="server" Width="95%" CssClass="txtbox_Var" ReadOnly="True"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 15%" class="column_RightBold">Note : </td>
                                        <td style="width: 35%" class="column_Left">
                                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtprdate">
                                            </cc1:CalendarExtender>
                                            <cc1:ListSearchExtender ID="ListSearchExtender1" runat="server" TargetControlID="ddRC" PromptCssClass="ListSearchExtenderPrompt">
                                            </cc1:ListSearchExtender>
                                            <cc1:ListSearchExtender ID="ListSearchExtender2" runat="server" TargetControlID="ddFunction" PromptCssClass="ListSearchExtenderPrompt">
                                            </cc1:ListSearchExtender>
                                            <asp:TextBox ID="txtNote" runat="server" CssClass="txtbox_Var" Width="90%"></asp:TextBox>
                                        </td>
                                        <td style="width: 20%" class="column_RightBold">Approved By : </td>
                                        <td style="width: 30%" class="column_Left">
                                            <asp:DropDownList ID="ddApprovedBy" runat="server" CssClass="drpdownCSS" Width="95%">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="column_RightBold" style="width: 15%"></td>
                                        <td class="column_Left" style="width: 35%">
                                            <asp:TextBox ID="txtrequestingperson" runat="server" CssClass="txtbox_Var" Visible="False" Width="95%"></asp:TextBox>
                                        </td>
                                        <td class="column_RightBold" style="width: 20%"></td>
                                        <td class="column_Left" style="width: 30%">
                                            <asp:CheckBox ID="cbReinbursement" runat="server" Enabled="False" Visible="False" />
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="DivTitle">Allotment Details</td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:GridView ID="gvBudgetInfo2" runat="server" Width="98%" Font-Bold="False" OnSelectedIndexChanged="gvBudgetInfo2_SelectedIndexChanged"
                                CssClass="text" SkinID="GridViewAA" AutoGenerateColumns="False" ShowFooter="True" EmptyDataText="No Data Found.">
                                <Columns>
                                    <asp:BoundField DataField="ga_code" HeaderText="Account Code">
                                        <FooterStyle HorizontalAlign="Left"></FooterStyle>
                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center" Width="20%"></ItemStyle>
                                    </asp:BoundField>

                                    <asp:BoundField DataField="Allotment" DataFormatString="{0:N}" HeaderText="Released Amount">
                                        <FooterStyle HorizontalAlign="Right"></FooterStyle>
                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Right" Width="20%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Obligated" DataFormatString="{0:N}" HeaderText="Obligated Amount" HtmlEncode="False">
                                        <FooterStyle HorizontalAlign="Right"></FooterStyle>
                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Right" Width="15%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Ongoing" DataFormatString="{0:N}" HeaderText="Ongoing Obligation">
                                        <FooterStyle HorizontalAlign="Right"></FooterStyle>
                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Right" Width="15%"></ItemStyle>
                                    </asp:BoundField>

                                    <asp:BoundField DataField="PR_Amt" DataFormatString="{0:N}" HeaderText="PR Amount">
                                        <FooterStyle HorizontalAlign="Right"></FooterStyle>
                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Right" Width="15%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Available_Budget" DataFormatString="{0:N}" HeaderText="Available Budget">
                                        <FooterStyle HorizontalAlign="Right"></FooterStyle>
                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Right" Width="15%"></ItemStyle>
                                    </asp:BoundField>
                                </Columns>

                                <FooterStyle HorizontalAlign="Right" Font-Bold="True"></FooterStyle>
                            </asp:GridView>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="DivTitle">List of Goods</td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:GridView ID="gvbody" runat="server" Width="100%" SkinID="GridViewAA" ShowFooter="True" CaptionAlign="Left"
                                DataKeyNames="Item_ID,ppmp_dtl_id,GA_ID,BGA_ID" PageSize="5" OnRowDeleting="gvbody_RowDeleting" EmptyDataText="No Data Found.">
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkDelete" OnClick="lnkDelete_Click" runat="server" CausesValidation="False" CommandName="Select" Font-Underline="False">Delete</asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Code">
                                        <ItemTemplate>
                                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("GA_Code2") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Description">
                                        <ItemTemplate>
                                            <asp:Label ID="lbldesc" runat="server" Text='<%# Bind("Item_Desc") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="30%"></ItemStyle>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Unit">
                                        <ItemTemplate>
                                            <asp:Label ID="lblunit" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Quantity">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtqty" runat="server" Width="95%" AutoPostBack="True" CssClass="txtbox_Amt" Visible='<%#Bind("isVisible") %>' Text='<%# bind("qty") %>' SkinID="text" OnTextChanged="txtqty_TextChanged"></asp:TextBox>
                                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtqty" ValidChars="0123456789."></cc1:FilteredTextBoxExtender>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="8%"></ItemStyle>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Available Qty">
                                        <ItemTemplate>
                                            <asp:Label ID="lblBalance" runat="server" Text='<%#Bind("InputQty") %>' Visible='<%# bind("isVisible") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterStyle HorizontalAlign="Right" Font-Bold="True"></FooterStyle>
                                        <ItemStyle HorizontalAlign="Center" Width="8%"></ItemStyle>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Unit Price">
                                        <FooterTemplate>
                                            <strong style="text-align: right">TOTAL :</strong>
                                        </FooterTemplate>
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtcost" runat="server" Width="95%" CssClass="txtbox_Amt" AutoPostBack="True" Visible='<%#Bind("isVisible") %>' Text='<%# Bind("cost", "{0:N}") %>' ReadOnly="True" SkinID="text" OnTextChanged="txtcost_TextChanged1"></asp:TextBox>
                                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtcost" ValidChars="0123456789.,">
                                            </cc1:FilteredTextBoxExtender>
                                        </ItemTemplate>

                                        <ItemStyle HorizontalAlign="Right" Width="8%"></ItemStyle>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Total Amount">
                                        <FooterTemplate>
                                            <asp:Label ID="lbltotal" runat="server" Text='<%# Bind("total", "{0:N}") %>' Width="100px"></asp:Label>
                                        </FooterTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lbltotal" runat="server"  Text='<%# Bind("total", "{0:N}") %>' Visible='<%# bind("isVisible") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterStyle HorizontalAlign="Right" Font-Bold="False"></FooterStyle>
                                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                    </asp:TemplateField>

                                    <asp:TemplateField Visible="False">
                                        <ItemTemplate>
                                            <asp:Button ID="btnDetail" OnClick="btnDetail_Click" runat="server" Text="+" Visible='<%#Bind("isVisible") %>' CommandName="Select" EnableTheming="True"></asp:Button>
                                            <asp:Panel Style="display: none" ID="pnlDetail" runat="server" Width="500px" Visible='<%#Bind("isVisible") %>' BorderWidth="2px" BorderStyle="Solid" BorderColor="#FFA016" BackColor="White">
                                                <asp:TextBox ID="txtMemo" runat="server" Width="498px" CssClass="text" Height="150px" Text='<%#Bind("Project_title") %>' Visible='<%# bind("isVisible") %>' TextMode="MultiLine"></asp:TextBox><br />
                                                <br />
                                                <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td style="text-align: center">
                                                                <asp:Button ID="Button6" runat="server" Text="close"></asp:Button></td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </asp:Panel>
                                            <cc1:ModalPopupExtender ID="ModalPopupExtender2" runat="server" Enabled='<%#Bind("isVisible") %>' TargetControlID="btnDetail" BackgroundCssClass="modalBackground" PopupControlID="pnlDetail" CancelControlID="Button6" DynamicServicePath="">
                                            </cc1:ModalPopupExtender>
                                        </ItemTemplate>

                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:TemplateField>

                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Button ID="btnPRSpecs" runat="server" Text="+" EnableTheming="True"></asp:Button>
                                            <asp:Panel ID="pnlPRSpecs" runat="server" Width="400px" CssClass="Panel_Popup">
                                                <table style="width: 100%; text-align: center">
                                                    <tbody>
                                                        <tr>
                                                            <td style="width: 100%">
                                                                <asp:TextBox ID="txtremarks" runat="server" Width="98%" Text='<%#Bind("PR_ItemSpecs") %>' CssClass="txtbox_Remarks" Height="150px" TextMode="MultiLine"></asp:TextBox></td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 100%" align="left">
                                                                <span class="CalendarFormat">Note: Put > for next line</span>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 100%">
                                                                <asp:Button ID="ButtonPRSpecs" runat="server" Width="100px" CssClass="CSButton" Text="OK"></asp:Button></td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </asp:Panel>
                                            <cc1:ModalPopupExtender ID="ModalPopupExtenderPRSpecs" runat="server" TargetControlID="btnPRSpecs" PopupControlID="pnlPRSpecs" CancelControlID="ButtonPRSpecs" BackgroundCssClass="modalBackground">
                                            </cc1:ModalPopupExtender>

                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="6%" />
                                    </asp:TemplateField>

                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:Image ID="Image1" runat="server" ImageUrl="~/images/delete.png"></asp:Image>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ImageButton4" OnClick="ImageButton4_Click" runat="server" ImageUrl="~/images/delete.png" Height="15px" Visible='<%#Bind("isVisible") %>' OnClientClick="StartProgressBar();" CommandName="Select"></asp:ImageButton>
                                            <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" TargetControlID="ImageButton4" ConfirmText="Are you sure you want to delete this item?"></cc1:ConfirmButtonExtender>
                                        </ItemTemplate>

                                        <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>

                    <%-- REQUEST: REMOVED THE CHECKED BY AND NOTED BY 12-27-19 --%>
                    <%--<tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <span class="column_RightBold">Checked By :</span>
                            &nbsp;<asp:DropDownList ID="ddCheckedBy" runat="server" CssClass="drpdownCSS" Width="300px">
                            </asp:DropDownList>
                            &nbsp;<span class="column_RightBold">Noted By :</span>
                            &nbsp;<asp:DropDownList ID="ddNotedBy" runat="server" CssClass="drpdownCSS" Width="300px">
                            </asp:DropDownList>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>--%>

                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:Button ID="btnSave" runat="server" Width="150px" CssClass="CSButton" Text="SAVE" OnClientClick="StartProgressBar();"></asp:Button>
                            &nbsp;<asp:Button ID="btnSubmit" OnClick="btnSubmit_Click" runat="server" Width="150px" CssClass="CSButton" Enabled="False" Text="SUBMIT" OnClientClick="StartProgressBar();"></asp:Button>
                            &nbsp;<asp:Button ID="btnpreview" runat="server" Width="150px" CssClass="CSButton" Text="PREVIEW" OnClientClick="StartProgressBar();"></asp:Button>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:GridView ID="gvListPR" runat="server" Width="90%" SkinID="GridViewAA" AutoGenerateColumns="False" DataKeyNames="prhdr_id,pr_no,IsApproved">
                                <Columns>
                                    <asp:BoundField DataField="Remarks" HeaderText="Remarks">
                                        <ItemStyle HorizontalAlign="Left" Width="50%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ABC" DataFormatString="{0:N}" HeaderText="ABC">
                                        <ItemStyle HorizontalAlign="Right" Width="15%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Date_Submitted" DataFormatString="{0:MM/dd/yyyy}" HeaderText="Date">
                                        <ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Report" ShowHeader="False">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton1" OnClick="LinkButton1_Click1" runat="server" CausesValidation="False" Visible='<%#Bind("isVisible") %>' OnClientClick="StartProgressBar();" Font-Underline="False" CommandName="Select" Text="PR" CssClass="LinkBtnPreview"></asp:LinkButton>
                                            &nbsp;<asp:Label runat="server" ID="lblSlash" CssClass="column_CenterBold" Text="/"  Visible='<%#Bind("isVisible") %>'></asp:Label>
                                            &nbsp;<asp:LinkButton ID="LinkButton4" OnClick="LinkButton4_Click" runat="server" CausesValidation="False" Visible='<%#Bind("isVisible") %>' OnClientClick="StartProgressBar();" Font-Underline="False" CommandName="Select" Text="OBR" CssClass="LinkBtnPreview"></asp:LinkButton>
                                        </ItemTemplate>

                                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField ShowHeader="False">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton2" OnClick="LinkButton2_Click" runat="server" CausesValidation="False" Visible='<%#Bind("isVisible") %>' Text="EDIT" CssClass="LinkBtnSelect" OnClientClick="StartProgressBar();" Font-Underline="False" CommandName="Select" ></asp:LinkButton>
                                            <asp:LinkButton ID="LinkButton6" OnClick="LinkButton6_Click" runat="server" Enabled="False" Visible="False" Font-Underline="False" CommandName="Select" >Cancel</asp:LinkButton>
                                            <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender3" runat="server" TargetControlID="LinkButton6" ConfirmText="Are you sure you want to cancel  this transaction?">
                                            </cc1:ConfirmButtonExtender>
                                        </ItemTemplate>

                                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
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




            <table style="width: 1010px">
                <tbody>
                    <tr>
                        <td style="width: 10px" align="center"></td>
                        <td style="width: 1000px" class="DivTitle">Document Attachment</td>
                    </tr>
                    <tr>
                        <td style="width: 10px" align="center"></td>
                        <td style="width: 1000px" align="center">
                            <table style="width: 950px">
                                <tbody>
                                    <tr>
                                        <td style="border-right: gray 1px solid; border-top: gray 1px solid; vertical-align: top; border-left: gray 1px solid; width: 600px; border-bottom: gray 1px solid" align="center">
                                            <table style="font-weight: normal; width: 100%">
                                                <tbody>
                                                    <tr>
                                                        <td style="width: 20%" class="column_RightBold">Attach File :</td>
                                                        <td style="width: 80%" class="column_Left">
                                                            <asp:FileUpload ID="FileUpload1" runat="server" Width="400px" ViewStateMode="Inherit" ClientIDMode="Inherit" BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px"></asp:FileUpload></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 20%" class="column_RightBold"></td>
                                                        <td style="width: 80%" class="column_Left"><span style="color: red; font-family: Calibri">Note:<br />
                                                            &nbsp;&nbsp;&nbsp;&nbsp; Accepted file types:&nbsp;*.jpg, *.png,&nbsp;*.doc, *.rar, *.zip, *.xls, and *.xlsx&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 20%" class="column_RightBold">Document Name :</td>
                                                        <td style="width: 80%" class="column_Left">
                                                            <asp:TextBox ID="txtDocName" runat="server" Width="300px" CssClass="txtboxinspection"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 20%" class="column_RightBold">Document No. :</td>
                                                        <td style="width: 80%" class="column_Left">
                                                            <asp:TextBox ID="txtDocNumb" runat="server" Width="300px" CssClass="txtboxinspection"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 20%" class="column_RightBold">Remarks :</td>
                                                        <td style="width: 80%" class="column_Left">
                                                            <asp:TextBox ID="txtRemarks" runat="server" Width="300px" CssClass="txtboxinspection"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 20%" class="column_RightBold"></td>
                                                        <td style="width: 80%" class="column_Left">
                                                            <asp:Button ID="UploadButton" OnClick="UploadButton_Click" runat="server" Width="200px" Enabled="False" Text="UPLOAD FILE" OnClientClick="StartProgressBar();"></asp:Button>
                                                            <asp:Label ID="lblNoti" runat="server" ForeColor="Red" Font-Size="9pt" Font-Names="Calibri" Visible="False" Text="* No file to upload."></asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" colspan="2">
                                                            <asp:GridView ID="grdDocuments" runat="server" Width="95%" SkinID="GridViewAA" DataKeyNames="Attch_ID,ID,DocumentName" PageSize="5" EmptyDataText="No Data Found." AllowPaging="True">
                                                                <Columns>
                                                                    <asp:BoundField DataField="DocumentNo" HeaderText="Document No.">
                                                                        <ItemStyle HorizontalAlign="Center" Width="20%"></ItemStyle>
                                                                    </asp:BoundField>
                                                                    <asp:TemplateField HeaderText="Document Name">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lbtnDocu" runat="server" CommandName="Select" Text='<%# Bind("AttachedFilename") %>' Font-Underline="False"></asp:LinkButton>

                                                                        </ItemTemplate>

                                                                        <ItemStyle HorizontalAlign="Left" Width="40%"></ItemStyle>
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="Remarks" HeaderText="Remarks">
                                                                        <ItemStyle HorizontalAlign="Left" Width="40%"></ItemStyle>
                                                                    </asp:BoundField>
                                                                </Columns>

                                                                <FooterStyle BackColor="#2977DC"></FooterStyle>

                                                                <HeaderStyle BackColor="#2977DC" ForeColor="White"></HeaderStyle>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </td>
                                        <td style="border-right: gray 1px solid; border-top: gray 1px solid; vertical-align: middle; border-left: gray 1px solid; width: 350px; border-bottom: gray 1px solid" align="center">
                                            <fieldset style="border-right: #2977dc 1px solid; border-top: #2977dc 1px solid; border-left: #2977dc 1px solid; width: 250px; border-bottom: #2977dc 1px solid; height: 320px">
                                                <legend><span style="font-size: 10pt; font-family: Tahoma"><strong>ATTACHED DOCUMENTS</strong></span></legend>
                                                <br />
                                                <asp:Image ID="imgPRAttachDoc" runat="server" Width="225px" ImageUrl="~/images/blankImage.jpg" Height="290px"></asp:Image>
                                            </fieldset>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 10px" align="center"></td>
                        <td style="width: 1000px" align="center">
                            <asp:Panel ID="Panel2" runat="server" Width="99%" CssClass="PanelBorder" Visible="False">
                                <table style="width: 98%">
                                    <tbody>
                                        <tr>
                                            <td style="width: 30%" align="center">
                                                <asp:HiddenField ID="hdfbuilding" runat="server"></asp:HiddenField>
                                                <input style="display: none" id="flbuilding" type="file" onchange="Handlechange();" name="fileupload" />
                                                <input style="width: 147px; height: 29px" id="btnBuildingBrowse" onclick="HandleBrowseClick();" type="submit" value="Browse" runat="server" onserverclick="btnBuildingBrowse_ServerClick" /></td>
                                            <td style="width: 30%" align="right"><span style="font-size: 10pt; font-family: Tahoma"><strong>Validated By :</strong></span>
                                                <asp:TextBox ID="txtvalidatedby" runat="server" Width="150px"></asp:TextBox></td>
                                            <td style="width: 40%" align="center" rowspan="6"></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 30%" align="right"><span style="font-size: 10pt; font-family: Tahoma"><strong>Document Name :</strong></span>
                                                <asp:TextBox ID="txtDocumentname" runat="server" Width="150px"></asp:TextBox></td>
                                            <td style="width: 30%" align="right"><span style="font-size: 10pt; font-family: Tahoma"><strong>Date Validated :</strong></span>
                                                <asp:TextBox ID="txtdatevalidated" runat="server" Width="150px"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 30%" align="right"><span style="font-size: 10pt; font-family: Tahoma"><strong>Document No. :</strong></span>
                                                <asp:TextBox ID="txtdocumentno" runat="server" Width="150px"></asp:TextBox></td>
                                            <td style="width: 30%" align="right"><span style="font-size: 10pt; font-family: Tahoma"><strong>Remarks :</strong></span>
                                                <asp:TextBox ID="txtdocremarks" runat="server" Width="150px"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="2">
                                                <cc1:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtdatevalidated" PopupPosition="BottomRight"></cc1:CalendarExtender>
                                                <asp:Button ID="btnAddlist" OnClick="btnAddlist_Click" runat="server" Width="122px" Text="Add To List"></asp:Button><asp:Button ID="btnCancel" runat="server" Width="122px" Text="Cancel"></asp:Button></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 30%" align="left"></td>
                                            <td style="width: 30%" align="left"></td>
                                        </tr>
                                        <tr>
                                            <td align="left" colspan="2">
                                                <asp:GridView ID="grdocumentdetails" runat="server" Width="98%" Font-Size="9pt" OnSelectedIndexChanged="grdocumentdetails_SelectedIndexChanged" Height="170px" SkinID="GridView" DataKeyNames="IdentityNo,DocuId" PageSize="5" BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px">
                                                    <Columns>
                                                        <asp:BoundField DataField="DocumentName" HeaderText="Document Name">
                                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="DocumentNo" HeaderText="Document No.">
                                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="ValidatedBy" HeaderText="Validated By">
                                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="DateValidated" DataFormatString="{0:d}" HeaderText="Date Validated">
                                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Remarks" HeaderText="Remarks">
                                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                        </asp:BoundField>
                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 10px" align="center"></td>
                        <td style="width: 1000px" align="center"></td>
                    </tr>
                </tbody>
            </table>




            <asp:Panel Style="display: none" ID="popup" runat="server" Width="900px">
                <table id="Table2" cellspacing="0" cellpadding="0" width="747" border="0">
                    <tbody>
                        <tr>
                            <td colspan="2"></td>
                        </tr>
                        <tr>
                            <td style="background-image: url(../images/modalpopup_02.png); width: 772px; height: 39px"></td>
                            <td style="width: 46px; height: 39px">
                                <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="../images/modalpopup_03.png"></asp:ImageButton></td>
                        </tr>
                        <tr>
                            <td style="background-image: url(../images/modalpopup_04.png); vertical-align: top; width: 772px; text-align: center" id="Td1">
                                <table style="width: 705px; height: 336px" cellspacing="0" cellpadding="0" border="0">
                                    <tbody>
                                        <tr>
                                            <td style="vertical-align: top; width: 4%; text-align: center"></td>
                                            <td style="vertical-align: top; width: 100%; text-align: center">
                                                <table style="width: 100%" class="text" cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td style="width: 100%; height: 25px" colspan="3">
                                                                <table style="width: 100%">
                                                                    <tbody>
                                                                        <tr>
                                                                            <td style="width: 20%" class="column_RightBold">DESCRIPTION&nbsp;: </td>
                                                                            <td style="width: 50%" class="column_Left">
                                                                                <asp:TextBox ID="SearchBut" runat="server" Width="98%" CssClass="txtboxinspection"></asp:TextBox></td>
                                                                            <td style="width: 30%" class="column_Left">
                                                                                <asp:Button ID="Button5" OnClick="Button5_Click" runat="server" Width="120px" Text="SEARCH"></asp:Button></td>
                                                                        </tr>
                                                                    </tbody>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>


                                                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                                    <ContentTemplate>
                                                        <asp:Panel ID="Panel1" runat="server" Width="99%" CssClass="PanelSize_Popup" ScrollBars="Vertical">
                                                            <asp:GridView ID="gvitems" runat="server" Width="100%" CssClass="text" OnSelectedIndexChanged="gvitems_SelectedIndexChanged" SkinID="GridViewAA" PageSize="8" DataKeyNames="item_id" AllowPaging="True" BackColor="White" Font-Size="9pt">
                                                                <Columns>
                                                                    <asp:TemplateField>
                                                                        <EditItemTemplate>
                                                                            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                                                        </EditItemTemplate>
                                                                        <HeaderTemplate>
                                                                            <asp:CheckBox ID="CheckBox2" runat="server" Font-Bold="True" ForeColor="White" Font-Size="10pt" Font-Names="tahoma" AutoPostBack="True" Text="All" OnCheckedChanged="CheckBox2_CheckedChanged"></asp:CheckBox>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="True" Enabled='<%# bind("Enable") %>' OnCheckedChanged="CheckBox1_CheckedChanged"></asp:CheckBox>
                                                                        </ItemTemplate>

                                                                        <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="Item_Desc" HeaderText="Description">
                                                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                                        <ItemStyle HorizontalAlign="Left" Width="50%"></ItemStyle>
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="Description" HeaderText="Unit">
                                                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                                        <ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="Item_id">
                                                                        <ItemStyle Width="10px"></ItemStyle>
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="id" HeaderText="id"></asp:BoundField>
                                                                    <asp:BoundField DataField="cost" DataFormatString="{0:N}" HeaderText="Cost" HtmlEncode="False">
                                                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                                        <ItemStyle HorizontalAlign="Right" Width="15%"></ItemStyle>
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="qty" HeaderText="qty"></asp:BoundField>
                                                                    <asp:BoundField DataField="GA_ID" HeaderText="GA_ID"></asp:BoundField>
                                                                    <asp:BoundField DataField="BGA_ID" HeaderText="BGA_ID"></asp:BoundField>
                                                                    <asp:BoundField DataField="GA_Code2" HeaderText="Code">
                                                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                                        <ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="ppmp_dtl_id" HeaderText="id2"></asp:BoundField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </asp:Panel>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>

                                                <br />
                                                &nbsp;<asp:Label ID="lblItemList" runat="server"></asp:Label>
                                                <asp:DropDownList ID="ddpopup" runat="server" Visible="False">
                                                    <asp:ListItem Value="Item_Desc">Description</asp:ListItem>
                                                    <asp:ListItem Value="GA_Code2">Code</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 4%; height: 24px; text-align: center"></td>
                                            <td style="width: 100%; text-align: center">
                                                <asp:Button ID="Button3" runat="server" Width="150px" Text="LOAD" OnClientClick="StartProgressBar();"></asp:Button></td>
                                        </tr>
                                    </tbody>
                                </table>

                                <span style="font-size: 11pt"></span></td>
                            <td style="background-image: url(../images/modalpopup_05.png); width: 46px; height: 446px"></td>
                        </tr>
                    </tbody>
                </table>
            </asp:Panel>




            <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="lblItemList" CancelControlID="ImageButton3" PopupControlID="popup" BackgroundCssClass="modalBackground"></cc1:ModalPopupExtender>
           
            <asp:Panel Style="border-top-width: 1px; border-left-width: 1px; border-left-color: #0033cc; border-bottom-width: 1px; border-bottom-color: #0033cc; border-top-color: #0033cc; position: relative; background-color: transparent; text-align: center; border-right-width: 1px; border-right-color: #0033cc" ID="PanelProgress" runat="server" Width="109px">
                <img alt="" src="../images/ajax-loader.gif" />
            </asp:Panel>
            <cc1:ModalPopupExtender ID="ProgressBarModalPopupExtender" runat="server" TargetControlID="ButtonProgress" PopupControlID="PanelProgress" BackgroundCssClass="modalBackground" BehaviorID="ProgressBarModalPopupExtender"></cc1:ModalPopupExtender>
            <asp:Button Style="border-top-style: none; border-right-style: none; border-left-style: none; position: relative; background-color: transparent; border-bottom-style: none" ID="ButtonProgress" runat="server" Width="16px" Enabled="False"></asp:Button><br />


        </ContentTemplate>
    </asp:UpdatePanel>



</asp:Content>

