<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="t_dispose_committe.aspx.vb" Inherits="filemaintenance_t_dispose_committe"
    Title="Dispose Committee" StylesheetTheme="SkinFile" EnableEventValidation="false" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<script runat="server">


</script>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table style="text-align: center" width="1015">
                <tbody>
                    <tr>
                        <td style="text-align: center" width="1015">
                            <table class="PageTitle">
                                <tbody>
                                    <tr>
                                        <td style="width: 1000px">DISPOSAL COMMITTEE</td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                    </tr>
                </tbody>
            </table>
            <table style="width: 1000px; text-align: center">
                <tbody>
                    <tr>
                        <td style="width: 1000px" align="right">
                            <asp:Button Style="position: relative" ID="btnADD" CssClass="CSButton" runat="server" Width="150px" Text="ADD MEMBER" __designer:wfdid="w1" OnClick="btnADD_Click"></asp:Button></td>
                    </tr>
                    <tr>
                        <td style="width: 1000px" align="center">
                            <asp:GridView Style="font-weight: normal" ID="grdDisposalComm" runat="server" Width="800px" CssClass="text" BorderStyle="Solid" SkinID="GridViewGL" EmptyDataText="No Data Found" OnSelectedIndexChanged="grdDisposalComm_SelectedIndexChanged" AutoGenerateColumns="False" PageSize="5" DataKeyNames="Position_Desc,DC_ID,DC_position_id">
                                <Columns>
                                    <asp:CommandField ShowSelectButton="True">
                                        <ItemStyle Width="10px"></ItemStyle>
                                    </asp:CommandField>
                                    <asp:BoundField DataField="name" HeaderText="NAME">
                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                        <ItemStyle HorizontalAlign="Left" Width="230px"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="pos_desc" HeaderText="POSITION">
                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                        <ItemStyle HorizontalAlign="Left" Width="200px"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="department" HeaderText="DEPARTMENT">
                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                        <ItemStyle HorizontalAlign="Left" Width="360px"></ItemStyle>
                                    </asp:BoundField>
                                      <asp:BoundField DataField="Status_Description" HeaderText="Status">
                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                        <ItemStyle HorizontalAlign="Left" Width="100px"></ItemStyle>
                                    </asp:BoundField>


                                </Columns>

                                <FooterStyle BackColor="#2977DC"></FooterStyle>

                                <HeaderStyle BackColor="#2977DC" ForeColor="White"></HeaderStyle>
                            </asp:GridView>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px">
                            <table style="width: 1000px">
                                <tbody>
                                    <tr>
                                        <td style="width: 100px"></td>
                                        <td style="width: 190px" class="text5">Name</td>
                                        <td style="width: 10px" class="column_LeftBold">:</td>
                                        <td style="width: 700px" class="column_LeftBold">
                                            <asp:DropDownList ID="ddNames" runat="server" AutoPostBack="True" CssClass="txtboxinspection" Enabled="False" OnSelectedIndexChanged="ddNames_SelectedIndexChanged" Width="400px">
                                                <asp:ListItem>Select</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100px"></td>
                                        <td style="width: 190px" class="text5">Position</td>
                                        <td style="width: 10px" class="column_LeftBold">:</td>
                                        <td style="width: 700px" class="column_LeftBold">
                                            <asp:TextBox ID="txtPosition" runat="server" CssClass="txtboxinspection" Enabled="False" ReadOnly="True" Width="395px" Visible="false"></asp:TextBox>
                                            <asp:DropDownList ID="ddPosition" runat="server" AutoPostBack="True" CssClass="drpdownCSS" Enabled="False"  Width="400px" OnSelectedIndexChanged="ddPosition_SelectedIndexChanged">
                                                
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100px"></td>
                                        <td style="width: 190px" class="text5">Department</td>
                                        <td style="width: 10px" class="column_LeftBold">:</td>
                                        <td style="width: 700px" class="column_LeftBold">
                                            <asp:TextBox ID="txtDepartment" runat="server" Width="395px" CssClass="txtboxinspection" Enabled="False" ReadOnly="True"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td style="height: 23px"></td>
                                        <td class="text5" style="height: 23px">Status</td>
                                        <td style="height: 23px">:</td>
                                        <td style="height: 23px" class="column_LeftBold">
                                            <asp:DropDownList ID="ddStatus" runat="server" AutoPostBack="True" CssClass="drpdownCSS" Enabled="False" Width="100px">
                                                      <asp:ListItem Value="0">Default</asp:ListItem>
                                                      <asp:ListItem Value="1">Active</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="4"></td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="4">
                                            <asp:Button ID="btnsave" OnClick="btnsave_Click" runat="server" Width="166px" OnClientClick="StartProgressBar();" Text="Save" CssClass="CSButton"></asp:Button>&nbsp
                                            <asp:Button ID="btncancel" runat="server" Width="166px" OnClientClick="StartProgressBar();" Text="Cancel" CssClass="CSButton"></asp:Button></td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                    </tr>
                </tbody>
            </table>
            <br />
            <br />
            <asp:Panel Style="border-top-width: 1px; border-left-width: 1px; border-left-color: #0033cc; border-bottom-width: 1px; border-bottom-color: #0033cc; border-top-color: #0033cc; position: relative; background-color: transparent; text-align: center; border-right-width: 1px; border-right-color: #0033cc" ID="PanelProgress" runat="server" Width="109px" __designer:wfdid="w7">
                <img src="../images/ajax-loader.gif" />
            </asp:Panel>
            <cc1:ModalPopupExtender ID="ProgressBarModalPopupExtender" runat="server" __designer:wfdid="w8" BackgroundCssClass="modalBackground" BehaviorID="ProgressBarModalPopupExtender" PopupControlID="PanelProgress" TargetControlID="ButtonProgress"></cc1:ModalPopupExtender>
            <asp:Button Style="border-top-style: none; border-right-style: none; border-left-style: none; position: relative; background-color: transparent; border-bottom-style: none" ID="ButtonProgress" runat="server" Width="16px" Enabled="False" __designer:wfdid="w9"></asp:Button>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>

