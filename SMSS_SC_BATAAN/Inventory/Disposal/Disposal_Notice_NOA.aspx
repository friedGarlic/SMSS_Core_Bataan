<%@ Page Title="Disposal - NOA" Language="VB" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" StylesheetTheme="SkinFile"
    CodeFile="Disposal_Notice_NOA.aspx.vb" Inherits="Inventory_Disposal_Disposal_Notice_NOA" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">

        <Scripts>

        </Scripts>

    </asp:ScriptManager>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>



           <%-- <div>
                <table width="1020px">
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="PageTitle">DISPOSAL - NOTICE OF AWARD
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <div runat="server" id="dvReport" class="ReportBorderCSS" style="width: 85%">
                                <table width="85%">
                                    <tr>
                                        <td style="width: 100%; height: 10px"></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100%" class="column_CenterBold">Republika ng Pilipinas
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100%" class="column_CenterBold">LUNGSOD NG PASAY, KALAKHANG MAYNILA
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100%" class="column_CenterBold">TANGGAPAN NG TAGA PANGASIWA
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100%; height: 20px"></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100%" class="column_Right">
                                            <asp:Label runat="server" ID="lblNOA_Date" Text="January 01, 1900"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100%; height: 10px"></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100%" class="column_Left">
                                            <asp:Label runat="server" ID="lblRepresentative" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100%" class="column_Left">
                                            <asp:Label runat="server" ID="lblSuppName" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100%" class="column_Left">
                                            <asp:Label runat="server" ID="lblSupp_Address" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100%; height: 20px"></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100%" class="column_CenterBold">
                                            NOTICE OF AWARD
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100%; height: 20px"></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100%" class="column_Left">
                                            Dear
                                            &nbsp;<asp:Label runat="server" ID="lblRepresentative2" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100%" align="center">
                                            <asp:TextBox runat="server" ID="txtNOA_Content" Width="95%" Height="350px" TextMode="MultiLine" CssClass="txtbox_Encoding"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100%" class="column_Left"></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100%" class="column_Left"></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100%" class="column_Left"></td>
                                    </tr>

                                </table>

                            </div>
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



















            <div>
                <table width="1020px">
                   

                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center" >

                            <table width="95%" class="ReportBorderCSS">
                                <tr>
                                    <td>
                                        <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 60%; font-size: 11pt" class="column_CenterBold"><span><b>Republika ng Pilipinas</b></span></td>
                                </tr>
                                <tr>
                                    <td style="font-size: 11pt" class="column_CenterBold">Provincial Government of Cagayan</td>
                                </tr>
                                <tr>
                                    <td style="font-size: 11pt" class="column_CenterBold"><span><b>TANGGAPAN NG TAGA PANGASIWA</b></span>
                                    </>
                                </tr>
                                <tr>
                                    <td>
                                        <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="column_Right" style="padding-right: 2%">
                                        <asp:TextBox Font-Size="10pt" runat="server" ID="txtDate" BorderStyle="None" Enabled="false" Text="01/01/01" CssClass="txtbox_Date" Width="10%"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="column_Left" style="padding-left: 2%">
                                        <asp:TextBox Font-Size="10pt" runat="server" ID="txtSuppName" BorderStyle="None" Enabled="false" Text="01/01/01" CssClass="txtbox_Var" Width="90%"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="column_Left" style="padding-left: 2%">
                                        <asp:TextBox Font-Size="10pt" runat="server" ID="txtCompName" BorderStyle="None" Enabled="false" Text="01/01/01" CssClass="txtbox_Var" Width="90%"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="column_Left" style="padding-left: 2%">
                                        <asp:TextBox Font-Size="10pt" runat="server" ID="txtAddress" BorderStyle="None" Enabled="false" Text="01/01/01" CssClass="txtbox_Var" Width="90%"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr align="center">
                                    <td class="column_Center" style="align-content: center">
                                        <asp:TextBox Font-Size="14pt" Font-Bold="true" runat="server" ID="txtHdr" BorderStyle="None" Enabled="false" Text="NOTICE OF AWARD" CssClass="column_CenterBold" Width="100%"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="column_Left" style="padding-left: 2%">
                                        <asp:TextBox Font-Size="11pt" runat="server" ID="txtDear" BorderStyle="None" Enabled="false" Text="Dear " CssClass="txtbox_Var" Width="90%"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" style="padding: 1%; text-align: center;">
                                        <asp:TextBox runat="server" ID="txtNOAContent" Height="200px" CssClass="txtbox_Encoding" TextMode="MultiLine" Width="95%"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="column_Left" style="padding-left: 2%">
                                        <asp:TextBox Font-Size="10pt" runat="server" ID="txtTY" BorderStyle="None" Enabled="false" Text="Thank you." CssClass="txtbox_Var" Width="25%"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="column_right" style="padding-left: 2%">
                                        <asp:TextBox Font-Size="10pt" runat="server" ID="txtFN" BorderStyle="None" Enabled="false" Text="01/01/01" CssClass="txtbox_Var" Width="25%"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="column_right" style="padding-left: 2%">
                                        <asp:TextBox Font-Size="10pt" runat="server" ID="txtPosition" BorderStyle="None" Enabled="false" Text="01/01/01" CssClass="txtbox_Var" Width="25%"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="column_Left" style="padding-left: 2%">
                                        <asp:TextBox Font-Size="10pt" runat="server" ID="txtISSP" BorderStyle="None" Enabled="false" CssClass="txtbox_Var" Width="25%"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 100%" align="center">
                                        <asp:Button runat="server" ID="btnPreview_NOA" CssClass="CSButton" Width="15%" Text="Save/Preview" OnClientClick="StartProgressBar();" Enabled="True" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
