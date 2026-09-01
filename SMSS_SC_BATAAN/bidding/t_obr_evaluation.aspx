<%@ Page 
    Language="VB" 
    MasterPageFile="~/MasterPage.master" 
    AutoEventWireup="false" 
    CodeFile="t_obr_evaluation.aspx.vb" 
    Inherits="bidding_t_obr_evaluation" 
    Title="OBR-Evaluation" 
    StylesheetTheme="SkinFile" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="upEmployeeDetail" runat="server">
        <ContentTemplate>


            <div>
                <table width="100%">
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="PageTitle">PRE - PROCUREMENT
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <span class="column_RightBold">Search PR Number :</span>
                            <asp:TextBox ID="txtOBR_Search" runat="server" Width="250px" CssClass="txtbox_Var"></asp:TextBox>
                            &nbsp;<asp:Button ID="btnSearch" OnClick="btnSearch_Click" runat="server" CssClass="CSButton" Width="150px" Text="SEARCH" OnClientClick="StartProgressBar();"></asp:Button>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                <ContentTemplate>
                                    <asp:Panel ID="Panel2" runat="server" Width="98%" CssClass="PanelSize" ScrollBars="Vertical" BorderColor="DodgerBlue" BorderStyle="Solid" BorderWidth="1px">
                                        <asp:GridView ID="gvIncomingPR" runat="server" Width="100%" EmptyDataText="No Data Found." Font-Size="8pt" CssClass="text" OnSelectedIndexChanged="gvIncomingPR_SelectedIndexChanged" DataKeyNames="prhdr_id,pr_no,remarks,ABC,isPublicInfra,isStraight" AutoGenerateColumns="False" SkinID="GridViewAA">
                                            <Columns>
                                     <asp:TemplateField>
                                      <ItemTemplate>
                                                        <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="True"  Visible="true" OnCheckedChanged="CheckBox1_CheckedChanged"></asp:CheckBox>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" Width="10px"></ItemStyle>
                                               </asp:TemplateField>
                                                <asp:TemplateField HeaderText="CAA Number" ShowHeader="False">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="LinkButton1" OnClick="LinkButton1_Click" runat="server" CausesValidation="False" Text='<%#Bind("OBR_No") %>' Font-Underline="False" CommandName="Select"></asp:LinkButton>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="pr_no" HeaderText="PR Number">
                                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="rc_name" HeaderText="Department">
                                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Function_Desc" HeaderText="Function" Visible="false">
                                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="Date Approved">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("DateApproved", "{0:MM/dd/yyyy}") %>'></asp:Label>
                                                    </ItemTemplate>

                                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="ABC">
                                                    <ItemTemplate>
                                                        <asp:Label Style="text-align: right" ID="Label2" runat="server" Text='<%# Bind("ABC", "{0:N}") %>'></asp:Label>
                                                    </ItemTemplate>

                                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Right"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField ShowHeader="False" Visible="False">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="LinkButton2" OnClick="LinkButton2_Click" runat="server" Width="40px" CausesValidation="False" Text="view" Font-Underline="False" CommandName="Select"></asp:LinkButton>
                                                    </ItemTemplate>

                                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                </asp:TemplateField>
                                            </Columns>

                                            <FooterStyle BackColor="#2977DC"></FooterStyle>
                                            <HeaderStyle BackColor="#2977DC" ForeColor="White"></HeaderStyle>
                                        </asp:GridView>
                                    </asp:Panel>
                                </ContentTemplate>
                            </asp:UpdatePanel>
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
                        <td style="width: 98%" class="DivTitle">Signatories
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <table style="width: 95%">
                                <tr>
                                    <td style="width: 15%" class="column_RightBold">Mode of Procurement :</td>
                                    <td style="width: 35%" class="column_Left">
                                        <asp:DropDownList ID="dd_mode_of_procurement" runat="server" Width="98%" CssClass="drpdownCSS" OnSelectedIndexChanged="dd_mode_of_procurement_SelectedIndexChanged" AutoPostBack="True" Enabled="False">
                                            <asp:ListItem Text="Select"></asp:ListItem>
                                        </asp:DropDownList></td>
                                    <td style="width: 15%" class="column_RightBold">&nbsp;</td>
                                    <td style="width: 35%" class="column_Left">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td style="width: 15%; height: 10px" class="column_RightBold">No. of BAC Signatories:</td>
                                    <td style="width: 35%" class="column_Left">
                                        <asp:DropDownList ID="ddSearchOption" runat="server" AutoPostBack="True" CssClass="drpdownCSS" Width="200px">
                                            <asp:ListItem Selected="True" Value="1">7 BAC member signatories</asp:ListItem>
                                            <asp:ListItem Value="2">5 BAC member signatories</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td style="width: 15%" class="column_RightBold"></td>
                                    <td style="width: 35%" class="column_Left">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td style="width: 15%" class="column_RightBold">BAC Member 1 :</td>
                                    <td style="width: 35%" class="column_Left">
                                        <asp:DropDownList ID="ddBAC1" runat="server" CssClass="drpdownCSS" Width="98%">
                                        </asp:DropDownList>
                                    </td>
                                    <td style="width: 15%" class="column_RightBold">BAC Vice Chairman : </td>
                                    <td style="width: 35%" class="column_Left">
                                        <asp:DropDownList ID="ddBACVC" runat="server" Width="98%" CssClass="drpdownCSS"></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 15%" class="column_RightBold">BAC Member 2 : </td>
                                    <td style="width: 35%" class="column_Left">
                                        <asp:DropDownList ID="ddBAC2" runat="server" Width="98%" CssClass="drpdownCSS"></asp:DropDownList>
                                    </td>
                                    <td style="width: 15%" class="column_RightBold">BAC Chairman : </td>
                                    <td style="width: 35%" class="column_Left">
                                        <asp:DropDownList ID="ddBACC" runat="server" Width="98%" CssClass="drpdownCSS"></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 15%" class="column_RightBold">BAC Member 3 : </td>
                                    <td style="width: 35%" class="column_Left">
                                        <asp:DropDownList ID="ddBAC3" runat="server" Width="98%" CssClass="drpdownCSS"></asp:DropDownList>
                                    </td>
                                    <td style="width: 15%" class="column_RightBold">Approved By :</td>
                                    <td style="width: 35%" class="column_Left">
                                        <asp:DropDownList ID="ddApprovedBy" runat="server" Width="98%" CssClass="drpdownCSS"></asp:DropDownList>
                                    </td>
                                </tr>
                                 <tr>
                                    <td style="width: 15%" class="column_RightBold">BAC Member 4 : </td>
                                    <td style="width: 35%" class="column_Left">
                                        <asp:DropDownList ID="ddBAC4" runat="server" Width="98%" CssClass="drpdownCSS"></asp:DropDownList>
                                    </td>
                                    <td style="width: 15%" class="column_RightBold"></td>
                                    <td style="width: 35%" class="column_Left"></td>
                                </tr>
                                <tr>
                                    <td style="width: 15%" class="column_RightBold">BAC Member 5 : </td>
                                    <td style="width: 35%" class="column_Left">
                                        <asp:DropDownList ID="ddBAC5" runat="server" Width="98%" CssClass="drpdownCSS"></asp:DropDownList>
                                    </td>
                                    <td style="width: 15%" class="column_RightBold"></td>
                                    <td style="width: 35%" class="column_Left"></td>
                                </tr>
                            </table>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%; height: 10px"></td>
                        <td style="width: 98%"></td>
                        <td style="width: 1%"> <asp:TextBox ID ="txtIsInfra" runat="server" Visible="false"></asp:TextBox></td>
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
                            <asp:Panel ID="Panel3" runat="server" Width="98%" CssClass="PanelSize" ScrollBars="Vertical">
                                <asp:GridView ID="gvGoods" runat="server" Width="100%" OnSelectedIndexChanged="gvGoods_SelectedIndexChanged" EmptyDataText="No Data Found."
                                    ShowFooter="True" PageSize="5" SkinID="GridViewAA" AutoGenerateColumns="False">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Description">
                                            <ItemTemplate>
                                                <asp:Label Style="text-align: left" ID="lbldesc" runat="server" Text='<%# Bind("Item_Desc") %>'></asp:Label>
                                            </ItemTemplate>

                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Unit">
                                            <ItemTemplate>
                                                <asp:Label ID="lblunit" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                                            </ItemTemplate>

                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Quantity">
                                            <ItemTemplate>
                                                <asp:Label Style="text-align: center" ID="lblqty" runat="server" Text='<%#Bind("qty") %>'></asp:Label>
                                            </ItemTemplate>

                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Price">
                                            <ItemTemplate>
                                                <asp:Label Style="text-align: right" ID="lblcost" runat="server" Text='<%#Bind("Cost", "{0:N}") %>'></asp:Label>
                                            </ItemTemplate>

                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                            <ItemStyle HorizontalAlign="Right"></ItemStyle>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Total Amount">
                                            <FooterTemplate>
                                                <asp:Label Style="text-align: right" ID="lbltotal" runat="server" Text='<%# Bind("total", "{0:N}") %>'></asp:Label>
                                            </FooterTemplate>
                                            <ItemTemplate>
                                                <asp:Label Style="text-align: right" ID="lbltotal" runat="server" Text='<%# Bind("total", "{0:N}") %>'></asp:Label>
                                            </ItemTemplate>

                                            <FooterStyle HorizontalAlign="Right" Font-Bold="False"></FooterStyle>
                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                            <ItemStyle HorizontalAlign="Right"></ItemStyle>
                                        </asp:TemplateField>
                                    </Columns>

                                    <FooterStyle BackColor="#2977DC"></FooterStyle>
                                    <HeaderStyle BackColor="#2977DC" Font-Names="Arial" Font-Size="8pt" ForeColor="White"></HeaderStyle>
                                </asp:GridView>
                            </asp:Panel>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:Button ID="btnsave" OnClick="btnsave_Click" runat="server" Width="150px" CssClass="CSButton" Text="SAVE" OnClientClick="StartProgressBar();" Enabled="False" ValidationGroup="save"></asp:Button>
                            &nbsp;<asp:Button ID="btnPreview" OnClick="btnPreview_Click" runat="server" Width="150px" CssClass="CSButton" Text="PREVIEW AMP" OnClientClick="StartProgressBar();" Enabled="False" ValidationGroup="save"></asp:Button>
                            &nbsp;<asp:Button ID="btnBACCertificate" OnClick="btnBACCertificate_Click" runat="server" Width="150px" CssClass="CSButton" Text="BAC CERTIFICATION" OnClientClick="StartProgressBar();" Enabled="False"  ValidationGroup="save" __designer:wfdid="w1"></asp:Button>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center"></td>
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
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%"></td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%">
                            <asp:RadioButtonList ID="RadioButtonList1" runat="server" Visible="False" CssClass="column_Left" RepeatDirection="Horizontal" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" AutoPostBack="True">
                                <asp:ListItem Selected="True">GOODS</asp:ListItem>
                                <asp:ListItem>PUBLIC INFRASTRUCTURE</asp:ListItem>
                            </asp:RadioButtonList>
                            <asp:DropDownList ID="ddFund" runat="server" Visible="False" OnSelectedIndexChanged="ddFund_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>

                </table>
            </div>


            <asp:Panel ID="PopUP_Panel" runat="server" Width="350px" CssClass="Panel_Popup">
                <table style="width: 100%" cellpadding="0px" cellspacing="0px">
                    <tr>
                        <td style="width: 100%" colspan="2" class="DivTitle">Bac Certification
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 30%; height: 5px" class="column_RightBold"></td>
                        <td style="width: 70%" align="left"></td>
                    </tr>
                    <tr>
                        <td style="width: 30%" class="column_RightBold">Date Duration :&nbsp;</td>
                        <td style="width: 70%" align="left">
                            <asp:TextBox ID="txtDateFrom" runat="server" Width="100px" CssClass="txtbox_Date"></asp:TextBox>
                            &nbsp;<span class="column_RightBold">to</span>
                            &nbsp;<asp:TextBox ID="txtDateTo" runat="server" Width="100px" CssClass="txtbox_Date"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 30%; height: 5px" class="column_RightBold"></td>
                        <td style="width: 70%" align="left"></td>
                    </tr>
                    <tr>
                        <td style="width: 30%" class="column_RightBold">Date Issued :&nbsp;</td>
                        <td style="width: 70%" align="left">
                            <asp:TextBox ID="txtDateIssued" runat="server" Width="100px" CssClass="txtbox_Date"></asp:TextBox>
                        </td>
                    </tr>
                     <tr>
                        <td style="width: 30%; height: 5px" class="column_RightBold"></td>
                        <td style="width: 70%" align="left"></td>
                    </tr>
                    <tr>
                        <td style="width: 100%" colspan="2" align="center">
                            <asp:Button ID="btnBACCertSave" OnClick="btnBACCertSave_Click" runat="server" Width="120px" CssClass="CSButton" Text="SAVE" OnClientClick="StartProgressBar();"></asp:Button>
                            &nbsp;<asp:Button ID="btnBACCancel" runat="server"  Width="120px" CssClass="CSButton" Text="CANCEL"></asp:Button>

                        </td>
                    </tr>
                    <tr>
                        <td style="width: 30%; height: 10px" class="column_RightBold"></td>
                        <td style="width: 70%" align="left">
                             <asp:Label ID="lblPopUp" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </asp:Panel>

            <cc1:ModalPopupExtender ID="ModalPopupExtendepopup" runat="server" TargetControlID="lblPopUp" BackgroundCssClass="modalBackground" PopupControlID="PopUP_Panel" CancelControlID="btnBACCancel"></cc1:ModalPopupExtender>
            <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" ConfirmText="Are you sure you want to save this transaction?" TargetControlID="btnsave"></cc1:ConfirmButtonExtender>
            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDateFrom" PopupButtonID="txtDateFrom"></cc1:CalendarExtender>
            <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtDateTo" PopupButtonID="txtDateTo"></cc1:CalendarExtender>
            <cc1:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtDateIssued" PopupButtonID="txtDateIssued"></cc1:CalendarExtender>
            


            <asp:Panel Style="border-top-width: 1px; border-left-width: 1px; border-left-color: #0033cc; border-bottom-width: 1px; border-bottom-color: #0033cc; border-top-color: #0033cc; background-color: transparent; text-align: center; border-right-width: 1px; border-right-color: #0033cc" ID="PanelProgress" runat="server" Width="109px">
                <%--<img alt="" src="../images/ajax-loader.gif" />--%>
            </asp:Panel>
            <cc1:ModalPopupExtender ID="ProgressBarModalPopupExtender" runat="server" TargetControlID="ButtonProgress" BehaviorID="ProgressBarModalPopupExtender" BackgroundCssClass="modalBackground" PopupControlID="PanelProgress"></cc1:ModalPopupExtender>
            <asp:Button Style="border-top-style: none; border-right-style: none; border-left-style: none; background-color: transparent; border-bottom-style: none" ID="ButtonProgress" runat="server" Width="16px" Enabled="False"></asp:Button>&nbsp; 
        
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>

