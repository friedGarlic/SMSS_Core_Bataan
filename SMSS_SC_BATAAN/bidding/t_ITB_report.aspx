<%@ 
    Page Language="VB"
    MasterPageFile="~/MasterPage.master"
    AutoEventWireup="false" 
    CodeFile="t_ITB_report.aspx.vb" 
    Inherits="bidding_t_ITB_report"
    EnableEventValidation="false"
    StylesheetTheme="SkinFile"
%>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <div>
                <table width="100%">
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="PageTitle">INVITATION TO BID REPORTS
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
                            <span class="column_RightBold">Search By :</span>&nbsp;
                            <asp:DropDownList runat="server" ID="drpSearch" Width="150px">
                                <asp:ListItem Value="1" Text="ITN Number"></asp:ListItem>
                                <asp:ListItem Value="2" Text="Project Name"></asp:ListItem>
                            </asp:DropDownList>&nbsp;
                            <asp:TextBox runat="server" ID="txtSearch" Width="200px" CssClass="txtbox_Var"></asp:TextBox>
                            <asp:Button runat="server" ID="btnSearch" CssClass="CSButton" Width="150px" Text="SEARCH"/>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%; height: 10px"></td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:GridView runat="server" ID="grdITB" SkinID="GridViewAA" Width="90%" EmptyDataText="No Data Found." DataKeyNames="ITB_No, Project_name, ITB_Hdr_ID, ABC, withPreBidConference">
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton runat="server" Text="Preview" Font-Underline="false" CssClass="LinkBtnPreview" CommandName="Select" OnClientClick="StartProgressBar();"></asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle Width="7%" />
                                    </asp:TemplateField>
                                    <asp:BoundField ItemStyle-Width="13%" DataField="ITB_No" HeaderText="ITB Number" ItemStyle-HorizontalAlign="Center" />
                                                                    <asp:BoundField ItemStyle-Width="65%" DataField="Project_name" HeaderText="Contract / Project Name" ItemStyle-HorizontalAlign="Left" />
                                                                    <asp:BoundField ItemStyle-Width="15%" DataField="ABC" DataFormatString="{0:N}" HeaderText="ABC" ItemStyle-HorizontalAlign="Right" />
                                </Columns>
                                <FooterStyle BackColor="#2977DC" />
                                <HeaderStyle BackColor="#2977DC" ForeColor="White" />
                            </asp:GridView>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                </table>
            </div>

            <asp:Panel Style="border-top-width: 1px; border-left-width: 1px; border-left-color: #0033cc; border-bottom-width: 1px; border-bottom-color: #0033cc; border-top-color: #0033cc; background-color: transparent; text-align: center; border-right-width: 1px; border-right-color: #0033cc" ID="PanelProgress" runat="server" Width="109px">
                <img alt="" src="../images/ajax-loader.gif" />
            </asp:Panel>
            <cc1:ModalPopupExtender ID="ProgressBarModalPopupExtender" runat="server" TargetControlID="ButtonProgress" BehaviorID="ProgressBarModalPopupExtender" BackgroundCssClass="modalBackground" PopupControlID="PanelProgress"></cc1:ModalPopupExtender>
            <asp:Button Style="border-top-style: none; border-right-style: none; border-left-style: none; background-color: transparent; border-bottom-style: none" ID="ButtonProgress" runat="server" Width="16px" Enabled="False"></asp:Button>

        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>

