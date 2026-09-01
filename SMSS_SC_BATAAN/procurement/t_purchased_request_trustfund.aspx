<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" EnableEventValidation="false"
    CodeFile="t_purchased_request_trustfund.aspx.vb" Inherits="procurement_t_purchased_request_trustfund"
    Title="Purchase Request - Trust Fund" StylesheetTheme="SkinFile" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <table style="width: 1000px">
                <tbody>
                    <tr>
                        <td style="width: 10px" class="column_Left"></td>
                        <td style="width: 1000px" class="PageTitle" align="center">CREATE PURCHASE REQUEST - TRUST FUND</td>
                    </tr>
                    <tr>
                        <td style="width: 10px" class="column_Left"></td>
                        <td style="width: 1000px" align="center">
                            <table style="width: 100%">
                                <tbody>
                                    <tr>
                                        <td style="width: 15%" class="column_RightBold">Fund Type :</td>
                                        <td class="column_Left" colspan="3">
                                            <asp:RadioButtonList ID="rbTrustFund" runat="server" Width="500px" CssClass="rbCS_Horizontal" AutoPostBack="True" RepeatDirection="Horizontal" __designer:wfdid="w18" OnSelectedIndexChanged="rbTrustFund_SelectedIndexChanged">
                                                <asp:ListItem Value="1">General Fund</asp:ListItem>
                                                <asp:ListItem Value="2">Special Education Fund</asp:ListItem>
                                                <asp:ListItem Selected="True" Value="3">Trust Fund</asp:ListItem>
                                            </asp:RadioButtonList></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 15%" class="column_RightBold">Transaction Type :</td>
                                        <td style="width: 35%" class="column_Left">
                                            <asp:DropDownList ID="ddTransactionType" runat="server" Width="95%" CssClass="drpdownCSS" AutoPostBack="True" Enabled="False">
                                                <asp:ListItem>Purchase Request</asp:ListItem>
                                                <asp:ListItem>Reimbursement</asp:ListItem>
                                            </asp:DropDownList></td>
                                        <td style="width: 20%" class="column_RightBold"><asp:RadioButtonList ID="RadioButtonList1" runat="server" CssClass="rbCS_Horizontal" Width="174px" RepeatDirection="Horizontal" AutoPostBack="True" Height="30px">
                                                <asp:ListItem Selected="True" Value="0">Current</asp:ListItem>
                                                <asp:ListItem Value="1">Continuing</asp:ListItem>
                                            </asp:RadioButtonList>

                                        </td>
                                        <td style="width: 30%" class="column_Left">
                                            Date :&nbsp; <asp:TextBox ID="txtprdate" runat="server" Width="100px" CssClass="txtbox_Date"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 15%" class="column_RightBold">Department :</td>
                                        <td style="width: 35%" class="column_Left">
                                            <asp:DropDownList ID="ddRC" runat="server" Width="95%" CssClass="drpdownCSS" AutoPostBack="True" OnSelectedIndexChanged="ddRC_SelectedIndexChanged"></asp:DropDownList></td>
                                        <td style="width: 20%" class="column_RightBold">Items&nbsp;:</td>
                                        <td style="width: 30%" class="column_Left">
                                            <asp:LinkButton ID="LinkButton2" OnClick="LinkButton2_Click1" runat="server" ForeColor="#00C000" CssClass="LinkBtnPreview" Enabled="False">View List of Goods</asp:LinkButton></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 15%" class="column_RightBold">Function :</td>
                                        <td style="width: 35%" class="column_Left">
                                            <asp:DropDownList ID="ddFunction" runat="server" Width="95%" CssClass="drpdownCSS" AutoPostBack="True"  OnSelectedIndexChanged="ddFunction_SelectedIndexChanged"></asp:DropDownList></td>
                                        <td style="width: 20%" class="column_RightBold">Payee :</td>
                                        <td style="width: 30%" class="column_Left">
                                            <asp:TextBox ID="txtpeyee" runat="server" Width="95%" CssClass="txtbox_Var" ></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 15%" class="column_RightBold">P/P/A :</td>
                                        <td style="width: 35%" class="column_Left">
                                            <asp:DropDownList ID="ddPAPS" runat="server" Width="95%" CssClass="drpdownCSS" AutoPostBack="True" OnSelectedIndexChanged="ddPAPS_SelectedIndexChanged"></asp:DropDownList></td>
                                        <td style="width: 20%" class="column_RightBold">Address :</td>
                                        <td style="width: 30%" class="column_Left">
                                            <asp:TextBox ID="txtaddpeyee" runat="server" Width="95%" CssClass="txtbox_Var" ></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 15%" class="column_RightBold">Nature of Transaction :</td>
                                        <td style="width: 35%" class="column_Left">
                                            <asp:DropDownList ID="ddnature" runat="server" Width="95%" CssClass="drpdownCSS" AutoPostBack="True" OnSelectedIndexChanged="ddnature_SelectedIndexChanged" Enabled="False">
                                                <asp:ListItem Selected="True">Select</asp:ListItem>
                                                <asp:ListItem Value="2">MOOE</asp:ListItem>
                                                <asp:ListItem Value="3">Capital Outlay</asp:ListItem>
                                            </asp:DropDownList></td>
                                        <td style="width: 20%" class="column_RightBold">Requesting Person :</td>
                                        <td style="width: 30%" class="column_Left">
                                            <asp:DropDownList ID="ddRequestedBy" runat="server" Width="95%" CssClass="drpdownCSS" AutoPostBack="True" OnSelectedIndexChanged="ddRequestedBy_SelectedIndexChanged" Enabled="False" AppendDataBoundItems="True">
                                                <asp:ListItem Value="0">Select</asp:ListItem>
                                            </asp:DropDownList></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 15%" class="column_RightBold">Account Title :</td>
                                        <td style="width: 35%" class="column_Left">
                                            <asp:DropDownList ID="ddAccounts" runat="server" Width="95%" CssClass="drpdownCSS" AutoPostBack="True"  OnSelectedIndexChanged="ddAccounts_SelectedIndexChanged"></asp:DropDownList></td>
                                        <td style="width: 20%" class="column_RightBold">Position :</td>
                                        <td style="width: 30%" class="column_Left">
                                            <asp:TextBox ID="txtposition" runat="server" Width="95%" CssClass="txtbox_Var"  ReadOnly="True"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 15%" class="column_RightBold">
                                            <asp:Label ID="req1" runat="server" ForeColor="Red" Visible="False" Text="*"></asp:Label> Purpose :</td>
                                        <td style="width: 35%" class="column_Left" rowspan="2">
                                            <asp:TextBox Style="text-align: left" ID="txtpurpose" runat="server" Width="95%" CssClass="txtbox_Remarks"  SkinID="text" TextMode="MultiLine" Height="40px"></asp:TextBox></td>
                                        <td style="width: 20%" class="column_RightBold">Approved By : </td>
                                        <td style="width: 30%" class="column_Left">
                                            
                                            <asp:DropDownList ID="ddApprovedBy" runat="server" Width="95%" CssClass="drpdownCSS">
                                            </asp:DropDownList>
                                           </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 15%" class="column_RightBold"></td>
                                        <td style="width: 20%" class="column_RightBold"></td>
                                        <td style="width: 30%" class="column_Left"></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 15%" class="column_RightBold">Note : </td>
                                        <td style="width: 35%" class="column_Left">
                                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtprdate">
                                            </cc1:CalendarExtender>
                                            <asp:TextBox ID="txtNote" runat="server" CssClass="txtbox_Var" Width="95%"></asp:TextBox>
                                        </td>
                                        <td style="width: 20%" class="column_RightBold"></td>
                                        <td style="width: 30%" class="column_Left"></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 15%" class="column_RightBold"></td>
                                        <td style="width: 35%" class="column_Left">
                                            <asp:CheckBox ID="cbReinbursement" runat="server"  Visible="False"></asp:CheckBox></td>
                                        <td style="width: 20%" class="column_RightBold"></td>
                                        <td style="width: 30%" class="column_Left"></td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                    </tr>
                     <tr>
                        <td style="width: 10px" class="column_Left"></td>
                        <td style="width: 1000px" class="DivTitle">Allotment Details</td>
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
                        <td style="width: 10px" class="column_Left"></td>
                        <td style="width: 1000px" class="DivTitle">List Of Goods</td>
                    </tr>
                    <tr>
                        <td style="width: 10px" class="column_Left"></td>
                        <td style="width: 1000px" align="center">
                            <asp:GridView ID="gvbody" runat="server" Width="98%" OnSelectedIndexChanged="gvbody_SelectedIndexChanged" SkinID="GridViewAA" ShowFooter="True" 
                                OnRowDeleting="gvbody_RowDeleting" CaptionAlign="Left" PageSize="5" DataKeyNames="Item_ID,GA_ID,BGA_ID">
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkDelete" OnClick="lnkDelete_Click" runat="server" CausesValidation="False" Font-Underline="False" CommandName="Select">Delete</asp:LinkButton>
                                        </ItemTemplate>

                                        <ItemStyle HorizontalAlign="Center" Width="20px"></ItemStyle>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Description">
                                        <ItemTemplate>
                                            <asp:Label Style="text-align: left" ID="lbldesc" runat="server" Text='<%# Bind("Item_Desc") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Left" Width="50%"></ItemStyle>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Unit">                                       
                                        <ItemTemplate>
                                            <asp:Label ID="lblunit" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Quantity">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtqty" runat="server" Width="95%" CssClass="txtbox_Amt" AutoPostBack="True"  Text='<%# Bind("InputQty") %>' SkinID="text" OnTextChanged="txtqty_TextChanged"></asp:TextBox>
                                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"  TargetControlID="txtqty" ValidChars="0123456789.,"></cc1:FilteredTextBoxExtender>
                                        </ItemTemplate>

                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Price">
                                        <FooterTemplate>
                                            <strong>TOTAL</strong> :
                                        </FooterTemplate>
                                        <ItemTemplate>                                          
                                            <asp:Label ID="lblCost" runat="server" Text='<%# Bind("cost", "{0:N}") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterStyle HorizontalAlign="Right"></FooterStyle>
                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Right" Width="10%"></ItemStyle>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Total">
                                        <FooterTemplate>
                                            <asp:Label ID="lbltotal2" runat="server" Width="100px" Text='<%# Bind("total", "{0:N}") %>'></asp:Label>
                                        </FooterTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lbltotal" runat="server" Width="100px" Text='<%# Bind("total", "{0:N}") %>'></asp:Label>
                                        </ItemTemplate>

                                        <FooterStyle HorizontalAlign="Right" Font-Bold="False"></FooterStyle>
                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Right" Width="15%"></ItemStyle>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Item_ID">
                                        <ItemTemplate>
                                            <asp:Label ID="lblItem_ID" runat="server"  Text='<%# Bind("Item_ID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ImageButton4" runat="server" CommandName="Select" Height="15px" ImageUrl="~/images/delete.png" OnClick="ImageButton4_Click" OnClientClick="StartProgressBar();" />
                                            <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" ConfirmText="Are you sure you want to delete this item?" TargetControlID="ImageButton4">
                                            </cc1:ConfirmButtonExtender>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="5%" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 10px" class="column_Left"></td>
                        <td style="width: 1000px" align="center">
                            <span class="column_RightBold">Checked By :</span>
                            &nbsp;<asp:DropDownList ID="ddCheckedBy" runat="server" Width="300px" CssClass="drpdownCSS"></asp:DropDownList> 
                            &nbsp;<span class="column_RightBold">Noted By :</span>
                            &nbsp;<asp:DropDownList ID="ddNotedBy" runat="server" Width="300px" CssClass="drpdownCSS"></asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td style="width: 10px" class="column_Left"></td>
                        <td style="width: 1000px" align="center">
                            <asp:Button ID="btnSave" OnClick="btnSave_Click" runat="server" Width="150px" CssClass="CSButton" Text="SAVE" OnClientClick="StartProgressBar();"></asp:Button>
                            &nbsp;<asp:Button ID="btnSubmit" OnClick="btnSubmit_Click" runat="server" Width="150px" CssClass="CSButton" Text="SUBMIT" OnClientClick="StartProgressBar();"></asp:Button>
                            &nbsp;<asp:Button ID="btnpreview" OnClick="btnpreview_Click" runat="server" Width="150px" CssClass="CSButton" Enabled="False" Text="PREVIEW"></asp:Button></td>
                    </tr>
                    <tr>
                        <td style="width: 10px" class="column_Left"></td>
                        <td style="width: 1000px" align="center">
                            <asp:GridView  ID="gvListPR" runat="server" Width="98%"  OnSelectedIndexChanged="gvListPR_SelectedIndexChanged" SkinID="GridViewAA" 
                                DataKeyNames="prhdr_id" AutoGenerateColumns="False">
                                <Columns>
                                    <asp:BoundField DataField="remarks" HeaderText="REMARKS">
                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Left" Width="50%"></ItemStyle>
                                    </asp:BoundField>

                                    <asp:BoundField DataField="ABC" DataFormatString="{0:N}" HeaderText="ABC">
                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Right" Width="15%"></ItemStyle>
                                    </asp:BoundField>

                                    <asp:BoundField DataField="Date_Submitted" DataFormatString="{0:MM/dd/yyyy}" HeaderText="DATE">
                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
                                    </asp:BoundField>

                                    <asp:TemplateField HeaderText="Report" ShowHeader="False">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton1" OnClick="LinkButton1_Click1" runat="server" CssClass="LinkBtnSelect" CausesValidation="False" Text="PR" Font-Underline="False" CommandName="Select"></asp:LinkButton>
                                            <asp:LinkButton ID="LinkButton4" OnClick="LinkButton4_Click" runat="server"  CausesValidation="False" Visible="False" Font-Underline="False" CommandName="Select">ObR</asp:LinkButton>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                    </asp:TemplateField>

                                    <asp:TemplateField ShowHeader="False">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton2" OnClick="LinkButton2_Click" runat="server" CausesValidation="False" Text="Edit" CssClass="LinkBtnSelect" Font-Underline="False" CommandName="Select"></asp:LinkButton>
                                            <asp:LinkButton ID="LinkButton6" OnClick="LinkButton6_Click" runat="server"  Visible="False" Font-Underline="False" CommandName="Select">Cancel</asp:LinkButton>
                                            <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender3" runat="server"  TargetControlID="LinkButton6" ConfirmText="Are you sure you want to cancel  this transaction?">
                                            </cc1:ConfirmButtonExtender>
                                        </ItemTemplate>

                                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 10px" class="column_Left"></td>
                        <td style="width: 1000px" align="center"></td>
                    </tr>
                    <tr>
                        <td style="width: 10px" class="column_Left"></td>
                        <td style="width: 1000px" align="center"></td>
                    </tr>
                </tbody>
            </table>



            <asp:Panel Style="display: none" ID="popup" runat="server" Width="706px" CssClass="Panel_Popup" >
                <table id="Table2"  cellspacing="0" cellpadding="0" width="747" border="0">
                    <tbody>
                        
                        
                        <tr>
                            <td style="vertical-align: top; width: 772px; text-align: center" id="Td1">
                                <table style="width: 705px; height: 336px" cellspacing="0" cellpadding="0" border="0">
                                    <tbody>
                                        <tr>
                                            
                                            <td style="vertical-align: top; width: 100%; text-align: center"><%--<asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                <ContentTemplate>--%>
                                                <table style="width: 100%" class="text" cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td style="width: 100%; height: 25px" colspan="3">
                                                                <asp:DropDownList ID="ddpopup" runat="server" Width="150px" __designer:wfdid="w61">
                                                                    <asp:ListItem Value="Item_Desc">Item Description</asp:ListItem>
                                                                </asp:DropDownList>
                                                                <asp:TextBox ID="SearchBut" runat="server" Width="350px" CssClass="text" __designer:wfdid="w62"></asp:TextBox>
                                                                <asp:Button ID="Button5" OnClick="Button5_Click" runat="server" Width="100px" __designer:wfdid="w63" Text="SEARCH" CssClass="CSButton"></asp:Button></td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                                <asp:GridView ID="gvitems" runat="server" Width="100%" __designer:wfdid="w64" SkinID="GridViewAA" PageSize="8" DataKeyNames="item_id" AllowPaging="True" OnPageIndexChanging="gvitems_PageIndexChanging" BackColor="White">
                                                    <Columns>
                                                        <asp:TemplateField>
                                                            <EditItemTemplate>
                                                                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>

                                                            </EditItemTemplate>
                                                            <HeaderTemplate>
                                                                <asp:CheckBox ID="CheckBox2" runat="server" Width="50px" Font-Bold="True" ForeColor="White" Font-Size="10pt" Font-Names="tahoma" __designer:wfdid="w106" AutoPostBack="True" Text="All" OnCheckedChanged="CheckBox2_CheckedChanged"></asp:CheckBox>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="CheckBox1" runat="server" Width="50px" AutoPostBack="True" __designer:wfdid="w6" OnCheckedChanged="CheckBox1_CheckedChanged"></asp:CheckBox>
                                                            </ItemTemplate>

                                                            <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="Item_Desc" HeaderText="Description">
                                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                            <ItemStyle HorizontalAlign="Left" Width="45%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Description" HeaderText="Unit">
                                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                            <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="cost" DataFormatString="{0:N}" HeaderText="Cost">
                                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                            <ItemStyle HorizontalAlign="Right" Width="10%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Item_ID" HeaderText="Item_ID">
                                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="id" HeaderText="ID"></asp:BoundField>
                                                    </Columns>
                                                </asp:GridView>
                                                <%--</ContentTemplate>
                                            </asp:UpdatePanel>--%></td>
                                        </tr>
                                        <tr>
                                           
                                            <td style="width: 100%; text-align: center">
                                                <asp:Button ID="Button3" OnClick="Button3_Click" runat="server" Width="150px"  Text="LOAD" OnClientClick="StartProgressBar();" CssClass="CSButton"></asp:Button>
                                                <asp:Button ID="Button1" OnClick="Button1_Click" runat="server" Width="150px"  Text="CLOSE" OnClientClick="StartProgressBar();" CssClass="CSButton"></asp:Button>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                                <span style="font-size: 11pt">
                                    <asp:Label ID="Label1" runat="server" ></asp:Label></span></td>
                            <td style=" width: 46px; height: 100px"></td>
                        </tr>
                    </tbody>
                </table>
            </asp:Panel>
            <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="Label1" CancelControlID="ImageButton3" BackgroundCssClass="modalBackground" PopupControlID="popup"></cc1:ModalPopupExtender>
            
            
            <asp:Panel Style="border-top-width: 1px; border-left-width: 1px; border-left-color: #0033cc; border-bottom-width: 1px; border-bottom-color: #0033cc; border-top-color: #0033cc; background-color: transparent; text-align: center; border-right-width: 1px; border-right-color: #0033cc" ID="PanelProgress" runat="server" Width="109px" __designer:wfdid="w112">
                <img alt="" src="../images/ajax-loader.gif" />
            </asp:Panel>
            <cc1:ModalPopupExtender ID="ProgressBarModalPopupExtender" runat="server"  TargetControlID="ButtonProgress" BackgroundCssClass="modalBackground" PopupControlID="PanelProgress" BehaviorID="ProgressBarModalPopupExtender"></cc1:ModalPopupExtender>
            <asp:Button Style="border-top-style: none; border-right-style: none; border-left-style: none; background-color: transparent; border-bottom-style: none" ID="ButtonProgress" runat="server" Width="16px" __designer:wfdid="w114" Enabled="False"></asp:Button>&nbsp;&nbsp; 
        
        
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>

