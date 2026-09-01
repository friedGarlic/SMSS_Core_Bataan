<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="t_canvass_infra.aspx.vb"
    Inherits="t_canvass_infra" Title="Direct Contracting" StylesheetTheme="SkinFile" %>


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

    <asp:UpdatePanel ID="upEmployeeDetail" runat="server">
        <ContentTemplate>

            <div>
                <table width="100%">
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="PageTitle">DIRECT CONTRACTING
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="right">
                            <span class="column_RightBold">Date :</span>
                            &nbsp;<asp:TextBox ID="txtDate" runat="server" Width="100px" CssClass="txtbox_Date"></asp:TextBox>
                            &nbsp;<asp:ImageButton ID="ImageButton2" runat="server" Width="20px" ImageUrl="~/images/Calendar_scheduleHS.png" Height="15px"></asp:ImageButton>
                            &nbsp;<span class="CalendarFormat">(MM/DD/YYYY)</span>
                            <cc1:CalendarExtender ID="CalendarExtender5" runat="server" TargetControlID="txtDate" PopupButtonID="ImageButton2" Enabled="True"></cc1:CalendarExtender>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <span class="column_RightBold">Search By :</span>
                            &nbsp;<asp:DropDownList ID="ddSearchDC" runat="server" Width="120px" CssClass="drpdownCSS" OnSelectedIndexChanged="ddSearchDC_SelectedIndexChanged" AutoPostBack="True">
                                <asp:ListItem Selected="True" Value="1">PR Number</asp:ListItem>
                                <asp:ListItem Value="2">Department</asp:ListItem>
                                <asp:ListItem Value="3">OBR Number</asp:ListItem>
                            </asp:DropDownList>
                            &nbsp;<asp:TextBox ID="txtSearch" runat="server" Width="200px" CssClass="txtbox_Var"></asp:TextBox>
                            &nbsp;<asp:Button ID="btnSearch" OnClick="btnSearch_Click" runat="server" Width="150px" CssClass="CSButton" OnClientClick="StartProgressBar();" Text="SEARCH"></asp:Button>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:GridView ID="grdDirectContract" runat="server" Width="98%" OnSelectedIndexChanged="grdDirectContract_SelectedIndexChanged"
                                OnPageIndexChanging="grdDirectContract_PageIndexChanging" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="prhdr_id"
                                PageSize="8" SkinID="GridViewAA">
                                <Columns>
                                    <asp:TemplateField HeaderText="PR Number">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbPR_No" OnClick="lbPR_No_Click" runat="server" CausesValidation="False" Text='<%# bind("pr_no") %>' Font-Underline="False" CommandName="Select"></asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="OBR_No" HeaderText="OBR Number">
                                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ABC" DataFormatString="{0:N}" HeaderText="ABC">
                                        <ItemStyle HorizontalAlign="Right" Width="10%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="rc_name" HeaderText="Department">
                                        <ItemStyle HorizontalAlign="Left" Width="55%"></ItemStyle>
                                    </asp:BoundField>                                   
                                    <asp:BoundField DataField="DateApproved" DataFormatString="{0:d}" HeaderText="Date Approved">
                                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Action">                                      
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbCancel" OnClick="lbCancel_Click" runat="server" CssClass="LinkBtnCancel" OnClientClick="StartProgressBar();" Font-Underline="False" CommandName="Select" Visible='<%#Bind("isVisible") %>'>Return</asp:LinkButton>
                                            <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender5" runat="server" ConfirmText="Are you sure you want to return this PR to OBR Evaluation?" TargetControlID="lbCancel"></cc1:ConfirmButtonExtender>
                                        </ItemTemplate>

                                        <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                    </asp:TemplateField>
                                </Columns>

                                <FooterStyle BackColor="#2977DC"></FooterStyle>
                                <HeaderStyle BackColor="#2977DC" ForeColor="White"></HeaderStyle>
                            </asp:GridView>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%; height: 10px"></td>
                        <td style="width: 98%"></td>
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
                                        <asp:GridView ID="grdDCItems" runat="server" Width="100%" PageSize="5" SkinID="GridViewAA" ShowFooter="True"
                                            EmptyDataText="No Data Found">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <asp:CheckBox ID="cbALL" runat="server" Enabled="False" OnCheckedChanged="cbALL_CheckedChanged"></asp:CheckBox>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="CheckBox1" runat="server" Enabled="False" AutoPostBack="True" OnCheckedChanged="CheckBox1_CheckedChanged"></asp:CheckBox>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Description">                                                    
                                                    <ItemTemplate>
                                                        <asp:Label  ID="lbldesc" runat="server" Text='<%# Bind("Item_Desc") %>' ></asp:Label>
                                                    </ItemTemplate>

                                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Left" Width="55%"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Unit">                                                   
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblunit" runat="server" CssClass="text" Text='<%# Bind("Unit") %>' ></asp:Label>
                                                    </ItemTemplate>

                                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Quantity">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblqty" runat="server" Text='<%# Bind("qty") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Price">
                                                    <FooterTemplate>
                                                        <strong>TOTAL</strong>
                                                    </FooterTemplate>                                             
                                                    <ItemTemplate>
                                                        <asp:TextBox  ID="txtCost" runat="server" Width="98%" CssClass="txtbox_Amt"  Text='<%# Bind("cost", "{0:N}") %>' AutoPostBack="True" OnTextChanged="txtCost_TextChanged"></asp:TextBox>
                                                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"  TargetControlID="txtCost" ValidChars="0123456789.,"></cc1:FilteredTextBoxExtender>
                                                    </ItemTemplate>

                                                    <FooterStyle HorizontalAlign="Right"></FooterStyle>
                                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Right" Width="10%"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Total Amount">
                                                    <FooterTemplate>
                                                        <asp:Label  ID="lbltotal" runat="server" Text='<%# Bind("total", "{0:N}") %>' ></asp:Label>
                                                    </FooterTemplate>
                                                   
                                                    <ItemTemplate>
                                                        <asp:Label Style="text-align: right" ID="lbltotalx" runat="server" Text='<%#Bind("total", "{0:N}") %>' ></asp:Label>
                                                    </ItemTemplate>

                                                    <FooterStyle HorizontalAlign="Right" Font-Bold="False"></FooterStyle>
                                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Right" Width="10%"></ItemStyle>
                                                </asp:TemplateField>
                                            </Columns>

                                            <FooterStyle BackColor="#2977DC"></FooterStyle>
                                            <HeaderStyle BackColor="#2977DC" Font-Names="Arial" Font-Size="8pt" ForeColor="White"></HeaderStyle>
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
                            <span class="column_RightBold">Supplier :</span>
                            &nbsp;<asp:DropDownList ID="ddSupplier" runat="server" AutoPostBack="True" Enabled="False" OnSelectedIndexChanged="ddSupplier_SelectedIndexChanged" Width="350px" CssClass="drpdownCSS">
                                 </asp:DropDownList>
                            &nbsp;<asp:Button ID="btnsupplier" runat="server" Enabled="False" OnClick="btnsupplier_Click" OnClientClick="StartProgressBar();" Text="SAVE" Width="150px" CssClass="CSButton" />
                            <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" ConfirmText="Are you sure you want to save  this transaction?" TargetControlID="btnsupplier">
                            </cc1:ConfirmButtonExtender>
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
            
            

            <asp:Panel ID="pnlDC" runat="server" Width="500px" BorderWidth="2px" BorderStyle="Solid" BorderColor="#FFA016" BackColor="White">
                <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                    <tbody>
                        <tr>
                            <td style="text-align: center">
                                <asp:Button ID="Button1" runat="server" Width="80px" Text="OK" ValidationGroup="ok"></asp:Button>
                                <asp:Button ID="Button2" runat="server" Width="80px" Text="CANCEL"></asp:Button></td>
                        </tr>
                    </tbody>
                </table>
                <asp:Label ID="pr_pop_up" runat="server"> </asp:Label>
            </asp:Panel>
            <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="pr_pop_up" PopupControlID="pnlDC" BackgroundCssClass="modalBackground" CancelControlID="Button2">
            </cc1:ModalPopupExtender>

            <asp:Panel Style="border-top-width: 1px; border-left-width: 1px; border-left-color: #0033cc; border-bottom-width: 1px; border-bottom-color: #0033cc; border-top-color: #0033cc; background-color: transparent; text-align: center; border-right-width: 1px; border-right-color: #0033cc" ID="PanelProgress" runat="server" Width="109px" __designer:wfdid="w32">
                <img alt="" src="../images/ajax-loader.gif" />
            </asp:Panel>
            <cc1:ModalPopupExtender ID="ProgressBarModalPopupExtender" runat="server" TargetControlID="ButtonProgress" PopupControlID="PanelProgress" BackgroundCssClass="modalBackground" BehaviorID="ProgressBarModalPopupExtender"></cc1:ModalPopupExtender>
            <asp:Button Style="border-top-style: none; border-right-style: none; border-left-style: none; background-color: transparent; border-bottom-style: none" ID="ButtonProgress" runat="server" Width="16px" Enabled="False"></asp:Button>

           


        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

