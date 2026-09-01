<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="t_ppmpList.aspx.vb"
    Inherits="planning_t_ppmpList" Title="PPMP List" StylesheetTheme="SkinFile" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<script runat="server">


</script>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table style="width: 100%">
                <tr>
                    <td style="width: 10px"></td>
                    <td align="center" class="PageTitle" style="width: 1000px">LIST OF SUBMITTED PPMP</td>
                </tr>
                <tr>
                    <td style="width: 10px"></td>
                    <td align="center" style="width: 1000px">
                        <table style="width: 80%">
                            <tr>
                                <td class="column_RightBold" style="width: 20%">APP YEAR :
                                </td>
                                <td class="text5" style="width: 80%">
                                    <asp:DropDownList ID="ddYear" runat="server" Width="150px" OnSelectedIndexChanged="ddYear_SelectedIndexChanged" AutoPostBack="True" CssClass="txtboxinspection"></asp:DropDownList></td>
                            </tr>
                            <tr>
                                <td class="column_RightBold" style="width: 20%">SEARCH BY :
                                </td>
                                <td class="text5" style="width: 80%">
                                    <asp:DropDownList ID="ddCategory" runat="server" Width="350px" OnSelectedIndexChanged="ddCategory_SelectedIndexChanged" AutoPostBack="True" CssClass="txtboxinspection">
                                        <asp:ListItem Selected="True">Select</asp:ListItem>
                                        <asp:ListItem Value="1">With PPMP</asp:ListItem>
                                        <asp:ListItem Value="0">Without PPMP</asp:ListItem>
                                    </asp:DropDownList><asp:Label ID="lblCount" runat="server" ForeColor="Red" Font-Size="10pt" Font-Names="Calibri" CssClass="txtboxinspection" Visible="False" Font-Italic="True" Height="18px"></asp:Label></td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td style="width: 10px"></td>
                    <td align="center" style="width: 1000px">
                        <table style="width: 100%">
                            <tr>
                                <td align="center" class="DivTitle" style="width: 50%">List Of Departments</td>
                                <td align="center" class="DivTitle" style="width: 50%">List Of PPMP Accounts</td>
                            </tr>
                            <tr>
                                <td align="center" style="vertical-align: top; width: 50%">
                                    <asp:GridView  ID="grdDept" runat="server" Width="100%" BorderStyle="Solid" DataKeyNames="RC_ID,Function_ID" 
                                        AutoGenerateColumns="False" PageSize="20" SkinID="GridViewAA" AllowPaging="True" OnPageIndexChanging="grdDept_PageIndexChanging" 
                                        OnSelectedIndexChanged="grdDept_SelectedIndexChanged" ShowHeader="False" EmptyDataText="No Data Found." >
                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="linkSelect" OnClick="linkSelect_Click" runat="server" CommandName="Select" Font-Underline="False" CssClass="LinkBtnSelect" Text="Select"></asp:LinkButton>
                                                </ItemTemplate>
                                                                                                <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="List of Department ">
                                                <EditItemTemplate>
                                                    <asp:TextBox runat="server" Text='<%# Bind("RespCenter") %>' ID="TextBox1"></asp:TextBox>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("DepartmentName") %>'></asp:Label>
                                                </ItemTemplate>

                                                <ItemStyle HorizontalAlign="Left" Width="90%"></ItemStyle>
                                            </asp:TemplateField>
                                        </Columns>

                                        <FooterStyle BackColor="#2977DC"></FooterStyle>

                                        <HeaderStyle BackColor="#2977DC" ForeColor="White"></HeaderStyle>
                                    </asp:GridView>
                                </td>
                                <td align="center" style="vertical-align: top; width: 50%">
                                    <asp:GridView ID="grdAccounts" runat="server" Width="100%" BorderStyle="Solid" DataKeyNames="GA_ID,BGA_ID,Project_ID,Program_id,RC_ID,CYear,Function_ID" 
                                        AutoGenerateColumns="False" PageSize="20" SkinID="GridViewAA" AllowPaging="True" OnPageIndexChanging="grdAccounts_PageIndexChanging" 
                                        OnSelectedIndexChanged="grdAccounts_SelectedIndexChanged" ShowHeader="False" EmptyDataText="No Data Found." >
                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Select" Font-Underline="False" CssClass="LinkBtnPreview" Text="Preview"></asp:LinkButton>
                                                </ItemTemplate>

                                                <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="ProgAccount" HeaderText="List of Accounts">
                                                <ItemStyle HorizontalAlign="Left" Width="90%"></ItemStyle>
                                            </asp:BoundField>
                                        </Columns>

                                        <FooterStyle BackColor="#2977DC"></FooterStyle>

                                        <HeaderStyle BackColor="#2977DC" ForeColor="White"></HeaderStyle>
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

