<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="t_receivingR.aspx.vb" Inherits="Procurement_t_receiving" Title="Receiving Report"
    StylesheetTheme="SkinFile" %>


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
                        <td style="width: 98%" class="PageTitle">RECEIVING REPORT
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <table width="80%">
                                <tr>
                                    <td style="width: 10%" class="column_RightBold">Search By :</td>
                                    <td style="width: 20%" class="column_Left">
                                        <asp:RadioButtonList ID="rbChoice" runat="server" Width="90%" CssClass="rbCS_Vertical" AutoPostBack="True" OnSelectedIndexChanged="rbChoice_SelectedIndexChanged">
                                            <asp:ListItem Selected="True"  Value="1">Received By</asp:ListItem>
                                            <asp:ListItem Value="2">Date (Duration)</asp:ListItem>
                                            <asp:ListItem Value="3">PO Number</asp:ListItem>
                                            <asp:ListItem Value="4">Invoice Number</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                    <td style="width: 70%" class="column_Left">
                                        <asp:MultiView ID="mvSearch" runat="server">
                                            <asp:View ID="vwReceivedBy" runat="server">
                                                <table style="width: 100%">
                                                    <tr>
                                                        <td style="width: 25%" class="column_RightBold">Received By :</td>
                                                        <td style="width: 75%" class="column_Left">
                                                            <asp:DropDownList ID="ddReceivedBy" runat="server" Width="250px" AutoPostBack="True" OnSelectedIndexChanged="ddReceivedBy_SelectedIndexChanged" CssClass="drpdownCSS"></asp:DropDownList>
                                                            &nbsp;<asp:Button ID="btnSearchRB" OnClick="btnSearchRB_Click" runat="server" Width="100px" CssClass="CSButton" OnClientClick="StartProgressBar();" Text="Search"></asp:Button></td>
                                                    </tr>
                                                </table>
                                            </asp:View>

                                            <asp:View ID="vwDate" runat="server">
                                                <table style="width: 100%">
                                                    <tr>
                                                        <td style="width: 25%" class="column_RightBold">Date From :</td>
                                                        <td style="width: 75%" class="column_Left">
                                                            <asp:TextBox ID="txtFrom" runat="server" Width="120px" CssClass="txtbox_Date"></asp:TextBox>
                                                            &nbsp;<asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/Calendar_scheduleHS.png" Enabled="true"></asp:ImageButton></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 25%" class="column_RightBold">Date To :</td>
                                                        <td style="width: 75%" class="column_Left">
                                                            <asp:TextBox ID="txtTo" runat="server" Width="120px" CssClass="txtbox_Date"></asp:TextBox>
                                                            &nbsp;<asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/images/Calendar_scheduleHS.png" Enabled="true"></asp:ImageButton>
                                                            &nbsp;<asp:Button ID="btnSearchDate" OnClick="btnSearchDate_Click" runat="server" Width="120px" CssClass="CSButton" OnClientClick="StartProgressBar();" Text="Search"></asp:Button>
                                                        </td>
                                                    </tr>
                                                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="ImageButton1" TargetControlID="txtFrom"></cc1:CalendarExtender>
                                                    <cc1:CalendarExtender ID="Calendarextender2" runat="server" PopupButtonID="ImageButton2" TargetControlID="txtTo"></cc1:CalendarExtender>
                                                </table>
                                            </asp:View>

                                            <asp:View ID="vwPO" runat="server">
                                                <table style="width: 100%">
                                                    <tbody>
                                                        <tr>
                                                            <td style="width: 25%" class="column_RightBold">PO Number :</td>
                                                            <td style="width: 75%" class="column_Left">
                                                                <asp:TextBox ID="txtPONumber" runat="server" Width="200px" CssClass="txtbox_Var"></asp:TextBox>
                                                                &nbsp;<asp:Button ID="btnPO" OnClick="btnPO_Click" runat="server" Width="120px" CssClass="CSButton" OnClientClick="StartProgressBar();" Text="Search"></asp:Button></td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </asp:View>
                                            
                                            <asp:View ID="vwInvoiceNum" runat="server">
                                                <table style="width: 100%">
                                                    <tbody>
                                                        <tr>
                                                            <td style="width: 25%" class="column_RightBold">Invoice Number :</td>
                                                            <td style="width: 75%" class="column_Left">
                                                                <asp:TextBox ID="txtInvoiceNum" runat="server" Width="200px" CssClass="txtbox_Var"></asp:TextBox>
                                                                &nbsp;<asp:Button ID="btnInvoiceNum" OnClick="btnInvoiceClick" runat="server" Width="120px" CssClass="CSButton" OnClientClick="StartProgressBar();" Text="Search"></asp:Button></td>
                                                        </tr>
                                                    </tbody>
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
                        <td style="width: 98%" class="DivTitle">Purchase Order
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:GridView ID="grdReceived" runat="server" Width="98%" OnSelectedIndexChanged="grdReceived_SelectedIndexChanged" PageSize="20" AllowPaging="True" 
                                DataKeyNames="Received_ID" AutoGenerateColumns="False" SkinID="GridViewAA" EmptyDataText="No Data Found." OnPageIndexChanging="grdReceived_PageIndexChanging">
                                <Columns>
                                    <asp:TemplateField ShowHeader="False">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CssClass="LinkBtnPreview" Text="Preview" Font-Underline="False" CommandName="Select"></asp:LinkButton>
                                        </ItemTemplate>

                                        <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="PO_No" HeaderText="PO Number">
                                        <ItemStyle HorizontalAlign="Left" Width="15%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Received_Date" DataFormatString="{0:d}" HeaderText="Date Received">
                                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ReceivedBy" HeaderText="Received By">
                                        <ItemStyle HorizontalAlign="Left" Width="30%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SuppName" HeaderText="Supplier">
                                        <ItemStyle HorizontalAlign="Left" Width="30%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="InvoiceNo" HeaderText="Invoice Number">
                                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
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
            <cc1:ModalPopupExtender ID="ProgressBarModalPopupExtender" runat="server" BehaviorID="ProgressBarModalPopupExtender" BackgroundCssClass="modalBackground" PopupControlID="PanelProgress" TargetControlID="ButtonProgress">
            </cc1:ModalPopupExtender>
            <asp:Button Style="border-top-style: none; border-right-style: none; border-left-style: none; background-color: transparent; border-bottom-style: none" ID="ButtonProgress" runat="server" Width="16px" Enabled="False"></asp:Button>
        
        
        
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>

