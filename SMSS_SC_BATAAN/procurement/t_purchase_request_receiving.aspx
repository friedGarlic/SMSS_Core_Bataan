<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="t_purchase_request_receiving.aspx.vb" Inherits="procurement_t_purchase_request_receiving" Title="Purchase Request Receiving Section" StylesheetTheme="SkinFile" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<script runat="server">



</script>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <asp:UpdatePanel ID="UpdatePanel22" runat="server">
        <ContentTemplate>





            <table style="width: 100%">
                <tbody>
                    <tr>
                        <td style="width: 10px"></td>
                        <td style="width: 1000px" class="PageTitle" align="center">PURCHASE REQUEST RECEIVING</td>
                    </tr>
                    <tr>
                        <td style="width: 10px"></td>
                        <td style="width: 1000px" class="column_Left" align="center">
                            <table style="width: 800px">
                                <tbody>
                                    <tr>
                                        <td style="vertical-align: middle; width: 100px; text-align: center" rowspan="2">
                                            <asp:LinkButton Style="vertical-align: middle; color: #006633" ID="btnToday" runat="server" Width="80px" Font-Bold="True" BackColor="#B7D9C5" Height="31px" OnClientClick="StartProgressBar();">Today</asp:LinkButton></td>
                                        <td style="width: 100px" align="left">
                                            <asp:Label Style="font-weight: bold; font-size: 7pt; color: white; background-color: #ff0000; text-align: center" ID="lblToday" runat="server" Width="21px"></asp:Label></td>
                                        <td style="vertical-align: middle; width: 100px; text-align: center" rowspan="2">
                                            <asp:LinkButton Style="vertical-align: middle; color: #006633" ID="btnThisWeek" runat="server" Width="80px" Font-Bold="True" Height="31px" OnClientClick="StartProgressBar();">This week</asp:LinkButton></td>
                                        <td style="width: 100px" align="left">
                                            <asp:Label Style="font-weight: bold; font-size: 7pt; color: white; background-color: #ff0000; text-align: center" ID="lblthisWeek" runat="server" Width="20px"></asp:Label></td>
                                        <td style="vertical-align: middle; width: 100px; text-align: center" rowspan="2">
                                            <asp:LinkButton Style="vertical-align: middle; color: #006633" ID="btnThisMonth" runat="server" Width="80px" Font-Bold="True" Height="31px" OnClientClick="StartProgressBar();">This Month</asp:LinkButton></td>
                                        <td style="width: 100px" align="left">
                                            <asp:Label Style="font-weight: bold; font-size: 7pt; color: white; background-color: #ff0000; text-align: center" ID="lblThisMonth" runat="server" Width="20px"></asp:Label></td>
                                        <td style="vertical-align: middle; width: 100px; text-align: center" rowspan="2">
                                            <asp:LinkButton Style="vertical-align: middle; color: #006633" ID="btnALL" runat="server" Width="80px" Font-Bold="True" Height="31px" OnClientClick="StartProgressBar();">ALL</asp:LinkButton></td>
                                        <td style="width: 100px" align="left">
                                            <asp:Label Style="font-weight: bold; font-size: 7pt; color: white; background-color: #ff0000; text-align: center" ID="lblall" runat="server" Width="20px"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100px" align="left"></td>
                                        <td style="width: 100px" align="left"></td>
                                        <td style="width: 100px" align="left"></td>
                                        <td style="width: 100px" align="left"></td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                    </tr>
                    <tr>
                         <td style="width: 10px"></td>
                         <td style="width: 1000px">
                           <table>
                               <tr>
                                   <td class="column_RightBold">Department :</td>
                                   <td class="column_Left">
                                        <asp:DropDownList ID="ddRC" runat="server" Width="400px" AutoPostBack="True" CssClass="drpdownCSS" AppendDataBoundItems="True">
                                               
                                            </asp:DropDownList>
                                            
                                       <asp:Button ID="btnSearch" runat="server" CssClass="CSButton" Text="Search" OnClick="btnSearch_Click" />
                                   </td>
                                   
                               </tr>
                           </table>
                         </td>
                    </tr>
                    
                    <tr>
                        <td style="width: 10px"></td>
                        <td style="width: 1000px" align="center">
                            <asp:GridView  ID="gvPurchaseRequest" runat="server" Width="98%" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="prhdr_id" PageSize="8" SkinID="GridViewAA">
                                <Columns>
                                    <asp:BoundField DataField="rc_name" HeaderText="Department">
                                        <ItemStyle HorizontalAlign="Left" Width="40%"></ItemStyle>
                                    </asp:BoundField>

                                    <asp:BoundField DataField="Function_Desc" HeaderText="Function">
                                        <ItemStyle HorizontalAlign="Left" Width="20%"></ItemStyle>
                                    </asp:BoundField>

                                    <asp:BoundField DataField="ABC" DataFormatString="{0:N}" HeaderText="ABC">
                                        <ItemStyle HorizontalAlign="Right" Width="10%"></ItemStyle>
                                    </asp:BoundField>

                                    <asp:TemplateField HeaderText="PR Type">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPTType" runat="server" 
                                                       Text='<%# GetPTType(Eval("IsNonPPMP")) %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                    </asp:TemplateField>



                                    <asp:TemplateField HeaderText="Date Submitted">
                                        <ItemTemplate>
                                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("Date_Submitted", "{0:MM/dd/yyyy}") %>'  Visible='<%# bind("isVisible") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                    </asp:TemplateField>

                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkview" OnClick="lnkview_Click" runat="server" CssClass="LinkBtnPreview" Font-Underline="False" Visible='<%# bind("isVisible") %>' CommandName="Select" CommandArgument="Select">View</asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="7%"></ItemStyle>
                                    </asp:TemplateField>

                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton2" OnClick="LinkButton2_Click" runat="server" CssClass="LinkBtnSelect" Font-Underline="False" Visible='<%# bind("isVisible") %>' CommandName="Select" CommandArgument="Select">Receive</asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="8%"></ItemStyle>
                                    </asp:TemplateField>

                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkReturn" OnClick="lnkReturn_Click" runat="server" OnClientClick="StartProgressBar();" Font-Underline="False" CssClass="LinkBtnCancel" Visible='<%# bind("isVisible") %>' CommandName="Select">Return</asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                    </asp:TemplateField>
                                </Columns>

                                <FooterStyle BackColor="#2977DC"></FooterStyle>

                                <HeaderStyle BackColor="#2977DC" ForeColor="White"></HeaderStyle>
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 10px"></td>
                        <td style="width: 1000px" align="center"></td>
                    </tr>
                </tbody>
            </table>

            <asp:Panel ID="Panel1" runat="server" Width="300px" CssClass="Panel_Popup">
                <table width="100%">
                    <tr>
                        <td style="width: 100%" class="DivTitle">Received Date
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100%; height: 10px"></td>
                    </tr>
                    <tr>
                        <td style="width: 100%" align="center">
                            <asp:TextBox ID="txtDateReceive" runat="server" Width="150px" CssClass="txtbox_Date"></asp:TextBox>
                            &nbsp;<asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/Calendar_scheduleHS.png"></asp:ImageButton>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100%; height: 10px"></td>
                    </tr>
                    <tr>
                        <td style="width: 100%" align="center">
                            <asp:Button ID="btnReceiveDoc" runat="server" Width="100px" CssClass="CSButton" Text="Receive" OnClientClick="StartProgressBar();"></asp:Button>
                            &nbsp;<asp:Button ID="btnCancelReceiveDoc" runat="server" Width="100px" CssClass="CSButton" Text="Cancel"></asp:Button>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100%"></td>
                    </tr>
                </table>

                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDateReceive" PopupButtonID="ImageButton1">
                </cc1:CalendarExtender>
                <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" TargetControlID="btnReceiveDoc" ConfirmText="Are you sure you have this document?">
                </cc1:ConfirmButtonExtender>
                <asp:Button Style="background-color: transparent" ID="btn" runat="server" BorderStyle="None" Enabled="False"></asp:Button>

            </asp:Panel>
            <cc1:ModalPopupExtender ID="ModalPopupExtender123" runat="server" BackgroundCssClass="modalBackground" PopupControlID="Panel1" TargetControlID="btn" CancelControlID="btnCancelReceiveDoc">
            </cc1:ModalPopupExtender>


            <asp:Panel Style="border-top-width: 1px; border-left-width: 1px; border-left-color: #0033cc; border-bottom-width: 1px; border-bottom-color: #0033cc; border-top-color: #0033cc; position: relative; background-color: transparent; text-align: center; border-right-width: 1px; border-right-color: #0033cc" ID="PanelProgress" runat="server" Width="109px">
                <img alt="" src="../images/ajax-loader.gif" />
            </asp:Panel>
            <cc1:ModalPopupExtender ID="ProgressBarModalPopupExtender" runat="server" BackgroundCssClass="modalBackground" PopupControlID="PanelProgress" TargetControlID="ButtonProgress" BehaviorID="ProgressBarModalPopupExtender"></cc1:ModalPopupExtender>
            <asp:Button Style="border-top-style: none; border-right-style: none; border-left-style: none; position: relative; background-color: transparent; border-bottom-style: none" ID="ButtonProgress" runat="server" Width="16px" Enabled="False"></asp:Button>

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

