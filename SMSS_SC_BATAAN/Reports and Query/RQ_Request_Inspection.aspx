<%@ Page Title="REQUEST FOR INSPECTION" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="RQ_Request_Inspection.aspx.vb"
    Inherits="Reports_and_Query_RQ_Request_Inspection" StylesheetTheme="SkinFile" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>


            <table cellspacing="1" style="width:100%">
                <tr>
                    <td width="10px"></td>
                    <td class="PageTitle" width="1000px">REQUEST FOR INSPECTION REPORT</td>
                </tr>
                <tr>
                    <td width="10px"></td>
                    <td align="center">
                        <span class="column_RightBold">Search By :</span>
                        &nbsp;<asp:DropDownList ID="ddSearchBy" runat="server" Width="150px" CssClass="drpdownCSS">
                            <asp:ListItem Value="1">PO Number</asp:ListItem>
                            <asp:ListItem Value="2">Supplier</asp:ListItem>
                        </asp:DropDownList>
                        &nbsp;<asp:TextBox ID="txtSearch" runat="server" Width="200px" CssClass="txtbox_Var"></asp:TextBox>
                        &nbsp;<asp:Button ID="btnSearch" runat="server" Text="SEARCH" Width="120px" CssClass="CSButton" OnClientClick="StartProgressBar();" />
                    </td>
                </tr>
                <tr>
                    <td width="10px"></td>
                    <td align="center" width="1000px">
                        <asp:GridView ID="grdPO" runat="server" SkinID="GridViewAA" Width="98%" AllowPaging="True" PageSize="20" DataKeyNames="POHdr_ID,AIRHdr_ID"
                            >
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkView" runat="server" CommandName="Select" CssClass="LinkBtnPreview" Font-Underline="False" OnClientClick="StartProgressBar();">View</asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="5%" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="PO_Date" DataFormatString="{0:d}" HeaderText="PO Date">
                                    <ItemStyle HorizontalAlign="Center" Width="10%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="PO_No" HeaderText="PO Number">
                                    <ItemStyle HorizontalAlign="Center" Width="10%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="SuppName" HeaderText="Supplier Name">
                                    <ItemStyle HorizontalAlign="Left" Width="30%" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Particular">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtParticular" runat="server" CssClass="txtbox_Var" Text='<%#Bind("RI_Particulars") %>' Width="98%"></asp:TextBox>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="45%" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>



            <asp:Panel Style="border-top-width: 1px; border-left-width: 1px; border-left-color: #0033cc; border-bottom-width: 1px; border-bottom-color: #0033cc; border-top-color: #0033cc; background-color: transparent; text-align: center; border-right-width: 1px; border-right-color: #0033cc" ID="PanelProgress" runat="server" Width="109px" __designer:wfdid="w21">
                <img alt="" src="../images/ajax-loader.gif" />
            </asp:Panel>
            <cc1:ModalPopupExtender ID="ProgressBarModalPopupExtender" runat="server" __designer:wfdid="w22" BackgroundCssClass="modalBackground" BehaviorID="ProgressBarModalPopupExtender" PopupControlID="PanelProgress" TargetControlID="ButtonProgress"></cc1:ModalPopupExtender>
            <asp:Button Style="border-top-style: none; border-right-style: none; border-left-style: none; background-color: transparent; border-bottom-style: none" ID="ButtonProgress" runat="server" Width="16px" __designer:wfdid="w23" Enabled="False"></asp:Button>


        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>

