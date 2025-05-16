<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="t_acknowledgement_receipt.aspx.vb" Inherits="t_acknowledgement_receipt"
    Title="Acknowledgement Receipt" StylesheetTheme="SkinFile" %>

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
                        <td style="width: 98%" class="PageTitle">ACKNOWLEDGEMENT RECEIPT
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
                                        <asp:RadioButtonList ID="RadioButtonList1" runat="server" Width="98%" CssClass="rbCS_Vertical" AutoPostBack="True">
                                            <asp:ListItem Selected="True">Responsibility Center</asp:ListItem>
                                            <asp:ListItem>Employee Name</asp:ListItem>
                                            <asp:ListItem>Date(Duration)</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                    <td style="width: 70%" class="column_Left">
                                        <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">

                                            <asp:View ID="View1" runat="server">
                                                <table style="width: 100%">
                                                    <tbody>
                                                        <tr>
                                                            <td style="width: 20%" class="column_RightBold">Department :</td>
                                                            <td style="width: 80%" class="column_Left">
                                                                <asp:DropDownList ID="drpDept" runat="server" Width="250px" AutoPostBack="True" CssClass="drpdownCSS">
                                                                </asp:DropDownList>
                                                                &nbsp;<asp:Button ID="btnSearchJEVNumber" runat="server" Width="120px" CssClass="CSButton" OnClientClick="StartProgressBar();" Text="Search"></asp:Button>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 20%" class="column_RightBold">Function : </td>
                                                            <td style="width: 80%" class="column_Left">
                                                                <asp:DropDownList ID="drpFunction" runat="server" Width="250px" AutoPostBack="True" CssClass="drpdownCSS">
                                                                </asp:DropDownList></td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </asp:View>

                                            <asp:View ID="View3" runat="server">
                                                <table style="width: 100%">
                                                    <tbody>
                                                        <tr>
                                                            <td style="width: 20%" class="column_RightBold">Employee Name :</td>
                                                            <td style="width: 80%" class="column_Left">
                                                                <asp:TextBox ID="txtsearch" runat="server" Width="200px" CssClass="txtboxinspection"></asp:TextBox>
                                                                &nbsp;<asp:Button ID="btnTransType" runat="server" Width="120px" CssClass="CSButton" OnClientClick="StartProgressBar();" Text="Browse"></asp:Button>
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
                                                            &nbsp;<asp:Button ID="btnByDate" runat="server" Width="120px" CssClass="CSButton" OnClientClick="StartProgressBar();" Text="Search"></asp:Button>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtdatefrom" PopupButtonID="btncal1"></cc1:CalendarExtender>
                                                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtdateto" PopupButtonID="btncal2"></cc1:CalendarExtender>
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
                        <td style="width: 98%" class="DivTitle">Acknowledgement Receipt
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:GridView ID="grdARE" runat="server" Width="98%" OnPageIndexChanging="grdARE_PageIndexChanging" AllowPaging="True" PageSize="20"
                                AutoGenerateColumns="False" SkinID="GridViewAA" DataKeyNames="MREHdr_ID" EmptyDataText="NO DATA FOUND"
                                OnSelectedIndexChanged="grdARE_SelectedIndexChanged">
                                <Columns>
                                    <asp:TemplateField ShowHeader="False">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CssClass="LinkBtnPreview" Text="Preview" Font-Underline="False" CommandName="Select" __designer:wfdid="w53"></asp:LinkButton>
                                        </ItemTemplate>

                                        <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="MRENumber" HeaderText="PARE No.">
                                        <ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="RC_Name" HeaderText="Department">
                                        <ItemStyle HorizontalAlign="Left" Width="45%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="fullname" HeaderText="Employee Name">
                                        <ItemStyle HorizontalAlign="Left" Width="25%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="MRE_Date" DataFormatString="{0:MM/dd/yyyy}" HeaderText="Date">
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
            <cc1:ModalPopupExtender ID="ProgressBarModalPopupExtender" runat="server" BehaviorID="ProgressBarModalPopupExtender" PopupControlID="PanelProgress" TargetControlID="ButtonProgress">
            </cc1:ModalPopupExtender>
            <asp:Button Style="border-top-style: none; border-right-style: none; border-left-style: none; background-color: transparent; border-bottom-style: none" ID="ButtonProgress" runat="server" Width="16px" Enabled="False"></asp:Button>
        
        
        
        
        </ContentTemplate>
    </asp:UpdatePanel>


</asp:Content>

