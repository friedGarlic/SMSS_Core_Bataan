<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="t_purchase_request.aspx.vb" Inherits="Reports_and_Query_t_purchase_request"
    Title="Purchased Request Reports" StylesheetTheme="SkinFile" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>


    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
        <ContentTemplate>


            <div>
                <table width="1020px">
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" class="PageTitle">PURCHASE REQUEST REPORT
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <table width="90%">
                                <tr>
                                    <td style="width: 10%" class="column_RightBold">Search By :
                                    </td>
                                    <td style="width: 20%" class="column_Left">
                                        <asp:RadioButtonList ID="RadioButtonList1" runat="server" Width="98%" CssClass="rbCS_Vertical" AutoPostBack="True">
                                            <asp:ListItem Selected="True" Value="1">Purchase Number</asp:ListItem>
                                            <asp:ListItem Value="2">Date (Duration)</asp:ListItem>
                                            <asp:ListItem Value="3">Allotment Class</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                    <td style="width: 70%" class="column_Left">
                                        <asp:MultiView ID="MultiView1" runat="server">
                                            <asp:View ID="View1" runat="server">
                                                <table style="width: 100%">
                                                    <tbody>
                                                        <tr>
                                                            <td style="width: 20%" class="column_RightBold">Purchase Number :</td>
                                                            <td style="width: 80%" class="column_Left">
                                                                <asp:TextBox ID="txtPRNumber" runat="server" Width="200px" CssClass="txtbox_Var" MaxLength="20"></asp:TextBox>
                                                                &nbsp;<asp:Button ID="btnSearchPRNo" runat="server" Width="120px" CssClass="CSButton" Text="SEARCH" OnClientClick="StartProgressBar();"></asp:Button>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </asp:View>
                                            <asp:View ID="View3" runat="server">
                                                <table style="width: 100%">
                                                    <tbody>
                                                        <tr>
                                                            <td style="width: 20%" class="column_RightBold">Transaction Type :</td>
                                                            <td style="width: 80%" class="column_Left">
                                                                <asp:DropDownList ID="drpTransType" runat="server" Width="200px" CssClass="drpdownCSS">
                                                                    <asp:ListItem Selected="True" Value="2">MOOE</asp:ListItem>
                                                                    <asp:ListItem Value="3">Capital Outlay</asp:ListItem>
                                                                </asp:DropDownList>
                                                                &nbsp;<asp:Button ID="btnTransType" runat="server" Width="120px" CssClass="CSButton" Text="SEARCH" OnClientClick="StartProgressBar();"></asp:Button>

                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </asp:View>
                                            <asp:View ID="View2" runat="server">
                                                <table style="width: 100%">
                                                    <tbody>
                                                        <tr>
                                                            <td style="width: 20%" class="column_RightBold">Date From :</td>
                                                            <td style="width: 80%" class="column_Left">
                                                                <asp:TextBox ID="txtdatefrom" runat="server" Width="120px" CssClass="txtbox_Date"></asp:TextBox>
                                                                &nbsp;<asp:ImageButton ID="btncal1" runat="server" ImageUrl="~/images/Calendar_scheduleHS.png" Enabled="true"></asp:ImageButton></td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 20%" class="column_RightBold">Date To :</td>
                                                            <td style="width: 80%" class="column_Left">
                                                                <asp:TextBox ID="txtdateto" runat="server" Width="120px" CssClass="txtbox_Date"></asp:TextBox>
                                                                &nbsp;<asp:ImageButton ID="btncal2" runat="server" ImageUrl="~/images/Calendar_scheduleHS.png" Enabled="true"></asp:ImageButton>
                                                                &nbsp;<asp:Button ID="btnByDate" runat="server" Width="120px" CssClass="CSButton" Text="SEARCH" OnClientClick="StartProgressBar();"></asp:Button>
                                                            </td>
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
                        <td style="width: 98%" class="DivTitle">List Of Purchase Request
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:GridView ID="gvopen" runat="server" Width="98%" SkinID="GridViewAA" EmptyDataText="NO DATA FOUND"
                                DataKeyNames="prhdr_id,pr_no" AutoGenerateColumns="False" AllowPaging="true" PageSize="30">
                                <Columns>
                                    <asp:TemplateField ShowHeader="False">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton1" OnClick="LinkButton1_Click" CssClass="LinkBtnPreview" runat="server" CausesValidation="False" Text="Preview" Font-Underline="False" CommandName="Select" __designer:wfdid="w27"></asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="pr_no" HeaderText="Purchase Number">
                                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="PR_Date" DataFormatString="{0:MM/dd/yyyy}" HeaderText="PR Date">
                                        <ItemStyle HorizontalAlign="Center" Width="8%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="rc_name" HeaderText="Department">
                                        <ItemStyle HorizontalAlign="Left" Width="30%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="remarks" HeaderText="Remaks">
                                        <ItemStyle HorizontalAlign="Left" Width="37%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ABC" DataFormatString="{0:N}" HeaderText="Amount">
                                        <ItemStyle HorizontalAlign="Right" Width="10%"></ItemStyle>
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%">
                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtdatefrom" PopupButtonID="btncal1" __designer:wfdid="w31">
                            </cc1:CalendarExtender>
                            <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtdateto" PopupButtonID="btncal2" __designer:wfdid="w32">
                            </cc1:CalendarExtender>
                            <asp:DropDownList ID="ddSortBy" runat="server" AutoPostBack="True" Visible="False" __designer:wfdid="w33">
                                <asp:ListItem Value="pr_no">Purchase Number</asp:ListItem>
                                <asp:ListItem Value="ABC">Amount</asp:ListItem>
                                <asp:ListItem Value="PR_Date">Date</asp:ListItem>
                            </asp:DropDownList>
                        </td>
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

