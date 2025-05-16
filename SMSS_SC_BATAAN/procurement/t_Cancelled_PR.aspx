<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="t_Cancelled_PR.aspx.vb"
    Inherits="procurement_t_Cancelled_PR" Title="CANCELLED PURCHASED REQUEST" EnableEventValidation="false" StylesheetTheme="SkinFile" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table style="width: 100%">
                <tbody>
                    <tr>
                        <td align="center" style="width: 10px"></td>
                        <td style="width: 1000px" class="PageTitle" align="center">LIST OF CANCELLED PURCHASE REQUEST</td>
                    </tr>
                    <tr>
                        <td align="center" style="width: 10px"></td>
                        <td style="width: 1000px" align="center">
                            <span class="column_RightBold">Search By :</span>
                            &nbsp;<asp:DropDownList ID="ddSearch" runat="server" Width="200px" CssClass="drpdownCSS">
                                <asp:ListItem Selected="True" Value="1">PR Number</asp:ListItem>
                                <asp:ListItem Value="2">Office Name</asp:ListItem>
                            </asp:DropDownList>                            
                            &nbsp;<asp:TextBox ID="txtSearch" runat="server" Width="200px" CssClass="txtbox_Var"></asp:TextBox>
                            &nbsp;<asp:Button ID="btnSearch" runat="server" Width="150px" Text="SEARCH" CssClass="CSButton" OnClick="btnSearch_Click"></asp:Button></td>
                    </tr>
                    <tr>
                        <td align="center" style="width: 10px"></td>
                        <td style="width: 1000px" align="center">
                            <asp:GridView  ID="grdPurchaseRequest" runat="server" Width="98%" OnPageIndexChanging="grdPurchaseRequest_PageIndexChanging" 
                                SkinID="GridViewAA" AllowPaging="True" AutoGenerateColumns="False" PageSize="15" DataKeyNames="prhdr_id" 
                                OnSelectedIndexChanged="grdPurchaseRequest_SelectedIndexChanged" EmptyDataText="No Data Found.">
                                <Columns>
                                    <asp:BoundField DataField="pr_no" HeaderText="PR Number">
                                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Date_Submitted" DataFormatString="{0:d}" HeaderText="PR Date">
                                        <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ABC" DataFormatString="{0:N}" HeaderText="ABC">
                                        <ItemStyle HorizontalAlign="Right" Width="5%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="RC_Name" HeaderText="Department">
                                        <ItemStyle HorizontalAlign="Left" Width="35%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="remarks" HeaderText="Purpose">
                                        <ItemStyle HorizontalAlign="Left" Width="20%"></ItemStyle>
                                    </asp:BoundField>
                                      <asp:BoundField DataField="ReasonForCancellation" HeaderText="Reason For Cancellation">
                                        <ItemStyle HorizontalAlign="left" Width="20%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkView" runat="server" CssClass="LinkBtnPreview" Visible='<%# bind("IsVisible") %>' CommandName="Select" Font-Overline="False">View</asp:LinkButton>
                                        </ItemTemplate>

                                        <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                    </asp:TemplateField>
                                </Columns>

                                <FooterStyle BackColor="#2977DC"></FooterStyle>
                                <HeaderStyle BackColor="#2977DC" ForeColor="White"></HeaderStyle>
                            </asp:GridView>
                        </td>
                    </tr>
                </tbody>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

