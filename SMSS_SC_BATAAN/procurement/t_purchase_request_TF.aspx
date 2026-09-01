<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" EnableEventValidation="false"
    AutoEventWireup="false" CodeFile="t_purchase_request_TF.aspx.vb" Inherits="t_purchase_request_TF"
    StylesheetTheme="SkinFile" Title="PURCHASE REQUEST TRUST FUND" %>

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
            <table style="width: 1010px">
                <tbody>
                    <tr>
                        <td style="width: 10px" align="center"></td>
                        <td style="width: 1000px" class="PageTitle" align="center">CREATE PURCHASE REQUEST - TRUST FUND</td>
                    </tr>
                    <tr>
                        <td style="width: 10px" align="center"></td>
                        <td style="width: 1000px" align="center">
                            <table style="width: 99%" class="panel_border">
                                <tbody>
                                    <tr>
                                        <td style="width: 15%" class="column_RightBold">Fund Type : </td>
                                        <td class="text5" colspan="3">
                                            <asp:RadioButtonList ID="rbTrustFund" runat="server" Width="500px" RepeatDirection="Horizontal" AutoPostBack="True" OnSelectedIndexChanged="rbTrustFund_SelectedIndexChanged">
                                                <asp:ListItem Value="1">General Fund</asp:ListItem>
                                                <asp:ListItem Value="2">Special Education Fund</asp:ListItem>
                                                <asp:ListItem Selected="True" Value="3">Trust Fund</asp:ListItem>
                                            </asp:RadioButtonList></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 15%" class="column_RightBold">Transaction Type :</td>
                                        <td style="width: 35%" class="text5">
                                            <asp:DropDownList ID="ddTransactionType" runat="server" Width="70%" AutoPostBack="True" AppendDataBoundItems="True" Enabled="False" CssClass="txtboxinspection">
                                                <asp:ListItem>Purchase Request</asp:ListItem>
                                                <asp:ListItem>Reimbursement</asp:ListItem>
                                            </asp:DropDownList></td>
                                        <td style="width: 20%" class="column_RightBold">Date : </td>
                                        <td style="width: 30%" class="text5">
                                            <asp:TextBox ID="txtprdate" runat="server" Width="100px" CssClass="txtboxinspection"></asp:TextBox> <span style="font-size: 9pt; font-family: Calibri"><strong>(MM/DD/YYYY)</strong></span></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 15%" class="column_RightBold">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" Width="1px" ValidationGroup="save" InitialValue="Select" ErrorMessage="Responsibility Center" ControlToValidate="ddRC" Height="1px">*</asp:RequiredFieldValidator>Department :</td>
                                        <td style="width: 35%" class="text5">
                                            <asp:DropDownList ID="ddRC" runat="server" Width="90%" AutoPostBack="True" AppendDataBoundItems="True" CssClass="txtboxinspection">
                                                <asp:ListItem>Select</asp:ListItem>
                                            </asp:DropDownList></td>
                                        <td style="width: 20%" class="column_RightBold">Items&nbsp;:</td>
                                        <td style="width: 30%" class="text5">
                                            <asp:LinkButton ID="LinkButton2" OnClick="LinkButton2_Click1" runat="server" ForeColor="#00C000">View List of Goods</asp:LinkButton>|
                                            <asp:LinkButton ID="lbmeals" runat="server" ForeColor="#00C000">Meals</asp:LinkButton></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 15%" class="column_RightBold">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ValidationGroup="save" InitialValue="Select" ErrorMessage="Function" ControlToValidate="ddFunction">*</asp:RequiredFieldValidator>Function :</td>
                                        <td style="width: 35%" class="text5">
                                            <asp:DropDownList ID="ddFunction" runat="server" Width="90%" AutoPostBack="True" AppendDataBoundItems="True" CssClass="txtboxinspection">
                                                <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>
                                            </asp:DropDownList></td>
                                        <td style="width: 20%" class="column_RightBold">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ValidationGroup="save" ErrorMessage="ObR Title" ControlToValidate="txtOBRpurpose">*</asp:RequiredFieldValidator>
                                            <asp:Label Style="left: 0px; position: relative" ID="lblreq2" runat="server" ForeColor="Red" Visible="False" Text="** "></asp:Label>OBR Description / Purpose :</td>
                                        <td style="width: 30%" class="text5" rowspan="2">
                                            <asp:TextBox Style="text-align: left" ID="txtOBRpurpose" runat="server" Width="95%" CssClass="ddropbox1" Height="40px" ReadOnly="True" TextMode="MultiLine" SkinID="text"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 15%" class="column_RightBold">P/P/A :</td>
                                        <td style="width: 35%" class="text5">
                                            <asp:DropDownList ID="ddPAPS" runat="server" Width="90%" Enabled="False" CssClass="txtboxinspection">
                                                <asp:ListItem Selected="True" Value="0">Office Operational Expense</asp:ListItem>
                                            </asp:DropDownList></td>
                                        <td style="width: 20%" class="column_RightBold"></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 15%" class="column_RightBold">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ValidationGroup="save" InitialValue="0" ErrorMessage="Nature of Transaction" ControlToValidate="ddnature">*</asp:RequiredFieldValidator>Nature of Transaction :</td>
                                        <td style="width: 35%" class="text5">
                                            <asp:DropDownList ID="ddnature" runat="server" Width="90%" AutoPostBack="True" AppendDataBoundItems="True" CssClass="txtboxinspection">
                                                <asp:ListItem Value="0">Select</asp:ListItem>
                                                <asp:ListItem Value="2">Maintenance and Other Operating Expenses</asp:ListItem>
                                                <asp:ListItem Value="3">Capital Outlays</asp:ListItem>
                                            </asp:DropDownList></td>
                                        <td style="width: 20%" class="column_RightBold">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ValidationGroup="save" ErrorMessage="Payee" ControlToValidate="txtpeyee">*</asp:RequiredFieldValidator>Payee :&nbsp;</td>
                                        <td style="width: 30%" class="text5">
                                            <asp:TextBox ID="txtpeyee" runat="server" Width="95%" CssClass="txtboxinspection"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 15%" class="column_RightBold">Account Title :</td>
                                        <td style="width: 35%" class="text5">
                                            <asp:DropDownList ID="ddAccounts" runat="server" Width="90%" AutoPostBack="True" AppendDataBoundItems="True" CssClass="txtboxinspection">
                                                <asp:ListItem Value="0">Select</asp:ListItem>
                                            </asp:DropDownList></td>
                                        <td style="width: 20%" class="column_RightBold">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ValidationGroup="save" ErrorMessage="Address" ControlToValidate="txtaddpeyee">*</asp:RequiredFieldValidator>Address :</td>
                                        <td style="width: 30%" class="text5">
                                            <asp:TextBox ID="txtaddpeyee" runat="server" Width="95%" CssClass="txtboxinspection"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 15%" class="column_RightBold">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="save" ErrorMessage="Purpose" ControlToValidate="txtpurpose">*</asp:RequiredFieldValidator>
                                            <asp:Label Style="position: relative" ID="lblreq1" runat="server" ForeColor="Red" Visible="False" Text="** "></asp:Label>Purpose :</td>
                                        <td style="width: 35%" class="text5" rowspan="2">
                                            <asp:TextBox Style="text-align: left" ID="txtpurpose" runat="server" Width="90%" AutoPostBack="True" CssClass="ddropbox1" Height="40px" TextMode="MultiLine" SkinID="text" OnTextChanged="txtpurpose_TextChanged"></asp:TextBox></td>
                                        <td style="width: 20%" class="column_RightBold">Requesting Person :</td>
                                        <td style="width: 30%" class="text5">
                                            <asp:DropDownList ID="ddRequestedBy" runat="server" Width="95%" AutoPostBack="True" OnSelectedIndexChanged="ddRequestedBy_SelectedIndexChanged" AppendDataBoundItems="True" Enabled="False" CssClass="txtboxinspection">
                                                <asp:ListItem Value="0">Select</asp:ListItem>
                                            </asp:DropDownList></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 15%" class="column_RightBold"></td>
                                        <td style="width: 20%" class="column_RightBold">Position :</td>
                                        <td style="width: 30%" class="text5">
                                            <asp:TextBox ID="txtposition" runat="server" Width="95%" CssClass="txtboxinspection" ReadOnly="True"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 15%" class="column_RightBold">
                                            <asp:CheckBox ID="cbReinbursement" runat="server" Enabled="False" Visible="False" />
                                        </td>
                                        <td style="width: 35%" class="text5">
                                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtprdate">
                                            </cc1:CalendarExtender>
                                            <cc1:ListSearchExtender ID="ListSearchExtender1" runat="server" TargetControlID="ddRC" PromptCssClass="ListSearchExtenderPrompt">
                                            </cc1:ListSearchExtender>
                                            <cc1:ListSearchExtender ID="ListSearchExtender2" runat="server" TargetControlID="ddFunction" PromptCssClass="ListSearchExtenderPrompt">
                                            </cc1:ListSearchExtender>
                                            <asp:TextBox ID="txtrequestingperson" runat="server" CssClass="txtboxinspection" Visible="False" Width="95%"></asp:TextBox>
                                        </td>
                                        <td style="width: 20%" class="column_RightBold">Approved By : </td>
                                        <td style="width: 30%" class="text5"><strong style="font-size: 10pt; font-family: Tahoma">
                                            <asp:DropDownList ID="ddApprovedBy" runat="server" Width="95%">
                                            </asp:DropDownList>
                                            </strong></td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 10px" align="center"></td>
                        <td style="width: 1000px" class="DivTitle" align="center">LIST OF GOODS</td>
                    </tr>
                    <tr>
                        <td style="width: 10px" align="center"></td>
                        <td style="width: 1000px" align="center">
                            <asp:GridView ID="gvbody" runat="server" Width="100%" Font-Size="9pt" CssClass="text" SkinID="GridViewAA" CaptionAlign="Left" DataKeyNames="Item_ID,ppmp_dtl_id,GA_ID,BGA_ID" PageSize="5" OnRowDeleting="gvbody_RowDeleting" ShowFooter="True">
                                <Columns>
                                    <asp:TemplateField>
                                        <EditItemTemplate>
                                            <asp:TextBox runat="server" ID="TextBox9"></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            &nbsp;<asp:LinkButton ID="lnkDelete" OnClick="lnkDelete_Click" runat="server" CausesValidation="False" CommandName="Select" Font-Underline="False">Delete</asp:LinkButton>
                                        </ItemTemplate>

                                        <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Code">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("GA_Code2") %>'></asp:TextBox>

                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label1" runat="server" CssClass="text" Text='<%# Bind("GA_Code2") %>'></asp:Label>
                                        </ItemTemplate>

                                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Description">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Item_Desc") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            &nbsp;<asp:Label Style="text-align: left" ID="lbldesc" runat="server" Width="280px" CssClass="text" Text='<%# Bind("Item_Desc") %>'></asp:Label>
                                        </ItemTemplate>

                                        <ItemStyle HorizontalAlign="Left" Width="30%"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Unit">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Description") %>'></asp:TextBox>

                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblunit" runat="server" CssClass="text" Text='<%# Bind("Description") %>'></asp:Label>
                                        </ItemTemplate>

                                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Quantity">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Qty") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:TextBox Style="text-align: right" ID="txtqty" runat="server" Width="95%" AutoPostBack="True" CssClass="text" Visible='<%# bind("isVisible") %>' Text='<%# bind("qty") %>' SkinID="text" OnTextChanged="txtqty_TextChanged"></asp:TextBox>
                                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtqty" ValidChars="0123456789."></cc1:FilteredTextBoxExtender>
                                        </ItemTemplate>

                                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Available Qty">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label Style="text-align: center" ID="lblBalance" runat="server" Width="80px" Text='<%# bind("InputQty") %>' Visible='<%# bind("isVisible") %>'></asp:Label>
                                        </ItemTemplate>

                                        <FooterStyle HorizontalAlign="Right" Font-Bold="True"></FooterStyle>

                                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Unit Price">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("Cost") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <strong style="text-align: right">TOTAL :</strong>
                                        </FooterTemplate>
                                        <ItemTemplate>
                                            <asp:TextBox Style="text-align: right" ID="txtcost" runat="server" Width="95%" AutoPostBack="True" CssClass="text" Visible='<%# bind("isVisible") %>' Text='<%# Bind("cost", "{0:N}") %>' ReadOnly="True" SkinID="text" OnTextChanged="txtcost_TextChanged1"></asp:TextBox>
                                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtcost" ValidChars="0123456789.,">
                                            </cc1:FilteredTextBoxExtender>
                                        </ItemTemplate>

                                        <ItemStyle HorizontalAlign="Right" Width="10%"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Total Amount">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("total") %>'></asp:TextBox>

                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lbltotal" runat="server" CssClass="text" Style="text-align: right"
                                                Text='<%# Bind("total", "{0:N}") %>' Width="100px"></asp:Label>

                                        </FooterTemplate>
                                        <ItemTemplate>
                                            <asp:Label Style="text-align: right" ID="lbltotal" runat="server" Width="100px" CssClass="text" Text='<%# Bind("total", "{0:N}") %>' Visible='<%# bind("isVisible") %>'></asp:Label>
                                        </ItemTemplate>

                                        <FooterStyle HorizontalAlign="Right" Font-Bold="False"></FooterStyle>

                                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField Visible="False">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>

                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Button ID="btnDetail" OnClick="btnDetail_Click" runat="server" Text="+" Visible='<%# bind("isVisible") %>' CommandName="Select" EnableTheming="True"></asp:Button>
                                            <asp:Panel Style="display: none" ID="pnlDetail" runat="server" Width="500px" Visible='<%# bind("isVisible") %>' BorderWidth="2px" BorderStyle="Solid" BorderColor="#FFA016" BackColor="White">
                                                <asp:TextBox ID="txtMemo" runat="server" Width="498px" CssClass="text" Height="150px" Text='<%# bind("Project_title") %>' Visible='<%# bind("isVisible") %>' TextMode="MultiLine"></asp:TextBox><br />
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
                                            <cc1:ModalPopupExtender ID="ModalPopupExtender2" runat="server" Enabled='<%# bind("isVisible") %>' TargetControlID="btnDetail" BackgroundCssClass="modalBackground" PopupControlID="pnlDetail" CancelControlID="Button6" DynamicServicePath="">
                                            </cc1:ModalPopupExtender>
                                        </ItemTemplate>

                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="DEL">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox10" runat="server"></asp:TextBox>
                                        </EditItemTemplate>
                                        <HeaderTemplate>
                                            <asp:Image ID="Image1" runat="server" ImageUrl="~/images/delete.png"></asp:Image>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ImageButton4" OnClick="ImageButton4_Click" runat="server" ImageUrl="~/images/delete.png" Height="15px" Visible='<%# bind("isVisible") %>' OnClientClick="StartProgressBar();" CommandName="Select"></asp:ImageButton>
                                            <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" TargetControlID="ImageButton4" ConfirmText="Are you sure you want to delete this item?"></cc1:ConfirmButtonExtender>
                                        </ItemTemplate>

                                        <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 10px" align="center"></td>
                        <td style="width: 1000px" align="center"><span style="font-size: 10pt; font-family: Tahoma"><strong>Checked By :</strong></span>
                            <asp:DropDownList ID="ddCheckedBy" runat="server" Width="300px"></asp:DropDownList> <span style="font-size: 10pt; font-family: Tahoma"><strong>Noted By :</strong></span>
                            <asp:DropDownList ID="ddNotedBy" runat="server" Width="300px"></asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td style="width: 10px" align="center"></td>
                        <td style="width: 1000px" align="center">
                            <asp:Button  ID="btnSave" runat="server" Width="200px" Font-Bold="True" Font-Size="10pt" Font-Names="Tahoma" Text="SAVE" OnClientClick="StartProgressBar();"></asp:Button>
                            &nbsp;<asp:Button ID="btnSubmit" OnClick="btnSubmit_Click" runat="server" Width="200px" Font-Bold="True" Font-Size="10pt" Font-Names="Tahoma" Enabled="False" Text="SUBMIT" OnClientClick="StartProgressBar();"></asp:Button><asp:Button ID="btnpreview" runat="server" Width="200px" Font-Bold="True" Font-Size="10pt" Font-Names="Tahoma" Text="PREVIEW PR" OnClientClick="StartProgressBar();"></asp:Button></td>
                    </tr>
                    <tr>
                        <td style="width: 10px" align="center"></td>
                        <td style="width: 1000px" align="center"></td>
                    </tr>
                    <tr>
                        <td style="width: 10px" align="center"></td>
                        <td style="width: 1000px" align="center">
                            <asp:GridView Style="font-weight: normal" ID="gvListPR" runat="server" Width="95%" Font-Size="9pt" SkinID="GridViewAA" DataKeyNames="prhdr_id,OBR_Hdr_ID,pr_no" AutoGenerateColumns="False">
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
                                            <asp:LinkButton ID="LinkButton1" OnClick="LinkButton1_Click1" runat="server" Width="20px" CausesValidation="False" Text="PR" Visible='<%# bind("isVisible") %>' OnClientClick="StartProgressBar();" Font-Underline="False" __designer:wfdid="w459" CommandName="Select"></asp:LinkButton>
                                            <asp:LinkButton ID="LinkButton4" OnClick="LinkButton4_Click" runat="server" Width="20px" CausesValidation="False" Visible="False" OnClientClick="StartProgressBar();" Font-Underline="False" __designer:wfdid="w460" CommandName="Select">OBR</asp:LinkButton>
                                        </ItemTemplate>

                                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField ShowHeader="False">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton2" OnClick="LinkButton2_Click" runat="server" CausesValidation="False" Visible='<%# bind("isVisible") %>' Text="EDIT" OnClientClick="StartProgressBar();" Font-Underline="False" CommandName="Select" __designer:wfdid="w5"></asp:LinkButton>
                                            <asp:LinkButton ID="LinkButton6" OnClick="LinkButton6_Click" runat="server" Enabled="False" Visible="False" Font-Underline="False" CommandName="Select" __designer:wfdid="w11">Cancel</asp:LinkButton>
                                            <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender3" runat="server" TargetControlID="LinkButton6" __designer:wfdid="w12" ConfirmText="Are you sure you want to cancel  this transaction?">
                                            </cc1:ConfirmButtonExtender>
                                        </ItemTemplate>

                                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 10px" align="center"></td>
                        <td style="width: 1000px" class="DivTitle" align="center">DOCUMENT ATTACHMENT</td>
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
                                                        <td style="width: 80%" class="text5">
                                                            <asp:FileUpload ID="FileUpload1" runat="server" Width="400px" ViewStateMode="Inherit" ClientIDMode="Inherit" BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px"></asp:FileUpload></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 20%" class="column_RightBold"></td>
                                                        <td style="width: 80%" class="text5"><span style="color: red; font-family: Calibri">Note:<br />
                                                            &nbsp;&nbsp;&nbsp;&nbsp; Accepted file types:&nbsp;*.jpg, *.png,&nbsp;*.doc, *.rar, *.zip, *.xls, and *.xlsx&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 20%" class="column_RightBold">Document Name :</td>
                                                        <td style="width: 80%" class="text5">
                                                            <asp:TextBox ID="txtDocName" runat="server" Width="300px" CssClass="txtboxinspection"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 20%" class="column_RightBold">Document No. :</td>
                                                        <td style="width: 80%" class="text5">
                                                            <asp:TextBox ID="txtDocNumb" runat="server" Width="300px" CssClass="txtboxinspection"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 20%" class="column_RightBold">Remarks :</td>
                                                        <td style="width: 80%" class="text5">
                                                            <asp:TextBox ID="txtRemarks" runat="server" Width="300px" CssClass="txtboxinspection"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 20%" class="column_RightBold"></td>
                                                        <td style="width: 80%" class="text5">
                                                            <asp:Button ID="UploadButton" OnClick="UploadButton_Click" runat="server" Width="200px" Enabled="False" Text="UPLOAD FILE" OnClientClick="StartProgressBar();"></asp:Button>
                                                            <asp:Label ID="lblNoti" runat="server" ForeColor="Red" Font-Size="9pt" Font-Names="Calibri" Visible="False" Text="* No file to upload."></asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" colspan="2">
                                                            <asp:GridView Style="font-weight: normal; text-align: justify" ID="grdDocuments" runat="server" Width="95%" Font-Size="9pt" SkinID="GridViewAA" DataKeyNames="Attch_ID,ID,DocumentName" PageSize="5" EmptyDataText="No Data Found." AllowPaging="True">
                                                                <Columns>
                                                                    <asp:BoundField DataField="DocumentNo" HeaderText="Document No.">
                                                                        <ItemStyle HorizontalAlign="Center" Width="20%"></ItemStyle>
                                                                    </asp:BoundField>
                                                                    <asp:TemplateField HeaderText="Document Name">
                                                                        <EditItemTemplate>
                                                                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("AttachedFilename") %>'></asp:TextBox>

                                                                        </EditItemTemplate>
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
                                            <fieldset style="border-right: #2977dc 1px solid; border-top: #2977dc 1px solid; border-left: #2977dc 1px solid; width: 250px; border-bottom: #2977dc 1px solid; height: 320px"><legend><span style="font-size: 10pt; font-family: Tahoma"><strong>ATTACHED DOCUMENTS</strong></span></legend>
                                                <br />
                                                <asp:Image ID="imgPRAttachDoc" runat="server" Width="225px" ImageUrl="~/images/blankImage.jpg" Height="290px"></asp:Image></fieldset>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 10px" align="center"></td>
                        <td style="width: 1000px" align="center"></td>
                    </tr>
                </tbody>
            </table>
            <asp:Panel Style="display: none" ID="popup" runat="server" Width="900px">
                <table id="Table2" height="486" cellspacing="0" cellpadding="0" width="747" border="0">
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
                                                                            <td style="width: 50%" class="text5">
                                                                                <asp:TextBox ID="SearchBut" runat="server" Width="98%" CssClass="txtboxinspection"></asp:TextBox></td>
                                                                            <td style="width: 30%" class="text5">
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
                                                            <asp:GridView ID="gvitems" runat="server" Width="100%" Font-Size="9pt" OnSelectedIndexChanged="gvitems_SelectedIndexChanged" CssClass="text" SkinID="GridViewAA" DataKeyNames="item_id" PageSize="8" AllowPaging="True" BackColor="White">
                                                                <Columns>
                                                                    <asp:TemplateField>
                                                                        <EditItemTemplate>
                                                                            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                                                        </EditItemTemplate>
                                                                        <HeaderTemplate>
                                                                            <asp:CheckBox ID="CheckBox2" runat="server" Font-Bold="True" ForeColor="White" Font-Size="10pt" Font-Names="tahoma" AutoPostBack="True" Text="All" OnCheckedChanged="CheckBox2_CheckedChanged"></asp:CheckBox>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="True" OnCheckedChanged="CheckBox1_CheckedChanged" __designer:wfdid="w11"></asp:CheckBox>
                                                                        </ItemTemplate>

                                                                        <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="Item_Desc" HeaderText="Description">
                                                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                                        <ItemStyle HorizontalAlign="Left" Width="65%"></ItemStyle>
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="Description" HeaderText="Unit">
                                                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                                        <ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="cost" DataFormatString="{0:N}" HeaderText="Cost" HtmlEncode="False">
                                                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                                        <ItemStyle HorizontalAlign="Right" Width="15%"></ItemStyle>
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="Item_id" HeaderText="Item_ID">
                                                                        <ItemStyle Width="10px"></ItemStyle>
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="GA_ID" HeaderText="GA_ID"></asp:BoundField>
                                                                    <asp:BoundField DataField="BGA_ID" HeaderText="BGA_ID"></asp:BoundField>
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
                <img src="../images/ajax-loader.gif" />
            </asp:Panel>
            <cc1:ModalPopupExtender ID="ProgressBarModalPopupExtender" runat="server" TargetControlID="ButtonProgress" PopupControlID="PanelProgress" BackgroundCssClass="modalBackground" BehaviorID="ProgressBarModalPopupExtender"></cc1:ModalPopupExtender>
            <asp:Button Style="border-top-style: none; border-right-style: none; border-left-style: none; position: relative; background-color: transparent; border-bottom-style: none" ID="ButtonProgress" runat="server" Width="16px" Enabled="False"></asp:Button><br />
        </ContentTemplate>
    </asp:UpdatePanel>




</asp:Content>

