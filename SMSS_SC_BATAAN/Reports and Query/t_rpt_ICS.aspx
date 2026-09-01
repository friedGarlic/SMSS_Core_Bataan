<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="t_rpt_ICS.aspx.vb"
    Inherits="Reports_and_Query_t_rpt_ICS" Title="Inventory of Custodian Slip" EnableEventValidation="false" StylesheetTheme="SkinFile" %>


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
                        <td style="width: 98%" class="PageTitle">INVENTORY CUSTODIAN SLIP
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <table width="100%">
                                <tr>
                                    <td style="width: 20%" class="column_RightBold">Search By :
                                    </td>
                                    <td style="width: 20%" class="text5" valign="top">
                                        <asp:RadioButtonList ID="rdSearchCriteria" runat="server" Width="100%" CssClass="rbCS_Vertical" AutoPostBack="True">
                                            <asp:ListItem Selected="True" Value="1">ICS Number</asp:ListItem>
                                            <asp:ListItem Value="2">RIS Number</asp:ListItem>
                                            <asp:ListItem Value="3">Date Duration</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                    <td style="width: 60%" class="text5" valign="top">
                                        <asp:MultiView runat="server" ID="mvSearch">
                                            <asp:View runat="server" ID="vwICSNo">
                                                <table width="100%">
                                                    <tr>
                                                        <td style="width: 10%" class="column_LeftBold">ICS No. :</td>
                                                        <td style="width: 35%" class="text5">
                                                            <asp:TextBox runat="server" ID="txtICSNo" CssClass="txtbox_Var" Width="95%"></asp:TextBox>
                                                        </td>
                                                        <td style="width: 55%" class="text5">
                                                            <asp:Button runat="server" ID="btnSearchICS" Text="SEARCH" CssClass="CSButton" Width="100px" Font-Bold="true" Font-Size="9pt" OnClientClick="StartProgressBar();" ForeColor="#0033cc"></asp:Button>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:View>
                                            <asp:View runat="server" ID="vwRISNo">
                                                <table width="100%">
                                                    <tr>
                                                        <td style="width: 10%" class="column_LeftBold">RIS No. :</td>
                                                        <td style="width: 35%" class="text5">
                                                            <asp:TextBox runat="server" ID="txtRISNo" Width="95%" CssClass="txtbox_Var"></asp:TextBox>
                                                        </td>
                                                        <td style="width: 55%" class="text5">
                                                            <asp:Button runat="server" ID="btnSearchRIS" Text="SEARCH" CssClass="CSButton" Width="100px" Font-Bold="true" Font-Size="9pt" OnClientClick="StartProgressBar();" ForeColor="#0033cc"></asp:Button>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:View>
                                            <asp:View runat="server" ID="vwDate">
                                                <table width="100%">
                                                    <tr>
                                                        <td style="width: 20%" class="column_RightBold">Date From :</td>
                                                        <td style="width: 20%" class="text5">
                                                            <asp:TextBox runat="server" ID="txtDateFrom" Width="100px" CssClass="txtbox_Date"></asp:TextBox>
                                                        </td>
                                                        <td style="width: 60%" class="text5">
                                                            <asp:Button runat="server" ID="btnSearchDate" Text="SEARCH" CssClass="CSButton" Width="100px" Font-Bold="true" Font-Size="9pt" OnClientClick="StartProgressBar();" ForeColor="#0033cc"></asp:Button>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 20%" class="column_RightBold">Date To :</td>
                                                        <td style="width: 20%" class="text5">
                                                            <asp:TextBox runat="server" ID="txtDateTo" Width="100px" CssClass="txtbox_Date"></asp:TextBox>
                                                        </td>
                                                        <td style="width: 60%" class="text5"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 20%" class="column_RightBold"></td>
                                                        <td style="width: 20%" class="text5"></td>
                                                        <td style="width: 60%" class="text5"></td>
                                                    </tr>
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
                        <td style="width: 98%" class="DivTitle">Inventory Custodian Slip
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:GridView ID="grdICS" runat="server" Width="98%" SkinID="GridViewAA" DataKeyNames="ICSHdr_ID"
                                AllowPaging="True" EmptyDataText="No Data Found.">
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton runat="server" ID="lnkSelect" CssClass="LinkBtnPreview" CommandName="Select" Font-Underline="false" Text="Preview" OnClientClick="StartProgressBar();"></asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="RIS_No" HeaderText="RIS NUMBER">
                                        <ItemStyle HorizontalAlign="Center" Width="20%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ICS_No" HeaderText="ICS NUMBER">
                                        <ItemStyle HorizontalAlign="Center" Width="20%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Date_Acquired" HeaderText="ICS DATE" DataFormatString="{0:d}">
                                        <ItemStyle HorizontalAlign="Center" Width="20%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="IssuedTo" HeaderText="ISSUED TO">
                                        <ItemStyle HorizontalAlign="Left" Width="30%"></ItemStyle>
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>
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
            <cc1:ModalPopupExtender ID="ProgressBarModalPopupExtender" runat="server" TargetControlID="ButtonProgress" BehaviorID="ProgressBarModalPopupExtender" BackgroundCssClass="modalBackground" PopupControlID="PanelProgress"></cc1:ModalPopupExtender>
            <asp:Button Style="border-top-style: none; border-right-style: none; border-left-style: none; background-color: transparent; border-bottom-style: none" ID="ButtonProgress" runat="server" Width="16px" Enabled="False"></asp:Button>


        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

