<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="t_Bill_Quantities.aspx.vb"
    Inherits="bidding_Bidding_Infra_t_Bill_Quantities" Title="BILL OF QUANTITIES"
    EnableEventValidation="false" StylesheetTheme="SkinFile" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>



            <div>
                <table width="1020px">
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="PageTitle">BILL OF QUANTITIES
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="right">
                            <span class="column_RightBold">Date :</span>
                            <asp:TextBox ID="txtDate" runat="server" Width="120px" CssClass="txtbox_Date"></asp:TextBox>
                            <span class="CalendarFormat">(MM/DD/YYYY)</span>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:GridView ID="grdProjectList" runat="server" Width="100%" EmptyDataText="No Data Found." SkinID="GridViewAA"
                                AllowPaging="True" PageSize="10" OnSelectedIndexChanged="grdProjectList_SelectedIndexChanged" AutoGenerateColumns="False" 
                                DataKeyNames="OBR_Hdr_ID,Program_ID,Project_ID,TotalAmount" >
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkSelect" runat="server" CssClass="LinkBtnSelect" Font-Underline="false" CommandName="Select" Visible='<%# BIND ("isVisible") %>'>Select</asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="OBR_No" HeaderText="OBR Number">
                                        <ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="OBR_Title" HeaderText="OBR Title">
                                        <ItemStyle HorizontalAlign="Left" Width="35%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="PPA" HeaderText="Project Name">
                                        <ItemStyle HorizontalAlign="Left" Width="35%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="TotalAmount" DataFormatString="{0:N}" HeaderText="Approved Budget">
                                        <ItemStyle HorizontalAlign="Right" Width="10%"></ItemStyle>
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
                        <td style="width: 98%;height:5px">
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="DivTitle">Information / Details
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:GridView ID="grdItems" runat="server" Width="90%" EmptyDataText="No Data Found." SkinID="GridViewAA" OnSelectedIndexChanged="grdItems_SelectedIndexChanged" AutoGenerateColumns="False" DataKeyNames="Description,Unit,Quantity,Infra_Dtl_ID">
                                <Columns>
                                    <asp:TemplateField HeaderText="Update">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkUpdate" runat="server" CssClass="LinkBtnSelect" Font-Underline="False" CommandName="Select">Update</asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="8%"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Part No.">
                                        <ItemTemplate>
                                            <asp:Label ID="lblNo" runat="server" Text='<%# Bind("ID") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="7%"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Description" HeaderText="Description">
                                        <ItemStyle HorizontalAlign="Left" Width="55%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Unit" HeaderText="Unit">
                                        <ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Quantity" HeaderText="Quantity">
                                        <ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
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
                        <td style="width: 98%" align="center">
                            <table width="50%">
                                <tr>
                                    <td style="width: 28%" class="column_LeftBold">Description</td>
                                    <td style="width: 2%" class="column_LeftBold">:</td>
                                    <td style="width: 70%" class="column_Left">
                                        <asp:TextBox ID="txtDescription" runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td style="width: 28%" class="column_LeftBold">Unit</td>
                                    <td style="width: 2%" class="column_LeftBold">:</td>
                                    <td style="width: 70%" class="column_Left">
                                        <asp:TextBox ID="txtUnit" runat="server" Width="40%" CssClass="txtbox_Var"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td style="width: 28%" class="column_LeftBold">Quantity</td>
                                    <td style="width: 2%" class="column_LeftBold">:</td>
                                    <td style="width: 70%" class="column_Left">
                                        <asp:TextBox ID="txtQty" runat="server" Width="40%" CssClass="txtbox_Var"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td style="width: 28%" class="column_LeftBold">BAC Chairman</td>
                                    <td style="width: 2%" class="column_LeftBold">:</td>
                                    <td style="width: 70%" class="column_Left">
                                        <asp:DropDownList ID="ddBACChairman" runat="server" Width="90%" AutoPostBack="True" CssClass="drpdownCSS"></asp:DropDownList></td>
                                </tr>
                            </table>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:Button ID="btnAdd" OnClick="btnAdd_Click" runat="server" Width="150px" CssClass="CSButton" Enabled="False" Text="ADD ITEM" OnClientClick="StartProgressBar();"></asp:Button>
                            &nbsp;<asp:Button ID="btnSave" OnClick="btnSave_Click" runat="server" Width="150px" CssClass="CSButton" Enabled="False" Text="SUBMIT" OnClientClick="StartProgressBar();"></asp:Button>
                            &nbsp;<asp:Button ID="btnPreview" OnClick="btnPreview_Click" runat="server" Width="150px" CssClass="CSButton" Enabled="False" Text="PREVIEW BOQ"></asp:Button>
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
                <img alt="" src="../../images/ajax-loader.gif" />
            </asp:Panel>
            <cc1:ModalPopupExtender ID="ProgressBarModalPopupExtender" runat="server" TargetControlID="ButtonProgress" PopupControlID="PanelProgress" BehaviorID="ProgressBarModalPopupExtender" BackgroundCssClass="modalBackground"></cc1:ModalPopupExtender>
            <asp:Button Style="border-top-style: none; border-right-style: none; border-left-style: none; background-color: transparent; border-bottom-style: none" ID="ButtonProgress" runat="server" Width="16px" Enabled="False"></asp:Button>&nbsp;&nbsp;&nbsp; 
        
        
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>



<%-- FIRST VERSION OF BILL OF QUANTITIES PAGE --%>

<%--<div>
    <table width="1020px">
        <tr>
            <td style="width: 1%"></td>
            <td style="width: 98%" class="PageTitle">BILL OF QUANTITIES
            </td>
            <td style="width: 1%"></td>
        </tr>
        <tr>
            <td style="width: 1%"></td>
            <td style="width: 98%" align="right">
                <span class="column_RightBold">Date :</span>
                <asp:TextBox ID="TextBox1" runat="server" Width="120px" CssClass="txtbox_Date"></asp:TextBox>
                <span class="CalendarFormat">(MM/DD/YYYY)</span>
            </td>
            <td style="width: 1%"></td>
        </tr>
        <tr>
            <td style="width: 1%"></td>
            <td style="width: 98%" align="center">
                <asp:GridView ID="GridView1" runat="server" Width="90%" EmptyDataText="No Data Found." SkinID="GridViewAA"
                    AllowPaging="True" OnSelectedIndexChanged="grdProjectList_SelectedIndexChanged" AutoGenerateColumns="False" PageSize="8"
                    DataKeyNames="prhdr_id,pre_procurement_hdr_id">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkSelect" runat="server" CssClass="LinkBtnSelect" Font-Underline="false" CommandName="Select" Visible='<%# BIND ("isVisible") %>'>Select</asp:LinkButton>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                        </asp:TemplateField>
                        <asp:BoundField DataField="pr_no" HeaderText="PR Number">
                            <ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="project_name" HeaderText="Project Name">
                            <ItemStyle HorizontalAlign="Left" Width="65%"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="ABC" DataFormatString="{0:N}" HeaderText="ABC">
                            <ItemStyle HorizontalAlign="Right" Width="15%"></ItemStyle>
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
            <td style="width: 98%" class="DivTitle">Information / Details
            </td>
            <td style="width: 1%"></td>
        </tr>
        <tr>
            <td style="width: 1%"></td>
            <td style="width: 98%" align="center">
                <asp:GridView ID="GridView2" runat="server" Width="90%" EmptyDataText="No Data Found." SkinID="GridViewAA" OnSelectedIndexChanged="grdItems_SelectedIndexChanged" AutoGenerateColumns="False" DataKeyNames="Description,Unit,Quantity,Infra_Dtl_ID">
                    <Columns>
                        <asp:TemplateField HeaderText="Update">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkUpdate" runat="server" CssClass="LinkBtnSelect" Font-Underline="False" CommandName="Select">Update</asp:LinkButton>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="8%"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Part No.">
                            <ItemTemplate>
                                <asp:Label ID="lblNo" runat="server" Text='<%# Bind("ID") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="7%"></ItemStyle>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Description" HeaderText="Description">
                            <ItemStyle HorizontalAlign="Left" Width="55%"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="Unit" HeaderText="Unit">
                            <ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="Quantity" HeaderText="Quantity">
                            <ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
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
            <td style="width: 98%" align="center">
                <table width="50%">
                    <tr>
                        <td style="width: 28%" class="column_LeftBold">Description</td>
                        <td style="width: 2%" class="column_LeftBold">:</td>
                        <td style="width: 70%" class="column_Left">
                            <asp:TextBox ID="TextBox2" runat="server" Width="90%" CssClass="txtbox_Var"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="width: 28%" class="column_LeftBold">Unit</td>
                        <td style="width: 2%" class="column_LeftBold">:</td>
                        <td style="width: 70%" class="column_Left">
                            <asp:TextBox ID="TextBox3" runat="server" Width="40%" CssClass="txtbox_Var"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="width: 28%" class="column_LeftBold">Quantity</td>
                        <td style="width: 2%" class="column_LeftBold">:</td>
                        <td style="width: 70%" class="column_Left">
                            <asp:TextBox ID="TextBox4" runat="server" Width="40%" CssClass="txtbox_Var"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="width: 28%" class="column_LeftBold">BAC Chairman</td>
                        <td style="width: 2%" class="column_LeftBold">:</td>
                        <td style="width: 70%" class="column_Left">
                            <asp:DropDownList ID="DropDownList1" runat="server" Width="90%" AutoPostBack="True" CssClass="drpdownCSS"></asp:DropDownList></td>
                    </tr>
                </table>
            </td>
            <td style="width: 1%"></td>
        </tr>
        <tr>
            <td style="width: 1%"></td>
            <td style="width: 98%" align="center">
                <asp:Button ID="Button1" OnClick="btnAdd_Click" runat="server" Width="150px" CssClass="CSButton" Enabled="False" Text="ADD ITEM" OnClientClick="StartProgressBar();"></asp:Button>
                &nbsp;<asp:Button ID="Button2" OnClick="btnSave_Click" runat="server" Width="150px" CssClass="CSButton" Enabled="False" Text="SUBMIT" OnClientClick="StartProgressBar();"></asp:Button>
                &nbsp;<asp:Button ID="Button3" OnClick="btnPreview_Click" runat="server" Width="150px" CssClass="CSButton" Enabled="False" Text="PREVIEW BOQ"></asp:Button>
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
</div>--%>
