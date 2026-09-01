<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="t_Property_information.aspx.vb" Inherits="t_Property_information" title="Property Information"StylesheetTheme="SkinFile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1"   Runat="Server">
<table width="1015px" style="text-align:center">
<tr>
<td width="1015px" style="text-align:center">
    
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>   

<asp:UpdatePanel id="UpdatePanel1" runat="server">   
<contenttemplate>    
    <table style="width: 1010px">
        <tr>
            <td style="width: 10px">
            </td>
            <td style="width: 1000px">
            </td>
        </tr>
        <tr>
            <td style="width: 10px">
            </td>
            <td class="PageTitle" style="width: 1000px">
                &nbsp;PROPERTY INFORMATION</td>
        </tr>
        <tr>
            <td style="width: 10px">
            </td>
            <td style="width: 1000px">
            </td>
        </tr>
        <tr>
            <td style="width: 10px">
            </td>
            <td style="width: 1000px">
                    <table style="width: 90%; border-right: royalblue 1px solid; border-top: royalblue 1px solid; border-left: royalblue 1px solid; border-bottom: royalblue 1px solid;">
                        <tr>
                            <td class="column_LeftBold" style="width: 3%">
                            </td>
                            <td style="width: 15%;" class="column_LeftBold">
                            </td>
                            <td style="width: 2%;" class="column_LeftBold">
                            </td>
                            <td style="width: 80%;" class="text5">
                            </td>
                        </tr>
                        <tr>
                            <td class="column_LeftBold" style="width: 3%">
                            </td>
                            <td style="width: 15%" class="column_LeftBold">
                                Bar Code</td>
                            <td style="width: 2%" class="column_LeftBold">
                                :</td>
                            <td style="width: 80%" class="text5">
                                <asp:TextBox ID="TXTBARCODE" runat="server" AutoPostBack="True" OnTextChanged="TXTBARCODE_TextChanged"
                                    Width="230px" CssClass="txtboxinspection"></asp:TextBox>
                                <asp:Label ID="Label2" runat="server" Font-Italic="True" ForeColor="Red" Text="Data not available!"
                                    Visible="False" Font-Names="Calibri"></asp:Label></td>
                        </tr>
                        <tr style="color: #000000">
                            <td class="column_LeftBold" style="width: 3%">
                            </td>
                            <td style="width: 15%" class="column_LeftBold">
                                Property Number</td>
                            <td style="width: 2%" class="column_LeftBold">
                                :</td>
                            <td style="width: 80%" class="text5">
                                <asp:TextBox ID="txtpropertynum" runat="server" ReadOnly="True" Width="230px" CssClass="txtboxinspection"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="column_LeftBold" style="width: 3%">
                            </td>
                            <td style="width: 15%" class="column_LeftBold">
                                Description</td>
                            <td style="width: 2%" class="column_LeftBold">
                                :</td>
                            <td style="width: 80%" class="text5">
                                <asp:TextBox ID="TXTDESCRIPTION" runat="server" ReadOnly="True" Width="499px" CssClass="txtboxinspection"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="column_LeftBold" style="width: 3%">
                            </td>
                            <td style="width: 15%;" class="column_LeftBold">
                                Department</td>
                            <td style="width: 2%;" class="column_LeftBold">
                                :</td>
                            <td style="width: 80%;" class="text5">
                                <asp:TextBox ID="txtrespcenter" runat="server" ReadOnly="True" Width="499px" CssClass="txtboxinspection"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="column_LeftBold" style="width: 3%">
                            </td>
                            <td style="width: 15%;" class="column_LeftBold">
                                Function</td>
                            <td style="width: 2%;" class="column_LeftBold">
                                :</td>
                            <td style="width: 80%;" class="text5">
                                <asp:TextBox ID="txtFunction" runat="server" ReadOnly="True" Width="499px" CssClass="txtboxinspection"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="column_LeftBold" style="width: 3%">
                            </td>
                            <td style="width: 15%" class="column_LeftBold">
                                Cost</td>
                            <td style="width: 2%" class="column_LeftBold">
                                :</td>
                            <td style="width: 80%" class="text5">
                                <asp:TextBox ID="txtcost" runat="server" ReadOnly="True" Style="text-align: right" CssClass="txtboxinspection"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="column_LeftBold" style="width: 3%">
                            </td>
                            <td style="width: 15%" class="column_LeftBold">
                                Date Purchased</td>
                            <td style="width: 2%" class="column_LeftBold">
                                :</td>
                            <td style="width: 80%" class="text5">
                                <asp:TextBox ID="txtdatePurchased" runat="server" ReadOnly="True" Style="text-align: left" CssClass="txtboxinspection"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="column_LeftBold" style="width: 3%">
                            </td>
                            <td style="width: 15%" class="column_LeftBold">
                                Date Acquired</td>
                            <td style="width: 2%" class="column_LeftBold">
                                :</td>
                            <td style="width: 80%" class="text5">
                                <asp:TextBox ID="txtdate" runat="server" ReadOnly="True" Style="text-align: left" CssClass="txtboxinspection"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="column_LeftBold" style="width: 3%">
                            </td>
                            <td style="width: 15%" class="column_LeftBold">
                                Responsible Person</td>
                            <td style="width: 2%" class="column_LeftBold">
                                :</td>
                            <td style="width: 80%" class="text5">
                                <asp:TextBox ID="txtperson" runat="server" ReadOnly="True" Width="230px" CssClass="txtboxinspection"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="column_LeftBold" style="width: 3%">
                            </td>
                            <td style="width: 15%" class="column_LeftBold">
                            </td>
                            <td style="width: 2%" class="column_LeftBold">
                            </td>
                            <td style="width: 80%" class="text5">
                            </td>
                        </tr>
                    </table>
            </td>
        </tr>
        <tr>
            <td style="width: 10px">
            </td>
            <td class="DivTitle" style="width: 1000px">
                HISTORY OF PROPERTY</td>
        </tr>
        <tr>
            <td style="width: 10px">
            </td>
            <td style="width: 1000px">
                    <asp:GridView ID="gvbody" runat="server" SkinID="GridViewAA" Style="font-weight: normal"
                        Width="95%" Font-Size="9pt">
                        <Columns>
                            <asp:BoundField DataField="date" DataFormatString="{0:MM/dd/yyyy}" HeaderText="Date"
                                HtmlEncode="False" >
                                <ItemStyle HorizontalAlign="Center" Width="10%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Operation" HeaderText="Operation" >
                                <ItemStyle HorizontalAlign="Left" Width="15%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="FullName" HeaderText="Name" >
                                <ItemStyle HorizontalAlign="Left" Width="25%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="rc_name" HeaderText="Department" >
                                <ItemStyle HorizontalAlign="Left" Width="25%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Function_Desc" HeaderText="Function" >
                                <ItemStyle HorizontalAlign="Left" Width="25%" />
                            </asp:BoundField>
                        </Columns>
                    </asp:GridView>
            </td>
        </tr>
    </table>
    
 </contenttemplate>
</asp:UpdatePanel>
</td>
</tr>
</table>
   
    
</asp:Content>

