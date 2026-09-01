<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="t_inspection_and_acceptanceR.aspx.vb" Inherits="Procurement_t_inspection_and_acceptance"
    Title="Inspection and Acceptance Report" StylesheetTheme="SkinFile" %>

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
                        <td style="width: 98%" class="PageTitle">INSPECTION AND ACCEPTANCE REPORTS
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <table width="90%">
                                <tr>
                                    <td style="width: 10%" class="column_RightBold">Search By :</td>
                                    <td style="width: 15%" class="column_Left">
                                        <asp:RadioButtonList ID="RadioButtonList1" runat="server" Width="90%" CssClass="rbCS_Vertical" AutoPostBack="True">
                                            <asp:ListItem Selected="True" Value="1">PO Number</asp:ListItem>
                                            <asp:ListItem Value="2">Department</asp:ListItem>
                                            <asp:ListItem Value="3">Date(Duration)</asp:ListItem>
                                            <asp:ListItem Value="4">Invoice Number</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                    <td style="width: 75%" class="column_Left">
                                        <asp:MultiView ID="MultiView1" runat="server">
                                            <asp:View ID="View1" runat="server">
                                                <table style="width: 100%">
                                                    <tr>
                                                        <td style="width: 20%" class="column_RightBold">PO Number :</td>
                                                        <td style="width: 80%" class="column_Left">
                                                            <asp:TextBox ID="txtPONumber" runat="server" Width="50%" CssClass="txtbox_Var" MaxLength="20"></asp:TextBox>
                                                            &nbsp;<asp:Button ID="btnSearchPO" runat="server" Width="120px" CssClass="CSButton" OnClientClick="StartProgressBar();" Text="Search"></asp:Button></td>
                                                    </tr>
                                                </table>
                                            </asp:View>

                                            <asp:View ID="View3" runat="server">
                                                <table style="width: 100%">
                                                    <tr>
                                                        <td style="width: 20%" class="column_RightBold">Department : </td>
                                                        <td style="width: 80%" class="column_Left">
                                                            <asp:DropDownList ID="ddDepartment" runat="server" Width="60%" CssClass="drpdownCSS" AutoPostBack="True">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 20%" class="column_RightBold">Function : </td>
                                                        <td style="width: 80%" class="column_Left">
                                                            <asp:DropDownList ID="ddFunction" runat="server" Width="60%" CssClass="drpdownCSS" AutoPostBack="True">
                                                            </asp:DropDownList>
                                                            &nbsp;<asp:Button ID="btnSearchRC" runat="server" Width="120px" OnClientClick="StartProgressBar();" Text="Search" CssClass="CSButton" Enabled="False"></asp:Button>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:View>

                                            <asp:View ID="View4" runat="server">
                                                <table style="width: 100%">
                                                    <tbody>
                                                        <tr>
                                                            <td style="width: 20%" class="column_RightBold">Date From :</td>
                                                            <td style="width: 80%" class="column_Left">
                                                                <asp:TextBox ID="txtdatefrom" runat="server" Width="20%" CssClass="txtbox_Date"></asp:TextBox>
                                                                &nbsp;<asp:ImageButton ID="btncal1" runat="server" ImageUrl="~/images/Calendar_scheduleHS.png" Enabled="true"></asp:ImageButton></td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 20%" class="column_RightBold">Date To :</td>
                                                            <td style="width: 80%" class="column_Left">
                                                                <asp:TextBox ID="txtdateto" runat="server" Width="20%" CssClass="txtbox_Date"></asp:TextBox>
                                                                &nbsp;<asp:ImageButton ID="btncal2" runat="server" ImageUrl="~/images/Calendar_scheduleHS.png" Enabled="true"></asp:ImageButton>
                                                                &nbsp;<asp:Button ID="btnByDate" runat="server" Width="120px" CssClass="CSButton" OnClientClick="StartProgressBar();" Text="Search"></asp:Button>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 20%" class="column_RightBold"></td>
                                                            <td style="width: 80%" class="column_Left">
                                                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="btncal1" TargetControlID="txtdatefrom">
                                                                </cc1:CalendarExtender>
                                                                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" PopupButtonID="btncal2" TargetControlID="txtdateto">
                                                                </cc1:CalendarExtender>
                                                            </td>
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
                            <asp:GridView ID="grdAIR" runat="server" Width="98%" PageSize="20" OnPageIndexChanging="grdAIR_PageIndexChanging" AllowPaging="True"
                                SkinID="GridViewAA" EmptyDataText="NO DATA FOUND" DataKeyNames="AIRHdr_ID,AllotmentClass_ID" AutoGenerateColumns="False">
                                <Columns>
                                    <asp:TemplateField ShowHeader="False">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" Text="Preview" CssClass="LinkBtnPreview" Font-Underline="False" CommandName="Select" __designer:wfdid="w29" OnClick="LinkButton1_Click"></asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="RC_Name" HeaderText="Department">
                                        <ItemStyle HorizontalAlign="Left" Width="50%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="PO_No" HeaderText="PO Number">
                                        <ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Date_Accepted" DataFormatString="{0:d}" HeaderText="Date Accepted">
                                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Invoice_No" HeaderText="Invoice Number">
                                        <ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:TemplateField Visible="false">
                                        <ItemTemplate>
                                            <asp:LinkButton runat="server" ID="lnkReturn" CssClass="LinkBtnCancel" CausesValidation="False" Text="Return" Font-Underline="false" CommandName="Select" OnClick="lnkReturn_Click"></asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="5%" />
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









        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

