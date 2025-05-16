<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="t_Agency.aspx.vb"
    Inherits="bidding_t_Agency" Title="Agency to Agency Mode of Procurement" StylesheetTheme="SkinFile" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="upEmployeeDetail" runat="server">
        <ContentTemplate>

            <div>
                <table width="1020px">
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="PageTitle">AGENCY TO AGENCY MODE OF PROCUREMENT
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
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <table width="90%">
                                <tr>
                                    <td style="width: 10%" class="column_RightBold">Search By :</td>
                                    <td style="width: 15%" class="column_Left">
                                        <asp:DropDownList ID="ddSearchDC" runat="server" Width="150px" CssClass="drpdownCSS" OnSelectedIndexChanged="ddSearchDC_SelectedIndexChanged" AutoPostBack="True">
                                            <asp:ListItem Selected="True" Value="1">PR Number</asp:ListItem>
                                            <asp:ListItem Value="2">Department</asp:ListItem>
                                            <asp:ListItem Value="3">OBR Number</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td style="width: 75%" class="column_Left">
                                        <asp:MultiView ID="MultiView1" runat="server">
                                            <asp:View ID="View1" runat="server">
                                                <table style="width: 100%">
                                                    <tbody>
                                                        <tr>
                                                            <td style="width: 20%" class="column_RightBold">PR Number :</td>
                                                            <td style="width: 80%" class="column_Left">
                                                                <asp:TextBox ID="txtPRNo" runat="server" Width="200px" CssClass="txtbox_Var"></asp:TextBox>
                                                                &nbsp;<asp:Button ID="btnSearchPRNumb" OnClick="btnSearchPRNumb_Click" runat="server" Width="120px" CssClass="CSButton" OnClientClick="StartProgressBar();" Text="SEARCH"></asp:Button></td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </asp:View>
                                            <asp:View ID="View2" runat="server">
                                                <table style="width: 100%">
                                                    <tbody>
                                                        <tr>
                                                            <td style="width: 20%" class="column_RightBold">Department : </td>
                                                            <td style="width: 80%" class="column_Left">
                                                                <asp:DropDownList ID="ddDept" runat="server" Width="300px" CssClass="drpdownCSS" AutoPostBack="True">
                                                                </asp:DropDownList>
                                                                &nbsp;<asp:Button ID="btnSearchDept" OnClick="btnSearchDept_Click" runat="server" Width="120px" CssClass="CSButton" OnClientClick="StartProgressBar();" Text="SEARCH"></asp:Button>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </asp:View>
                                            <asp:View ID="View3" runat="server">
                                                <table style="width: 100%">
                                                    <tbody>
                                                        <tr>
                                                            <td style="width: 20%" class="column_RightBold">OBR Number : </td>
                                                            <td style="width: 80%" class="column_Left">
                                                                <asp:TextBox ID="txtOBR" runat="server" Width="200px" CssClass="txtbox_Var"></asp:TextBox>
                                                                &nbsp;<asp:Button ID="btnSearchOBR" OnClick="btnSearchOBR_Click" runat="server" Width="120px" CssClass="CSButton" OnClientClick="StartProgressBar();" Text="SEARCH"></asp:Button></td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </asp:View>
                                        </asp:MultiView>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="DivTitle">Purchase Request
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:GridView ID="grdAgency" runat="server" Width="98%" OnSelectedIndexChanged="grdAgency_SelectedIndexChanged" SkinID="GridViewAA"
                                PageSize="8" DataKeyNames="prhdr_id" AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="grdAgency_PageIndexChanging">
                                <Columns>
                                    <asp:TemplateField HeaderText="PR Number" ShowHeader="False">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton1" OnClick="LinkButton1_Click" runat="server" CausesValidation="False" Text='<%# bind("pr_no") %>' CommandName="Select" Font-Underline="False"></asp:LinkButton>
                                        </ItemTemplate>

                                        <ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="OBR_No" HeaderText="OBR Number">
                                        <ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ABC" DataFormatString="{0:N}" HeaderText="ABC">
                                        <ItemStyle HorizontalAlign="Right" Width="15%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="rc_name" HeaderText="Department">
                                        <ItemStyle HorizontalAlign="Left" Width="40%"></ItemStyle>
                                    </asp:BoundField>
                                   <%-- <asp:BoundField DataField="Function_Desc" HeaderText="Function">
                                        <ItemStyle HorizontalAlign="Left" Width="20%"></ItemStyle>
                                    </asp:BoundField>--%>
                                    <asp:BoundField DataField="DateApproved" DataFormatString="{0:d}" HeaderText="Date Approved">
                                        <ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Action" Visible="False">
                                        <EditItemTemplate>
                                            <asp:TextBox runat="server" ID="TextBox1"></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbCancel" OnClick="lbCancel_Click" CssClass="LinkBtnCancel" runat="server" OnClientClick="StartProgressBar();" Font-Underline="False" CommandName="Select" Visible='<%#Bind("isVisible") %>'>Return</asp:LinkButton><cc1:ConfirmButtonExtender ID="ConfirmButtonExtender5" runat="server" ConfirmText="Are you sure you want to return this PR to OBR Evaluation?" TargetControlID="lbCancel"></cc1:ConfirmButtonExtender>
                                        </ItemTemplate>

                                        <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                    </asp:TemplateField>
                                </Columns>

                                <FooterStyle BackColor="#2977DC"></FooterStyle>
                            </asp:GridView>
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
                                        <asp:GridView ID="grdAgencyItems" runat="server" Width="100%" EmptyDataText="No Data Found" SkinID="GridViewAA"
                                            PageSize="5" ShowFooter="True">
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
                                                        <asp:Label ID="lbldesc" runat="server" Text='<%# Bind("Item_Desc") %>'></asp:Label>
                                                    </ItemTemplate>

                                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Left" Width="55%"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Unit">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblunit" runat="server" Text='<%# Bind("Unit") %>'></asp:Label>
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
                                                        TOTAL
                                                    </FooterTemplate>

                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtCost" runat="server" Width="98%" CssClass="txtbox_Amt" Text='<%# Bind("cost", "{0:N}") %>' AutoPostBack="True" OnTextChanged="txtCost_TextChanged"></asp:TextBox>
                                                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtCost" ValidChars="0123456789.,"></cc1:FilteredTextBoxExtender>
                                                    </ItemTemplate>

                                                    <FooterStyle HorizontalAlign="Right"></FooterStyle>
                                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Right" Width="10%"></ItemStyle>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Total Amount">
                                                    <FooterTemplate>
                                                        <asp:Label Style="text-align: right" ID="lbltotal" runat="server" Width="100px" CssClass="text" Text='<%# Bind("total", "{0:N}") %>'></asp:Label>
                                                    </FooterTemplate>

                                                    <ItemTemplate>
                                                        <asp:Label Style="text-align: right" ID="lbltotalx" runat="server" Width="100px" Text='<%#Bind("total", "{0:N}") %>'></asp:Label>
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
                        <td style="width: 98%; height: 10px"></td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <span class="column_RightBold">Supplier :</span>
                            &nbsp;<asp:DropDownList ID="ddSupplier" runat="server" Width="300px" OnSelectedIndexChanged="ddSupplier_SelectedIndexChanged" CssClass="drpdownCSS" Enabled="False" AutoPostBack="True"></asp:DropDownList><span style="font-size: 9pt; font-family: Arial"><strong></strong></span>
                            &nbsp;<asp:Button ID="btnsupplier" OnClick="btnsupplier_Click" runat="server" Width="150px" CssClass="CSButton" Enabled="False" Text="SAVE" OnClientClick="StartProgressBar();"></asp:Button>
                            &nbsp;<asp:Button ID="btnPreview" runat="server" Enabled="False" OnClientClick="StartProgressBar();" Text="PREVIEW" CssClass="CSButton" Width="150px" />
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%">
                            <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" TargetControlID="btnSaveBACReso" ConfirmText="Are you sure you want to save  this transaction?"></cc1:ConfirmButtonExtender>
                            <cc1:CalendarExtender ID="CalendarExtender5" runat="server" TargetControlID="txtDate" PopupButtonID="ImageButton2" Enabled="True"></cc1:CalendarExtender>
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



            <asp:Panel Style="border-top-width: 1px; border-left-width: 1px; border-left-color: #0033cc; border-bottom-width: 1px; border-bottom-color: #0033cc; border-top-color: #0033cc; background-color: transparent; text-align: center; border-right-width: 1px; border-right-color: #0033cc" ID="PanelProgress" runat="server" Width="109px">
                <img alt="" src="../images/ajax-loader.gif" />
            </asp:Panel>
            <cc1:ModalPopupExtender ID="ProgressBarModalPopupExtender" runat="server" TargetControlID="ButtonProgress" PopupControlID="PanelProgress" BackgroundCssClass="modalBackground" BehaviorID="ProgressBarModalPopupExtender"></cc1:ModalPopupExtender>
            <asp:Button Style="border-top-style: none; border-right-style: none; border-left-style: none; background-color: transparent; border-bottom-style: none" ID="ButtonProgress" runat="server" Width="16px" Enabled="False"></asp:Button>
            
            
            
            <asp:Panel ID="pnlDC" runat="server" Width="500px" BorderWidth="2px" BorderStyle="Solid" BorderColor="#FFA016" BackColor="White">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <table style="width: 500px" cellspacing="0" cellpadding="0" border="0">
                            <tbody>
                                <tr>
                                    <td style="width: 100px"></td>
                                </tr>
                                <tr>
                                    <td style="height: 20px; background-color: #ffa016; text-align: center"><strong style="color: white">Supplier Name</strong></td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:DropDownList ID="ddSupplier2" runat="server" Width="500px">
                                        </asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td style="color: white; height: 21px; background-color: #ffa016; text-align: center"><strong>Resolution Number&nbsp; Recommending the mode of Procurement</strong></td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="txtResu" runat="server" Width="94%" ValidationGroup="ok"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" BorderStyle="None" ValidationGroup="ok" ErrorMessage="*" ControlToValidate="txtResu"></asp:RequiredFieldValidator></td>
                                </tr>
                                <tr>
                                    <td></td>
                                </tr>
                            </tbody>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>

                <table style="width: 500px" cellspacing="0" cellpadding="0" border="0">
                    <tbody>
                        <tr>
                            <td style="text-align: center">
                                <asp:Button ID="Button1" runat="server" Width="80px" Text="OK" ValidationGroup="ok"></asp:Button>
                                <asp:Button ID="Button2" runat="server" Width="80px" Text="CANCEL"></asp:Button></td>
                        </tr>
                    </tbody>
                </table>
                <asp:Label ID="pr_pop_up" runat="server"></asp:Label>
            </asp:Panel>
            <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="pr_pop_up" PopupControlID="pnlDC" BackgroundCssClass="modalBackground" CancelControlID="Button2">
            </cc1:ModalPopupExtender>



            <asp:Panel runat="server" ID="pnlResolution" Width="250px" BackColor="White" CssClass="Panel_Popup">
                <table width="100%">
                    <tr>
                        <td style="width:100%" class="DivTitle">BAC Resolution Number
                        </td>
                    </tr>
                    <tr>
                        <td style="width:100%;height:10px"></td>
                    </tr>
                    <tr>
                        <td style="width: 100%" align="center">
                            <asp:TextBox runat="server" ID="txtBACResoNo" Width="150px" CssClass="txtbox_Date" >
                            </asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width:100%;height:10px"></td>
                    </tr>
                    <tr>
                        <td align="center" style="width: 100%">
                            <asp:Button ID="btnSaveBACReso" runat="server" Width="100px" CssClass="CSButton" Text="SAVE"></asp:Button>
                            &nbsp;<asp:Button ID="btnCancelBAC" runat="server" Width="100px" CssClass="CSButton" Text="CANCEL"></asp:Button>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" style="width: 100%;height:10px">
                            <asp:Label runat="server" ID="lblResoUp"></asp:Label>
                        </td>
                    </tr>                  
                </table>

            </asp:Panel>
            <cc1:ModalPopupExtender ID="ModalPopupExtender2" runat="server" TargetControlID="lblResoUp" PopupControlID="pnlResolution" BackgroundCssClass="modalBackground">
            </cc1:ModalPopupExtender>

        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>

