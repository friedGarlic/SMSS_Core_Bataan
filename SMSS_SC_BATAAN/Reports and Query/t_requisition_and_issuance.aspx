<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="t_requisition_and_issuance.aspx.vb"
    Inherits="t_requisition_and_issuance" Title="Requisition and Issuance Report" StylesheetTheme="SkinFile" %>

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
                        <td style="width: 98%" class="PageTitle">REQUISITION AND ISSUANCE REPORTS
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
                                            <asp:ListItem Value="1">Responsibility Center</asp:ListItem>
                                            <asp:ListItem Selected="True" Value="2">RIS Number</asp:ListItem>
                                            <asp:ListItem Value="3">Date(Duration)</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                    <td style="width: 70%" class="column_Left">
                                        <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                                            <asp:View ID="View1" runat="server">
                                                <table style="width: 100%">
                                                    <tr>
                                                        <td style="width: 20%" class="column_RightBold">Department :</td>
                                                        <td style="width: 80%" class="column_Left">
                                                            <asp:DropDownList ID="drpDept" runat="server" Width="70%" CssClass="drpdownCSS" AutoPostBack="True">
                                                            </asp:DropDownList></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 20%" class="column_RightBold">Function :</td>
                                                        <td style="width: 80%" class="column_Left">
                                                            <asp:DropDownList ID="drpFunction" runat="server" Width="70%" CssClass="drpdownCSS" AutoPostBack="True">
                                                            </asp:DropDownList>
                                                            &nbsp;<asp:Button ID="btnDepartment" runat="server" Width="25%" Text="SEARCH" CssClass="CSButton" OnClientClick="StartProgressBar();"></asp:Button></td>
                                                    </tr>
                                                </table>
                                            </asp:View>
                                            <asp:View ID="View2" runat="server">
                                                <table style="width: 100%">
                                                    <tbody>
                                                        <tr>
                                                            <td style="width: 20%" class="column_RightBold">RIS Number :</td>
                                                            <td style="width: 80%" class="column_Left">
                                                                <asp:TextBox ID="txtrisnumber" runat="server" Width="200px" CssClass="txtbox_Var"></asp:TextBox>
                                                                &nbsp;<asp:Button ID="btnRISNo" runat="server" Width="120px" Text="SEARCH" CssClass="CSButton" OnClientClick="StartProgressBar();"></asp:Button></td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </asp:View>
                                            <asp:View ID="View3" runat="server">
                                                <table style="width: 100%">
                                                    <tr>
                                                        <td style="width: 20%" class="column_RightBold">Date From :</td>
                                                        <td style="width: 80%" class="column_Left">
                                                            <asp:TextBox ID="txtdatefrom" runat="server" Width="30%" CssClass="txtbox_Date"></asp:TextBox>
                                                            &nbsp;<asp:ImageButton ID="btncal1" runat="server" ImageUrl="~/images/Calendar_scheduleHS.png" Enabled="true"></asp:ImageButton></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 20%" class="column_RightBold">Date To :</td>
                                                        <td style="width: 80%" class="column_Left">
                                                            <asp:TextBox ID="txtdateto" runat="server" Width="30%" CssClass="txtbox_Date"></asp:TextBox>
                                                            &nbsp;<asp:ImageButton ID="btncal2" runat="server" ImageUrl="~/images/Calendar_scheduleHS.png" Enabled="true"></asp:ImageButton>
                                                            &nbsp;<asp:Button ID="btnByDate" runat="server" Width="120px" Text="SEARCH" CssClass="CSButton" OnClientClick="StartProgressBar();"></asp:Button>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 20%" class="column_RightBold"></td>
                                                        <td style="width: 80%" class="column_Left">
                                                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtdatefrom" PopupButtonID="btncal1">
                                                            </cc1:CalendarExtender>
                                                            <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtdateto" PopupButtonID="btncal2">
                                                            </cc1:CalendarExtender>
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
                        <td style="width: 98%" class="DivTitle">List Of Requisition And Issuance
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:GridView ID="grdRIS" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="RIS_No,RISHdr_ID,StockID,PropertyDetai_ID"
                                EmptyDataText="No Data Found." PageSize="20" SkinID="GridViewAA" Width="98%">
                                <Columns>
                                    <asp:TemplateField ShowHeader="False">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkPreview" runat="server" CssClass="LinkBtnPreview" CausesValidation="False" CommandName="Select" Font-Underline="False" OnClick="lnkPreview_Click" Text="Preview"></asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="8%" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="RISDate" DataFormatString="{0:MM/dd/yyyy}" HeaderText="Date">
                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="RIS_No" HeaderText="RIS Number">
                                        <ItemStyle HorizontalAlign="Center" Width="15%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="RC_Name" HeaderText="Department">
                                        <ItemStyle HorizontalAlign="Left" Width="60%" />
                                    </asp:BoundField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkCancel" runat="server" CssClass="LinkBtnCancel" CommandName="Select" Font-Underline="False" OnClick="lnkCancel_Click">Cancel</asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="7%" />
                                    </asp:TemplateField>
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
            <cc1:ModalPopupExtender ID="ProgressBarModalPopupExtender" runat="server" TargetControlID="ButtonProgress" BackgroundCssClass="modalBackground" PopupControlID="PanelProgress" BehaviorID="ProgressBarModalPopupExtender">
            </cc1:ModalPopupExtender>
            <asp:Button Style="border-top-style: none; border-right-style: none; border-left-style: none; background-color: transparent; border-bottom-style: none" ID="ButtonProgress" runat="server" Width="16px" Enabled="False"></asp:Button>



        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>

