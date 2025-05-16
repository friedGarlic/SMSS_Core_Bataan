<%@ Page 
    Language="VB" 
    MasterPageFile="~/MasterPage.master"
    AutoEventWireup="false" 
    EnableEventValidation="false"
    CodeFile="Abstract_CanvassR.aspx.vb" 
    Inherits="Bidding_Canvass"
    Title="Abstract of Canvass" 
    StylesheetTheme="SkinFile" %>

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
                        <td style="width: 98%" class="PageTitle">ABSTRACT OF QUOTATION REPORTS
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <span class="column_RightBold">Search By :</span>
                            &nbsp;<asp:DropDownList runat="server" ID="drpSearchBy" Width="150px" CssClass="drpdownCSS" AutoPostBack="true">
                                <asp:ListItem Value="1" Text="PR Number"></asp:ListItem>
                                <asp:ListItem Value="2" Text="Supplier Name"></asp:ListItem>
                            </asp:DropDownList>
                            &nbsp;<asp:Label runat="server" ID="lblSearchBy" Text="PR Number :" CssClass="column_RightBold"></asp:Label>
                            &nbsp;<asp:TextBox runat="server" ID="txtSearch" Width="200px" CssClass="txtbox_Var"></asp:TextBox>
                            &nbsp;<asp:Button runat="server" ID="btnSearch" Width="150px" CssClass="CSButton" Text="Search" />
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="DivTitle">List Of Purchase Request
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:GridView ID="gvcanvass" runat="server" Width="90%" OnSelectedIndexChanged="gvcanvass_SelectedIndexChanged" DataKeyNames="prhdr_id,Supplier_ID,Hdr_ID" AutoGenerateColumns="False" SkinID="GridViewAA" EmptyDataText="No Found Data." AllowPaging="True" OnPageIndexChanging="gvcanvass_PageIndexChanging" PageSize="20">
                                <Columns>
                                    <asp:TemplateField ShowHeader="False">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" Text="Preview" CssClass="LinkBtnPreview" CommandName="Select" Font-Underline="False" OnClick="LinkButton1_Click" Visible='<%# Bind("isVisible") %>' OnClientClick="StartProgressBar();"></asp:LinkButton>
                                        </ItemTemplate>

                                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="pr_no" HeaderText="PR Number">
                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                        <ItemStyle HorizontalAlign="Center" Width="20%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SuppName" HeaderText="Supplier Name">
                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                        <ItemStyle HorizontalAlign="Left" Width="50%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="CanvassYear" HeaderText="Canvass Year">
                                        <ItemStyle HorizontalAlign="Center" Width="20%"></ItemStyle>
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>
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
                        <td style="width: 98%" align="center"></td>
                        <td style="width: 1%"></td>
                    </tr>
                </table>
            </div>


            <asp:Panel ID="PanelProgress" runat="server" Style="border-top-width: 1px; border-left-width: 1px; border-left-color: #0033cc; border-bottom-width: 1px; border-bottom-color: #0033cc; border-top-color: #0033cc; background-color: transparent; text-align: center; border-right-width: 1px; border-right-color: #0033cc"
                Width="109px">
                <img alt="" src="../images/ajax-loader.gif" />
            </asp:Panel>
            <cc1:ModalPopupExtender ID="ProgressBarModalPopupExtender" runat="server" BackgroundCssClass="modalBackground"
                BehaviorID="ProgressBarModalPopupExtender" PopupControlID="PanelProgress" TargetControlID="ButtonProgress">
            </cc1:ModalPopupExtender>
            <asp:Button ID="ButtonProgress" runat="server" Enabled="False" Style="border-top-style: none; border-right-style: none; border-left-style: none; background-color: transparent; border-bottom-style: none"
                Width="16px" />

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>


