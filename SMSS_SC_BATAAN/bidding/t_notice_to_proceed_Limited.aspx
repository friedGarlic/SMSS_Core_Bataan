<%@ Page 
    Language="VB" 
    MasterPageFile="~/MasterPage.master"
    EnableEventValidation="false"
    AutoEventWireup="false" 
    CodeFile="t_notice_to_proceed_Limited.aspx.vb" 
    Inherits="bidding_t_notice_to_proceed_Limited"
    Title="Notice to Proceed" StylesheetTheme="SkinFile"%>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>



            <div>
                <table width="100%">
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="PageTitle">NOTICE TO PROCEED (Public Bidding)
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:GridView ID="grdProceed" runat="server" Width="98%" OnPageIndexChanging="grdProceed_PageIndexChanging" AllowPaging="True"
                                OnRowDataBound="grdProceed_RowDataBound" AutoGenerateColumns="False" SkinID="GridViewAA" PageSize="8" OnSelectedIndexChanged="grdProceed_SelectedIndexChanged"
                                DataKeyNames="Bid_ID,pre_procurement_hdr_id,PR_No,POHdr_ID">
                                <Columns>
                                    <asp:BoundField DataField="SuppName" HeaderText="Bidder Name">
                                        <ItemStyle HorizontalAlign="Left" Width="30%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ProjectName" HeaderText="Article / Project Name">
                                        <ItemStyle HorizontalAlign="Left" Width="46%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="project_reference_no" HeaderText="Reference Number">
                                        <ItemStyle HorizontalAlign="center" Width="12%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Amount" DataFormatString="{0:N}" HeaderText="Total Bid Amount">
                                        <ItemStyle HorizontalAlign="Right" Width="12%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:TemplateField Visible="False">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkProceed" runat="server" Visible='<%#Bind("isVisible") %>' CommandName="Select">Notice to Proceed</asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:TemplateField>
                                </Columns>

                                <FooterStyle BackColor="#2977DC"></FooterStyle>
                                <HeaderStyle BackColor="#2977DC" ForeColor="White"></HeaderStyle>
                            </asp:GridView>
                        </td>
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
                            <table width="80%">
                                <tr>
                                    <td style="width: 20%" class="column_RightBold">Date :</td>
                                    <td style="width: 80%" align="left">
                                        <asp:TextBox ID="txtDateProceed" runat="server" Width="100px" CssClass="txtbox_Date"></asp:TextBox>
                                        &nbsp;<asp:ImageButton ID="ImageButton2" runat="server" Width="20px" ImageUrl="~/images/Calendar_scheduleHS.png" Height="15px"></asp:ImageButton>
                                        &nbsp;<span class="CalendarFormat">(MM/DD/YYYY)</span>
                                        <cc1:CalendarExtender ID="CalendarExtender5" runat="server" Enabled="True" PopupButtonID="ImageButton2" TargetControlID="txtDateProceed"></cc1:CalendarExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 20%" class="column_RightBold">PR Number :</td>
                                    <td style="width: 80%" align="left">
                                        <asp:TextBox ID="txtPRNumber" runat="server" Width="20%" CssClass="txtbox_Var" ReadOnly="True"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 20%" class="column_RightBold">Approved By :</td>
                                    <td style="width: 80%" align="left">
                                        <asp:DropDownList ID="ddApprovedBy" runat="server" Width="50%" OnSelectedIndexChanged="ddApprovedBy_SelectedIndexChanged" CssClass="drpdownCSS" AutoPostBack="True"></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 20%" class="column_RightBold">Position :</td>
                                    <td style="width: 80%" align="left">
                                        <asp:Label ID="lblPosition" runat="server" Font-Size="Medium"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%;height:10px"></td>
                        <td style="width: 98%"></td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:Button ID="btnProceed" OnClick="btnProceed_Click" runat="server" Width="150px" CssClass="CSButton" Text="SAVE" OnClientClick="StartProgressBar();" Enabled="False"></asp:Button>
                            &nbsp;<asp:Button ID="btnPreview" OnClick="btnPreview_Click" runat="server" Width="150px" CssClass="CSButton" Text="PREVIEW" OnClientClick="StartProgressBar();" Enabled="False"></asp:Button>
                            &nbsp;<asp:Button ID="btnReturn" runat="server" Enabled="False" Width="150px" CssClass="CSButton" OnClientClick="StartProgressBar();" Text="RETURN" />
                            <cc1:ConfirmButtonExtender ID="ConfirmReturn" runat="server" TargetControlID="btnReturn" ConfirmText="Are you sure you want to return this PO for approval?"></cc1:ConfirmButtonExtender>
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
            <cc1:ModalPopupExtender ID="ProgressBarModalPopupExtender" runat="server" TargetControlID="ButtonProgress" BehaviorID="ProgressBarModalPopupExtender" PopupControlID="PanelProgress" BackgroundCssClass="modalBackground">
            </cc1:ModalPopupExtender>
            <asp:Button Style="border-top-style: none; border-right-style: none; border-left-style: none; background-color: transparent; border-bottom-style: none" ID="ButtonProgress" runat="server" Width="16px" Enabled="False"></asp:Button>&nbsp;&nbsp; 
        
        
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

