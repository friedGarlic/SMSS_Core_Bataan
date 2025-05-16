<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="t_PO_Approval.aspx.vb"
    Inherits="procurement_t_PO_Approval" Title="Purchase Order Approval" StylesheetTheme="SkinFile" %>

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
                        <td style="width: 98%" class="PageTitle">APPROVAL OF PURCHASE ORDER
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="right">
                            <span class="column_RightBold">Date : </span>
                            <asp:TextBox ID="txtDate" runat="server" Width="100px" CssClass="txtbox_Date" ReadOnly="True"></asp:TextBox>
                            &nbsp;<asp:ImageButton ID="ImageButton1" runat="server" Height="15px" ImageUrl="~/images/calendar1.jpg" Width="20px" />
                            <span class="CalendarFormat">(MM/DD/YYYY)</span>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <table width="100%">
                                <tr>
                                    <td style="width:40%" align="right">
                                        <span class="column_RightBold">Search By :</span>
                                        <asp:DropDownList ID="ddSearchPR" runat="server" Width="30%" CssClass="drpdownCSS" AutoPostBack="True" OnSelectedIndexChanged="ddSearchPR_SelectedIndexChanged">
                                                <asp:ListItem Value="1">PR Number</asp:ListItem>
                                                <asp:ListItem Value="2">Department</asp:ListItem>
                                                <asp:ListItem Value="3">Supplier</asp:ListItem>
                                                <asp:ListItem  Selected="True" Value="4">PO Number</asp:ListItem>    
                                            </asp:DropDownList>
                                    </td>
                                    <td style="width:60%" align="left">
                                        <asp:MultiView ID="MultiView1" runat="server">
                                                <asp:View ID="View1" runat="server">
                                                    <table style="width: 100%">
                                                        <tr>
                                                            <td class="column_LeftBold" style="width: 100%">
                                                                <span class="column_RightBold">PR Number : </span>
                                                                <asp:TextBox ID="txtPRNo" runat="server" Width="200px" CssClass="txtbox_Var"></asp:TextBox>
                                                                <asp:Button ID="btnSearchPRNumb" OnClick="btnSearchPRNumb_Click" runat="server" CssClass="CSButton" Width="150px" OnClientClick="StartProgressBar();" Text="SEARCH"></asp:Button></td>
                                                        </tr>
                                                    </table>
                                                </asp:View>
                                                <asp:View ID="View2" runat="server">
                                                    <table style="width: 100%">
                                                        <tr>
                                                            <td class="column_LeftBold" style="width: 100%">
                                                                <span class="column_RightBold">Department : </span>
                                                                <asp:DropDownList ID="ddDept" runat="server" CssClass="drpdownCSS" Width="300px" AutoPostBack="True">
                                                                </asp:DropDownList>
                                                                <asp:Button ID="btnSearchDept" OnClick="btnSearchDept_Click" runat="server" CssClass="CSButton" Width="150px" OnClientClick="StartProgressBar();" Text="SEARCH"></asp:Button></td>
                                                        </tr>
                                                    </table>
                                                </asp:View>
                                                <asp:View ID="View3" runat="server">
                                                    <table style="width: 100%">
                                                        <tr>
                                                            <td class="column_LeftBold" style="width: 100%">
                                                                <span class="column_RightBold">Supplier : </span>
                                                                <asp:DropDownList ID="ddSupplier" runat="server" CssClass="drpdownCSS" Width="300px" AutoPostBack="True"></asp:DropDownList>
                                                                <asp:Button ID="btnSearchSupp" OnClick="btnSearchSupp_Click" runat="server" CssClass="CSButton" Width="150px" Text="SEARCH" OnClientClick="StartProgressBar();"></asp:Button></td>
                                                        </tr>
                                                    </table>
                                                </asp:View>

                                            <asp:View ID="View4" runat="server">
                                                    <table style="width: 100%">
                                                        <tr>
                                                            <td class="column_LeftBold" style="width: 100%">
                                                                <span class="column_RightBold">PO Number : </span>
                                                                <asp:TextBox ID="txtPONo" runat="server" Width="200px" CssClass="txtbox_Var"></asp:TextBox>
                                                                <asp:Button ID="btnSearchPONumb" OnClick="btnSearchPONumb_Click" runat="server" CssClass="CSButton" Width="150px" OnClientClick="StartProgressBar();" Text="SEARCH"></asp:Button></td>
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
                        <td style="width: 98%" class="DivTitle">
                            &nbsp; List of Purchase Order
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:GridView ID="grdPOApproval" runat="server" Width="98%" OnSelectedIndexChanged="grdPOApproval_SelectedIndexChanged" 
                                AllowPaging="True" OnPageIndexChanging="grdPOApproval_PageIndexChanging" SkinID="GridViewAA" AutoGenerateColumns="False" 
                                DataKeyNames="POHdr_ID,pre_procurement_hdr_id,Supplier_Id,pr_no, po_no">
                                <Columns>
                                    <asp:TemplateField>
                                        <EditItemTemplate>
                                            <asp:TextBox runat="server" ID="TextBox1"></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkSelect" runat="server" Visible='<%#Bind("isVisible") %>' CommandName="Select" CssClass="LinkBtnSelect" Font-Underline="False">Select</asp:LinkButton>
                                        </ItemTemplate>

                                        <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="pr_no" HeaderText="PR Number">
                                        <ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
                                    </asp:BoundField>

                                    <asp:BoundField DataField="po_no" HeaderText="PO Number">
                                        <ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
                                    </asp:BoundField>

                                    <asp:BoundField DataField="SuppName" HeaderText="Supplier">
                                        <ItemStyle HorizontalAlign="Left" Width="35%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ContractPrice" DataFormatString="{0:N}" HeaderText="PO Amount">
                                        <ItemStyle HorizontalAlign="Right" Width="10%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="RCName" HeaderText="Requesting Department">
                                        <ItemStyle HorizontalAlign="Left" Width="35%"></ItemStyle>
                                    </asp:BoundField>
                                </Columns>

                                <FooterStyle BackColor="#2977DC"></FooterStyle>

                                <HeaderStyle BackColor="#2977DC" ForeColor="White"></HeaderStyle>
                            </asp:GridView>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="DivTitle">
                            &nbsp; List of Goods
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:Panel ID="Panel1" runat="server" Width="98%" CssClass="PanelSize" ScrollBars="Vertical">
                                <asp:GridView ID="grdItemList" runat="server" Width="100%" SkinID="GridViewAA" 
                                    AutoGenerateColumns="False">
                                    <Columns>
                                        <asp:BoundField DataField="Item_Desc" HeaderText="Item Description" HtmlEncode="false">
                                            <ItemStyle HorizontalAlign="Left" Width="50%"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Unit" HeaderText="Unit">
                                            <ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="qty" HeaderText="Quantity">
                                            <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="cost" DataFormatString="{0:N}" HeaderText="Unit Price">
                                            <ItemStyle HorizontalAlign="Right" Width="10%"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="TotalAmount" DataFormatString="{0:N}" HeaderText="Total Amount">
                                            <ItemStyle HorizontalAlign="Right" Width="15%"></ItemStyle>
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
                        <td style="width: 98%" align="center">
                             <asp:Button ID="btnApproved" OnClick="btnApproved_Click" runat="server" CssClass="CSButton" Width="150px"  OnClientClick="StartProgressBar();" Enabled="False" Text="APPROVE"></asp:Button>
                            <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" TargetControlID="btnApproved" ConfirmText="Are you sure you want to Approve this PO?"></cc1:ConfirmButtonExtender>
                            &nbsp;<asp:Button ID="btnCancel" OnClick="btnCancel_Click" runat="server" CssClass="CSButton" Width="150px" OnClientClick="StartProgressBar();" Enabled="false" Text="RETURN P.O."></asp:Button>
                            <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender5" runat="server" TargetControlID="btnCancel" ConfirmText="Are you sure you want to return this PO?"></cc1:ConfirmButtonExtender>
                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" PopupButtonID="ImageButton1" TargetControlID="txtDate">
                            </cc1:CalendarExtender>
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
            <cc1:ModalPopupExtender ID="ProgressBarModalPopupExtender" runat="server" TargetControlID="ButtonProgress" BackgroundCssClass="modalBackground" BehaviorID="ProgressBarModalPopupExtender" PopupControlID="PanelProgress"></cc1:ModalPopupExtender>
            <asp:Button Style="border-top-style: none; border-right-style: none; border-left-style: none; background-color: transparent; border-bottom-style: none" ID="ButtonProgress" runat="server" Width="16px" Enabled="False"></asp:Button> 
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

