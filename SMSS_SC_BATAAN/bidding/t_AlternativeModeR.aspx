<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="t_AlternativeModeR.aspx.vb"
    Inherits="Bidding_t_AlternativeMode" Title="ALTERNATIVE MODE OF PROCUREMENT" StylesheetTheme="SkinFile" %>

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
                        <td style="width: 98%" class="PageTitle">ALTERNATIVE MODE OF PROCUREMENT REPORT</td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <table style="width: 95%">
                                <tbody>
                                    <tr>
                                        <td style="vertical-align: top; width: 10%" class="column_LeftBold">Search By :</td>
                                        <td style="vertical-align: top; width: 30%" class="column_Left">
                                            <asp:RadioButtonList ID="rbChoices" runat="server" Width="250px" CssClass="rbCS_Vertical" OnSelectedIndexChanged="rbChoices_SelectedIndexChanged" AutoPostBack="True">
                                                <asp:ListItem Selected="True" Value="1">Purchase Request Number</asp:ListItem>
                                                <asp:ListItem Value="2">Purchase Request Date</asp:ListItem>
                                            </asp:RadioButtonList></td>

                                        <td style="width: 60%" class="column_Left">
                                            <asp:MultiView ID="mvSearch" runat="server">
                                                <asp:View ID="vwPRNumber" runat="server">
                                                    <table style="width: 100%">
                                                        <tbody>
                                                            <tr>
                                                                <td style="width: 100%" class="column_LeftBold">
                                                                    <asp:TextBox ID="txtSearch_PRNo" runat="server" Width="200px" CssClass="txtbox_Var"></asp:TextBox>
                                                                    &nbsp;<asp:Button ID="btnSearch_PRNo" OnClick="btnSearch_PRNo_Click" runat="server" Width="150px" CssClass="CSButton" Text="SEARCH" OnClientClick="StartProgressBar();"></asp:Button></td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </asp:View>

                                                <asp:View ID="vwPRDate" runat="server">
                                                    <table style="width: 100%">
                                                        <tbody>
                                                            <tr>
                                                                <td style="width: 15%" class="column_RightBold">Date From : </td>
                                                                <td style="width: 85%" class="column_Left">
                                                                    <asp:TextBox ID="txtDate_From" runat="server" Width="100px" CssClass="txtbox_Date"></asp:TextBox>
                                                                    <span class="CalendarFormat">(MM/DD/YYYY)</span></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 15%" class="column_RightBold">Date To :</td>
                                                                <td style="width: 85%" class="column_Left">
                                                                    <asp:TextBox ID="txtDate_To" runat="server" Width="100px" CssClass="txtbox_Date"></asp:TextBox>
                                                                    &nbsp;<span class="CalendarFormat">(MM/DD/YYYY)</span>
                                                                    &nbsp;<asp:Button ID="btnSearch_PRDate" OnClick="btnSearch_PRDate_Click" runat="server" Width="150px" CssClass="CSButton" Text="SEARCH" OnClientClick="StartProgressBar();"></asp:Button></span></td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </asp:View>
                                            </asp:MultiView></td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="DivTitle">
                            Purchase Request List
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:GridView ID="grdPurchaseRequest" runat="server" Width="95%" OnSelectedIndexChanged="grdPurchaseRequest_SelectedIndexChanged" 
                                OnPageIndexChanging="grdPurchaseRequest_PageIndexChanging" PageSize="20" SkinID="GridViewAA" EmptyDataText="No Data Found." 
                                DataKeyNames="obr_evaluation_hdr_id" AllowPaging="True">
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkSelect" runat="server" CommandName="Select" Font-Underline="False" CssClass="LinkBtnSelect"
                                                OnClick="lnkSelect_Click" Visible='<%#Bind("isVisible") %>' OnClientClick="StartProgressBar();">Preview</asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="5%" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="pr_no" HeaderText="PR Number">
                                        <ItemStyle HorizontalAlign="Center" Width="15%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="PR_Date" HeaderText="PR Date" DataFormatString="{0:d}">
                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ABC" DataFormatString="{0:N}" HeaderText="ABC">
                                        <ItemStyle HorizontalAlign="Right" Width="10%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="MOP_Desc" HeaderText="Mode of Procurement">
                                        <ItemStyle HorizontalAlign="Left" Width="20%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="remarks" HeaderText="Particulars">
                                        <ItemStyle HorizontalAlign="Left" Width="40%" />
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%">
                             <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDate_From" PopupButtonID="txtDate_From">
                            </cc1:CalendarExtender>
                            <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtDate_To" PopupButtonID="txtDate_To">
                            </cc1:CalendarExtender>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                </table>
            </div>


            


            <asp:Panel Style="border-top-width: 1px; border-left-width: 1px; border-left-color: #0033cc; border-bottom-width: 1px; border-bottom-color: #0033cc; border-top-color: #0033cc; background-color: transparent; text-align: center; border-right-width: 1px; border-right-color: #0033cc" ID="PanelProgress" runat="server" Width="109px">
                <img alt="" src="../images/ajax-loader.gif" />
            </asp:Panel>
            <cc1:ModalPopupExtender ID="ProgressBarModalPopupExtender" runat="server" TargetControlID="ButtonProgress" PopupControlID="PanelProgress" BehaviorID="ProgressBarModalPopupExtender" BackgroundCssClass="modalBackground">
            </cc1:ModalPopupExtender>
            <asp:Button Style="border-top-style: none; border-right-style: none; border-left-style: none; background-color: transparent; border-bottom-style: none" ID="ButtonProgress" runat="server" Width="16px" Enabled="False"></asp:Button>
        
        
        
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>

