<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="t_initial_ppmp.aspx.vb"
    Inherits="planning_t_initial_ppmp" Title="CREATE INITIAL PPMP" StylesheetTheme="SkinFile" EnableEventValidation="false" %>

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
                        <td style="width: 98%" class="PageTitle">INITIAL - PPMP
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <table width="90%">
                                <tr>
                                    <td style="width: 20%" class="column_RightBold">Year : </td>
                                    <td style="width: 80%" class="column_Left">
                                        <asp:DropDownList ID="ddYear" runat="server" Width="150px" AutoPostBack="True" CssClass="drpdownCSS" OnSelectedIndexChanged="ddYear_SelectedIndexChanged"></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 20%" class="column_RightBold">Department : </td>
                                    <td style="width: 80%" class="column_Left">
                                        <asp:DropDownList ID="ddDepartment" runat="server" Width="70%" AutoPostBack="True" CssClass="drpdownCSS" OnSelectedIndexChanged="ddDepartment_SelectedIndexChanged"></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 20%" class="column_RightBold">Function : </td>
                                    <td style="width: 80%" class="column_Left">
                                        <asp:DropDownList ID="ddFunction" runat="server" Width="70%" AutoPostBack="True" CssClass="drpdownCSS" OnSelectedIndexChanged="ddFunction_SelectedIndexChanged"></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 20%" class="column_RightBold">PPA : </td>
                                    <td style="width: 80%" class="column_Left">
                                        <asp:DropDownList ID="ddPPA" runat="server" Width="70%" AutoPostBack="True" CssClass="drpdownCSS" OnSelectedIndexChanged="ddPPA_SelectedIndexChanged"></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 20%" class="column_RightBold">Allotment Type : </td>
                                    <td style="width: 80%" class="column_Left">
                                        <asp:DropDownList ID="ddAllotment" runat="server" Width="20%" AutoPostBack="True" CssClass="drpdownCSS" OnSelectedIndexChanged="ddAllotment_SelectedIndexChanged" Enabled="False">
                                            <asp:ListItem Selected="True" Value="1">Select</asp:ListItem>
                                            <asp:ListItem Value="2">MOOE</asp:ListItem>
                                            <asp:ListItem Value="3">CO</asp:ListItem>
                                        </asp:DropDownList>
                                        &nbsp;<asp:CheckBox ID="chkOOE" runat="server" AutoPostBack="True" Text="OOE" CssClass="rbCS_Horizontal" OnCheckedChanged="chkOOE_CheckedChanged"></asp:CheckBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 20%" class="column_RightBold">Account Title : </td>
                                    <td style="width: 80%" class="column_Left">
                                        <asp:DropDownList ID="ddAccount" runat="server" Width="70%" AutoPostBack="True" CssClass="drpdownCSS" OnSelectedIndexChanged="ddAccount_SelectedIndexChanged"></asp:DropDownList>
                                    </td>
                                </tr>
                            </table>
                            <asp:HiddenField ID="txtHiddenReceiveQty" runat="server" />
                             <asp:HiddenField ID="hdfppaprojId" runat="server"></asp:HiddenField>
                            <asp:HiddenField ID="hdfppaprogId" runat="server"></asp:HiddenField>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="DivTitle">List Of Items
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <span class="column_RightBold">Search : </span>
                            &nbsp;<asp:TextBox ID="txtSearch" runat="server" Width="300px" CssClass="txtbox_Var"></asp:TextBox>
                            &nbsp;<asp:Button ID="btnSearch" OnClick="btnSearch_Click" runat="server" Width="120px" Text="SEARCH" CssClass="CSButton"></asp:Button>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:GridView ID="grdItemList" runat="server" Width="80%" OnSelectedIndexChanged="grdItemList_SelectedIndexChanged" OnPageIndexChanging="grdItemList_PageIndexChanging" AllowPaging="True" DataKeyNames="Item_ID,Price,Item_Desc" PageSize="15" AutoGenerateColumns="False" BorderStyle="Solid" SkinID="GridViewAA" EmptyDataText="No Data Found." OnRowDataBound="grdItemList_RowDataBound">
                                <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NextPreviousFirstLast" NextPageText="Next" PreviousPageText="Previous"></PagerSettings>
                                <Columns>
                                    <asp:TemplateField>
                                         <HeaderTemplate>
                                                 <asp:CheckBox ID="CheckBox2" runat="server" Font-Bold="true" ForeColor="White" Font-Size="10pt" Font-Names="tahoma" AutoPostBack="true" Text="All" OnCheckedChanged="CheckBox2_CheckedChanged"></asp:CheckBox>
                                         </HeaderTemplate>
                                         <ItemTemplate>
                                                <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="True"  OnCheckedChanged="CheckBox1_CheckedChanged"></asp:CheckBox>
                                         </ItemTemplate>

                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Item_Desc" HeaderText="Description">
                                        <ItemStyle HorizontalAlign="Left" Width="60%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Description" HeaderText="Unit">
                                        <ItemStyle HorizontalAlign="Center" Width="20%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Price" DataFormatString="{0:N}" HeaderText="Unit Price">
                                        <ItemStyle HorizontalAlign="Right" Width="20%"></ItemStyle>
                                    </asp:BoundField>
                                </Columns>

                                <FooterStyle BackColor="#2977DC"></FooterStyle>

                                <PagerStyle HorizontalAlign="Center"></PagerStyle>

                                <HeaderStyle BackColor="#2977DC" ForeColor="White"></HeaderStyle>
                            </asp:GridView>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="DivTitle">Initial Goods
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:GridView ID="grdItems" runat="server" Width="98%" PageSize="3" AutoGenerateColumns="False" BorderStyle="Solid" SkinID="GridViewAA" EmptyDataText="No Data Found.">
                                <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NextPreviousFirstLast" NextPageText="Next" PreviousPageText="Previous"></PagerSettings>
                                <Columns>
                                    <asp:BoundField DataField="GA_Title2" HeaderText="Account Title">
                                        <ItemStyle HorizontalAlign="Left" Width="35%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Item_Desc" HeaderText="Item Description">
                                        <ItemStyle HorizontalAlign="Left" Width="35%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Unit" HeaderText="Unit">
                                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="UnitPrice" DataFormatString="{0:N}" HeaderText="Unit Price">
                                        <ItemStyle HorizontalAlign="Right" Width="10%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Qty" HeaderText="Quantity">
                                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                    </asp:BoundField>
                                </Columns>

                                <FooterStyle BackColor="#2977DC"></FooterStyle>

                                <PagerStyle HorizontalAlign="Center"></PagerStyle>

                                <HeaderStyle BackColor="#2977DC" ForeColor="White"></HeaderStyle>
                            </asp:GridView>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                             <asp:Button ID="btnSave" OnClick="btnSave_Click" runat="server" Width="150px" CssClass="CSButton" Enabled="False" Text="CREATE INITIAL PPMP" OnClientClick="StartProgressBar();"></asp:Button>
                            &nbsp;<asp:Button ID="btnCancel" OnClick="btnCancel_Click" runat="server" Width="150px" CssClass="CSButton"  Text="CANCEL"></asp:Button>
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
        
        
        
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

