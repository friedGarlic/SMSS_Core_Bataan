<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="t_PR_Tracking.aspx.vb" 
Inherits="procurement_t_PR_Tracking" title="PURCHASE REQUEST TRACKING" StylesheetTheme="SkinFile" EnableEventValidation="false"%>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<script runat="server">


</script>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:ScriptManager id="ScriptManager1" runat="server">
</asp:ScriptManager>

<asp:UpdatePanel id="UpdatePanel1" runat="server">
    <ContentTemplate>
        <table style="width: 100%">
            <tbody>
                <tr>
                    <td style="width: 10px" align="center"></td>
                    <td style="width: 1000px" class="PageTitle" align="center">PURCHASE REQUEST TRACKING</td>
                </tr>
                <tr align="left">
                    <td style="width: 10px" align="center"></td>
                    <td style="width: 1000px" align="center">
                       
                        <table width="100%">
                            <tr>
                                <td>
                                     <span style="font-size: 10pt; font-family: Verdana"><strong>Search PR Number :</strong></span>
                                    <asp:TextBox ID="txtSearch" runat="server" Width="200px"></asp:TextBox><asp:Button ID="btnSearch" OnClick="btnSearch_Click" CssClass="CSButton" runat="server" Width="150px" Font-Bold="True" Font-Size="10pt" Font-Names="Verdana" Font-Overline="False" Text="SEARCH"></asp:Button>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td style="width: 10px" align="center"></td>
                    <td style="width: 1000px" align="center">
                        <table width="100%">
                            <tr>
                                <td class="column_RightBold" style="width:15%">Status :</td>
                                <td class="column_Left"><asp:DropDownList ID="drpStatus" runat="server" Width="25%" CssClass="drpdownCSS" AutoPostBack="true" OnSelectedIndexChanged="drpStatus_SelectedIndexChanged">
                                            <asp:ListItem Value="0" Text="Select" Selected="True"></asp:ListItem>
                                            <asp:ListItem Value="1" Text="On Going"></asp:ListItem>
                                            <asp:ListItem Value="2" Text="Complete"></asp:ListItem>
                                       

                                        </asp:DropDownList></td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td style="width: 10px" align="center"></td>
                    <td style="width: 1000px" align="center">
                        <asp:GridView Style="font-weight: normal; text-align: justify" ID="grdPurchaseRequest" runat="server" Width="100%" Font-Size="8pt" EmptyDataText="No Data Found." OnPageIndexChanging="grdPurchaseRequest_PageIndexChanging" SkinID="GridViewAA" AllowPaging="True" AutoGenerateColumns="False" PageSize="30">
                            <Columns>
                                <asp:BoundField DataField="pr_no" HeaderText="PR Number">
                                    <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="OBR_DateApproved" DataFormatString="{0:&quot;MM/dd/yyyy&quot;}" HeaderText="OBR Approved">
                                    <ItemStyle HorizontalAlign="Center" Width="8%"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="MOP" HeaderText="Mode of Procurement">
                                    <ItemStyle HorizontalAlign="Left" Width="18%"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="Canvass_Date" DataFormatString="{0:&quot;MM/dd/yyyy&quot;}" HeaderText="Bidding">
                                    <ItemStyle HorizontalAlign="Center" Width="8%"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="Canvass_DateApproved" DataFormatString="{0:&quot;MM/dd/yyyy&quot;}" HeaderText="Bid Approved">
                                    <ItemStyle HorizontalAlign="Center" Width="8%"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="NOA_Date" DataFormatString="{0:&quot;MM/dd/yyyy&quot;}" HeaderText="NOA">
                                    <ItemStyle HorizontalAlign="Center" Width="8%"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="NTP_Date" DataFormatString="{0:&quot;MM/dd/yyyy&quot;}" HeaderText="NTP">
                                    <ItemStyle HorizontalAlign="Center" Width="8%"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="PO_Date" DataFormatString="{0:&quot;MM/dd/yyyy&quot;}" HeaderText="Purchase Order">
                                    <ItemStyle HorizontalAlign="Center" Width="8%"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="PO_DateApproved" DataFormatString="{0:&quot;MM/dd/yyyy&quot;}" HeaderText="PO Approved">
                                    <ItemStyle HorizontalAlign="Center" Width="8%"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="Received_Date" DataFormatString="{0:&quot;MM/dd/yyyy&quot;}" HeaderText="Received">
                                    <ItemStyle HorizontalAlign="Center" Width="8%"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="AIR_Date" DataFormatString="{0:&quot;MM/dd/yyyy&quot;}" HeaderText="Accepted">
                                    <ItemStyle HorizontalAlign="Center" Width="8%"></ItemStyle>
                                </asp:BoundField>
                            </Columns>

                            <FooterStyle BackColor="#2977DC"></FooterStyle>

                            <HeaderStyle BackColor="#2977DC" ForeColor="White"></HeaderStyle>
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td style="width: 10px" align="center"></td>
                    <td style="width: 1000px" align="center"></td>
                </tr>
            </tbody>
        </table>
    </ContentTemplate>
</asp:UpdatePanel>

</asp:Content>

