<%@ 
    Page Language="VB"
    MasterPageFile="~/MasterPage.master"
    AutoEventWireup="false" 
    CodeFile="t_fund.aspx.vb" 
    Inherits="filemaintenance_t_fund"
    Title="FM - Fund"
    StylesheetTheme="SkinFile" 
    EnableEventValidation="false"
%>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <div>
                <table width="1020px">
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="PageTitle">FUND</td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <table width="90%">
                                <tbody>
                                    <tr>
                                        <td class="column_RightBold" style="width: 15%">Fund Description :</td>
                                        <td class="column_Left" colspan="3">
                                            <asp:TextBox ID="txtFund" runat="server" Width="500px" Height="20px" CssClass="txtbox_Var"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 1%"></td>
                                        <td style="width: 98%; height: 10px"></td>
                                        <td style="width: 1%"></td>
                                    </tr>
                                    <tr>
                                        <td class="column_RightBold" style="width: 15%">Fund Code :</td>
                                        <td class="column_Left" colspan="3">
                                            <asp:TextBox ID="txtFund_Code" runat="server" Width="250px" Height="20px" CssClass="txtbox_Var"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 1%"></td>
                                        <td style="width: 98%; height: 10px"></td>
                                        <td style="width: 1%"></td>
                                    </tr>
                                    <tr>
                                        <td class="column_RightBold" style="width: 30%">Do you want to be this fund active</td>
                                        <td class="column_Left" style="width: 70%">
                                            <asp:DropDownList ID="ddActive" runat="server" Width="15%" CssClass="drpdownCSS" AutoPostBack="true">
                                                <asp:ListItem Value="1">YES</asp:ListItem>
                                                <asp:ListItem Value="2">NO</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
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
                        <td style="width: 98%;" align="center">
                            <asp:Button ID="btnSave" OnClick="btnSave_Click" runat="server" CssClass="CSButton" Width="150px" OnClientClick="StartProgressBar();" Text="SAVE FUND"></asp:Button>&nbsp;
                            <asp:Button ID="btnCancel" runat="server" CssClass="CSButton" Width="150px" Text="CANCEL" OnClick="btnCancel_Click"></asp:Button>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="DivTitle">List Of Funds</td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:GridView ID="grdFunds" runat="server" Width="95%" DataKeyNames="F_ID, Description, Fund_Code" PageSize="20" AutoGenerateColumns="false" OnSelectedIndexChanged="grdFunds_SelectedIndexChanged" EmptyDataText="No Data Found." SkinID="GridViewAA" AllowPaging="true" Font-Size="8pt" OnPageIndexChanging="grdFunds_PageIndexChanging">
                                <PagerSettings NextPageText="Next" PreviousPageText="Previous" />
                                <Columns>
                                    <asp:TemplateField>
                                        <EditItemTemplate>
                                            <asp:TextBox runat="server" ID="TextBox1"></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Select" CssClass="LinkBtnSelect" Font-Underline="false" OnClick="LinkButton1_Click" Text="Update"></asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Fund_Code" HeaderText="Fund Code">
                                        <ItemStyle HorizontalAlign="Center" Width="15%"/>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Description" HeaderText="The Name of the Fund">
                                        <ItemStyle HorizontalAlign="Center" Width="70%" />
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
                </table>
            </div>

            <asp:Panel Style="border-top-width: 1px; border-left-width: 1px; border-left-color: #0033cc; border-bottom-width: 1px; border-bottom-color: #0033cc; border-top-color: #0033cc; position: relative; background-color: transparent; text-align: center; border-right-width: 1px; border-right-color: #0033cc" ID="PanelProgress" runat="server" Width="109px">
                <img alt="" src="../images/ajax-loader.gif" />
            </asp:Panel>
            <cc1:ModalPopupExtender ID="ProgressBarModalPopupExtender" runat="server" TargetControlID="ButtonProgress" BackgroundCssClass="modalBackground" PopupControlID="PanelProgress" BehaviorID="ProgressBarModalPopupExtender"></cc1:ModalPopupExtender>
            <asp:Button Style="border-top-style: none; border-right-style: none; border-left-style: none; position: relative; background-color: transparent; border-bottom-style: none" ID="ButtonProgress" runat="server" Width="16px" Enabled="False"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>


