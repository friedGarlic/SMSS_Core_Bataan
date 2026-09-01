<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="t_purchase_orderR.aspx.vb" Inherits="Procurement_t_purchase_request" Title="Purchase Order" StylesheetTheme="SkinFile" EnableEventValidation="false" %>

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
                        <td style="width: 98%" class="PageTitle">PURCHASE ORDER REPORTS
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
                                        <asp:RadioButtonList ID="RadioButtonList1" runat="server" Width="90%" CssClass="rbCS_Vertical" AutoPostBack="True">
                                            <asp:ListItem Selected="True">Purchase Order</asp:ListItem>
                                            <asp:ListItem>Date (Duration)</asp:ListItem>
                                            <asp:ListItem>Department </asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                    <td style="width: 70%" class="column_Left">
                                        <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                                            <asp:View ID="View1" runat="server">
                                                <table style="width: 100%">
                                                    <tbody>
                                                        <tr>
                                                            <td style="width: 20%" class="column_RightBold">PO Number :</td>
                                                            <td style="width: 80%" class="column_Left">
                                                                <asp:TextBox ID="txtPONumber" runat="server" Width="60%" CssClass="txtbox_Var"></asp:TextBox>
                                                                &nbsp;<asp:Button ID="btnSearchJEVNumber" runat="server" Width="120px" CssClass="CSButton" Text="Search"></asp:Button>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </asp:View>
                                            <asp:View ID="View4" runat="server">
                                                <table style="width: 100%">
                                                    <tr>
                                                        <td style="width: 20%" class="column_RightBold">Date From :</td>
                                                        <td style="width: 80%" class="column_Left">
                                                            <asp:TextBox ID="txtdatefrom" runat="server" Width="120px" CssClass="txtbox_Date"></asp:TextBox>
                                                            &nbsp;<asp:ImageButton ID="btncal1" runat="server" ImageUrl="~/images/Calendar_scheduleHS.png" Enabled="true"></asp:ImageButton>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 20%" class="column_RightBold">Date To :</td>
                                                        <td style="width: 80%" class="column_Left">
                                                            <asp:TextBox ID="txtdateto" runat="server" Width="120px" CssClass="txtbox_Date"></asp:TextBox>
                                                            &nbsp;<asp:ImageButton ID="btncal2" runat="server" ImageUrl="~/images/Calendar_scheduleHS.png" Enabled="true"></asp:ImageButton>
                                                            &nbsp;<asp:Button ID="btnByDate" runat="server" Width="120px" CssClass="CSButton" Text="Search"></asp:Button>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:View>


                                            <asp:View ID="View2" runat="server">
                                                <table style="width: 100%">
                                                    <tr>
                                                        <td style="width: 20%" class="column_RightBold">Department :</td>
                                                        <td style="width: 80%" class="column_Left">
                                                            <asp:DropDownList ID="ddDepartment" runat="server" Width="250px" CssClass="drpdownCSS"></asp:DropDownList>
                                                            &nbsp;<asp:Button ID="btnSearchRC" runat="server" Text="Search" Width="120px" CssClass="CSButton"></asp:Button>
                                                        </td>
                                                    </tr>
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
                            <asp:GridView ID="gvopen" runat="server" Width="98%" DataKeyNames="POHdr_ID" EmptyDataText="No Data Found." AutoGenerateColumns="False"
                                SkinID="GridViewAA" AllowPaging="True" OnPageIndexChanging="gvopen_PageIndexChanging" PageSize="20">
                                <Columns>
                                    <asp:TemplateField ShowHeader="False">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" Text="Preview" CssClass="LinkBtnPreview" Font-Underline="False" CommandName="Select" __designer:wfdid="w28"></asp:LinkButton>
                                        </ItemTemplate>

                                        <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="RC_Name" HeaderText="Office">
                                        <ItemStyle HorizontalAlign="Left" Width="30%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="PO_No" HeaderText="PO Number">
                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="PO_Date" DataFormatString="{0:MM/dd/yyyy}" HeaderText="PO Date">
                                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SuppName" HeaderText="Supplier Name">
                                        <ItemStyle HorizontalAlign="Left" Width="35%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ContractPrice" DataFormatString="{0:N}" HeaderText="Contract Price">
                                        <ItemStyle HorizontalAlign="Left" Width="35%"></ItemStyle>
                                        <ItemStyle HorizontalAlign="Right" Width="10%" />
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%">
                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="btncal1" TargetControlID="txtdatefrom"></cc1:CalendarExtender>
                            <cc1:CalendarExtender ID="CalendarExtender2" runat="server" PopupButtonID="btncal2" TargetControlID="txtdateto"></cc1:CalendarExtender>
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

