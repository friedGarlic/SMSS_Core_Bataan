<%@ Page 
    Language="VB" 
    AutoEventWireup="false" 
    MasterPageFile="~/MasterPage.master"
    EnableEventValidation="false"
    CodeFile="t_notice_of_award_Limited.aspx.vb" 
    Inherits="bidding_t_notice_of_award_Limited"
    Title="Notice of Award" 
    StylesheetTheme="SkinFile"%>



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
                        <td style="width: 98%" class="PageTitle">NOTICE OF AWARD (Public Bidding)
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="right">
                            <span class="column_RightBold">Date :</span>
                            &nbsp;<asp:TextBox ID="txtAwardDate" runat="server" Width="100px" CssClass="txtbox_Date"></asp:TextBox>
                            &nbsp;<asp:ImageButton ID="ImageButton2" runat="server" Width="20px" ImageUrl="~/images/Calendar_scheduleHS.png" Height="15px"></asp:ImageButton>
                            &nbsp;<span class="CalendarFormat">(MM/DD/YYYY)</span>
                            <cc1:CalendarExtender ID="CalendarExtender5" runat="server" TargetControlID="txtAwardDate" Enabled="True" PopupButtonID="ImageButton2"></cc1:CalendarExtender>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:GridView ID="grdNoticeAward" runat="server" Width="98%" OnPageIndexChanging="grdNoticeAward_PageIndexChanging" AllowPaging="True"
                                AutoGenerateColumns="False" SkinID="GridViewAA" DataKeyNames="pre_procurement_hdr_id,TotalBidAmount,CountSupplier,obr_evaluation_hdr_id,isPublicInfra,Supplier_Id,project_name"
                                OnSelectedIndexChanged="grdNoticeAward_SelectedIndexChanged" PageSize="8" OnRowDataBound="grdNoticeAward_RowDataBound">
                                <Columns>
                                    <asp:BoundField DataField="RefNumber" HeaderText="Reference Number">
                                        <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SuppName" HeaderText="Bidder Name">
                                        <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="BidLocation" HeaderText="Bid Location">
                                        <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="CountSupplier" HeaderText="No. of Bidder">
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="TotalBidAmount" DataFormatString="{0:N}" HeaderText="Total Bid Amount">
                                        <ItemStyle HorizontalAlign="Right"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="BAC Resolution" Visible="False">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="linkResolution" OnClick="linkResolution_Click" runat="server" CommandName="Select" Visible='<%#Bind("isVisible") %>'>Preview</asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="90px"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Notice of Award" Visible="False">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="linkNoticeAward" OnClick="linkNoticeAward_Click" runat="server" Enabled="False" CommandName="Select" Visible='<%#Bind("isVisible") %>'>Preview</asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="90px"></ItemStyle>
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
                        <td style="width: 98%" class="DivTitle">List Of Goods
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:Panel ID="Panel1" runat="server" Width="98%" Font-Bold="True" CssClass="PanelSize" ScrollBars="Vertical" HorizontalAlign="Center">
                                <asp:GridView ID="grdItems" runat="server" Width="100%" SkinID="GridViewAA" AutoGenerateColumns="False" AllowPaging="True"
                                    EmptyDataText="No Data Found.">
                                    <Columns>
                                        <asp:BoundField DataField="Item_Desc" HeaderText="Description">
                                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Unit" HeaderText="Unit">
                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Qty" HeaderText="Quantity">
                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="BidAmount" DataFormatString="{0:N}" HeaderText="Bid Amount Per Unit">
                                            <ItemStyle HorizontalAlign="Right"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Total" DataFormatString="{0:N}" HeaderText="Total Amount">
                                            <ItemStyle HorizontalAlign="Right"></ItemStyle>
                                        </asp:BoundField>
                                    </Columns>

                                    <FooterStyle BackColor="#2977DC"></FooterStyle>
                                    <HeaderStyle BackColor="#2977DC" ForeColor="White"></HeaderStyle>
                                </asp:GridView>
                            </asp:Panel>
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
                        <td style="width: 98%" class="DivTitle">Details
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <table width="80%">
                                <tr>
                                    <td style="width: 20%" class="column_RightBold">Project / Contract Name :</td>
                                    <td style="width: 80%" align="left">
                                        <asp:TextBox ID="txtArticle" runat="server" Width="80%" CssClass="txtbox_Remarks" ReadOnly="True" TextMode="MultiLine"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 20%" class="column_RightBold">PR Number :</td>
                                    <td style="width: 80%" align="left">
                                        <asp:TextBox ID="txtPRNumber" runat="server" Width="30%" CssClass="txtbox_Var" ReadOnly="True"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
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
                            <table width="90%">
                                <tr>
                                    <td style="width: 10%" class="column_RightBold">Prepared By :</td>
                                    <td style="width: 35%" align="left">
                                        <asp:DropDownList ID="ddPreparedBy" runat="server" Width="95%" CssClass="drpdownCSS" OnSelectedIndexChanged="ddPreparedBy_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                                    </td>
                                    <td style="width: 15%" class="column_RightBold">Approved By :</td>
                                    <td style="width: 40%" align="left">
                                        <asp:DropDownList ID="ddApprovedBy" runat="server" Width="90%" CssClass="drpdownCSS" OnSelectedIndexChanged="ddApprovedBy_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 10%" class="column_RightBold">Position :</td>
                                    <td style="width: 35%" align="left">
                                        <asp:Label ID="lblPreparedPos" runat="server" CssClass="column_LeftBold"></asp:Label>
                                    </td>
                                    <td style="width: 15%" class="column_RightBold">Position :</td>
                                    <td style="width: 40%" align="left">
                                        <asp:Label ID="lblPosition" runat="server" CssClass="column_LeftBold"></asp:Label>
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
                            <asp:Button ID="btnSave" OnClick="btnSave_Click" runat="server" Width="150px" CssClass="CSButton" Enabled="False" OnClientClick="StartProgressBar();" Text="SAVE"></asp:Button>
                            &nbsp;<asp:Button ID="btnNOA" OnClick="btnNOA_Click" runat="server" Width="150px" CssClass="CSButton" Enabled="False" OnClientClick="StartProgressBar();" Text="PREVIEW NOA"></asp:Button>
                            <%--&nbsp;<asp:Button ID="btnResolution" OnClick="btnResolution_Click" runat="server" Width="150px" CssClass="CSButton" Enabled="True" OnClientClick="StartProgressBar();" Text=" PREVIEW BAC RESOLUTION" Visible="True"></asp:Button>--%>
                            &nbsp;<asp:Button ID="btnPreviewBACResolution" OnClick="btnPreviewBACResolution_Click" runat="server" Width="180px" CssClass="CSButton" Enabled="False" Text="PREVIEW BAC RESOLUTION"></asp:Button>
                            &nbsp;<asp:Button ID="btnReturn" runat="server" Enabled="False" OnClientClick="StartProgressBar();" Text="RETURN" Width="150px" CssClass="CSButton" />
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

            


            <asp:Panel Style="border-top-width: 1px; border-left-width: 1px; border-left-color: #0033cc; border-bottom-width: 1px; border-bottom-color: #0033cc; border-top-color: #0033cc; background-color: transparent; text-align: center; border-right-width: 1px; border-right-color: #0033cc" ID="PanelProgress" runat="server" Width="109px">
                <img alt="" src="../images/ajax-loader.gif" />
            </asp:Panel>
            <cc1:ModalPopupExtender ID="ProgressBarModalPopupExtender" runat="server" TargetControlID="ButtonProgress" PopupControlID="PanelProgress" BehaviorID="ProgressBarModalPopupExtender" BackgroundCssClass="modalBackground">
            </cc1:ModalPopupExtender>
            <asp:Button Style="border-top-style: none; border-right-style: none; border-left-style: none; background-color: transparent; border-bottom-style: none" ID="ButtonProgress" runat="server" Width="16px" Enabled="False"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
        
        
        </ContentTemplate>
    </asp:UpdatePanel>


</asp:Content>

