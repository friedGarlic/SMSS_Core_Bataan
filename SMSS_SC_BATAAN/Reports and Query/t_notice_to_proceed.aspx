<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="t_notice_to_proceed.aspx.vb" Inherits="Reports_and_Query_t_notice_to_proceed"
    Title="Notice to Proceed" StylesheetTheme="SkinFile" %>


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
                        <td style="width: 98%" class="PageTitle">NOTICE TO PROCEED
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
                                        <asp:RadioButtonList ID="RadioButtonList1" runat="server" Width="95%" CssClass="rbCS_Vertical" AutoPostBack="True">
                                            <asp:ListItem Selected="True" Value="1">Reference Number</asp:ListItem>
                                            <asp:ListItem Value="2">Bidder Name</asp:ListItem>
                                            <asp:ListItem Value="3">Date(Duration)</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                    <td style="width: 70%" class="column_Left">
                                        <asp:MultiView ID="MultiView1" runat="server">
                                            <asp:View ID="View1" runat="server">
                                                <table style="width: 100%">
                                                    <tbody>
                                                        <tr>
                                                            <td style="width: 20%" class="column_RightBold">Ref. Number :</td>
                                                            <td style="width: 80%" class="column_Left">
                                                                <asp:TextBox ID="txtRefNumber" runat="server" Width="200px" MaxLength="20" CssClass="txtbox_Var"></asp:TextBox>
                                                                &nbsp;<asp:Button ID="btnSearchREF" runat="server" Width="120px" Text="Search" CssClass="CSButton" OnClientClick="StartProgressBar();"></asp:Button></td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </asp:View>
                                            <asp:View ID="View3" runat="server">
                                                <table style="width: 100%">
                                                    <tbody>
                                                        <tr>
                                                            <td style="width: 20%" class="column_RightBold">Bidder Name :</td>
                                                            <td style="width: 80%" class="column_Left">
                                                                <asp:DropDownList ID="ddSupplier" runat="server" Width="300px" CssClass="drpdownCSS" AutoPostBack="True"></asp:DropDownList>
                                                                &nbsp;<asp:Button ID="btnSearchSupp" runat="server" Width="120px" Text="Search" CssClass="CSButton" OnClientClick="StartProgressBar();"></asp:Button></td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </asp:View>
                                            <asp:View ID="View4" runat="server">
                                                <table style="width: 100%">
                                                    <tbody>
                                                        <tr>
                                                            <td style="width: 20%" class="column_RightBold">Date From :</td>
                                                            <td style="width: 30%" class="column_Left">
                                                                <asp:TextBox ID="txtdatefrom" runat="server" Width="120px" CssClass="txtbox_Date"></asp:TextBox>
                                                                &nbsp;<asp:ImageButton ID="btncal1" runat="server" ImageUrl="~/images/Calendar_scheduleHS.png" Enabled="true"></asp:ImageButton></td>
                                                            <td style="width: 50%" class="column_Left" rowspan="2">
                                                                <asp:Button ID="btnByDate" runat="server" Width="120px" Text="Search" CssClass="CSButton" OnClientClick="StartProgressBar();"></asp:Button></td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 20%" class="column_RightBold">Date To :</td>
                                                            <td style="width: 30%" class="column_Left">
                                                                <asp:TextBox ID="txtdateto" runat="server" Width="120px" CssClass="txtbox_Var"></asp:TextBox>
                                                                &nbsp;<asp:ImageButton ID="btncal2" runat="server" ImageUrl="~/images/Calendar_scheduleHS.png" Enabled="true"></asp:ImageButton></td>
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
                        <td style="width: 98%" class="DivTitle">Notice Of Award
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:Panel ID="Panel1" runat="server" Width="98%" CssClass="PanelSize" ScrollBars="Vertical">
                                <asp:GridView ID="grdNotice" runat="server" Width="100%" AutoGenerateColumns="False" DataKeyNames="Bid_ID" EmptyDataText="NO DATA FOUND" SkinID="GridViewAA">
                                    <Columns>
                                        <asp:TemplateField ShowHeader="False">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="LinkButton1" runat="server" CssClass="LinkBtnPreview" CausesValidation="False" Text="Preview" Font-Underline="False" CommandName="Select" __designer:wfdid="w114"></asp:LinkButton>
                                            </ItemTemplate>

                                            <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                        </asp:TemplateField>
                                         <asp:BoundField DataField="project_reference_no" HeaderText="Reference Number">
                                            <ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Article" HeaderText="Project Name">
                                            <ItemStyle HorizontalAlign="Left" Width="30%"></ItemStyle>
                                        </asp:BoundField>                                       
                                        <asp:BoundField DataField="SuppName" HeaderText="Bidder Name">
                                            <ItemStyle HorizontalAlign="Left" Width="30%"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="NTP_Date" DataFormatString="{0:d}" HeaderText="Date of Notice">
                                            <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="NTP_ApprovedBy" HeaderText="Approved By">
                                            <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                        </asp:BoundField>
                                    </Columns>
                                </asp:GridView>
                            </asp:Panel>

                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtdatefrom" PopupButtonID="btncal1">
                            </cc1:CalendarExtender>
                            <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtdateto" PopupButtonID="btncal2">
                            </cc1:CalendarExtender>


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

            


        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>

