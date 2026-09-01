<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="t_RIS_Conso.aspx.vb" Inherits="Reports_and_Query_t_RIS_Conso" Title="RIS Consolidated Report" StylesheetTheme="SkinFile" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div>
                <table width="100%">
                    <tr>
                        <td style="width:1%"></td>
                        <td style="width:98%" class="PageTitle">RIS CONSOLIDATED REPORT</td>
                        <td style="width:1%"></td>
                    </tr>

                    <tr>
                        <td style="width:1%"></td>
                        <td style="width:98%" align="center">
                            <table width="80%">

                                 <tr>
                                    <td style="width:25%" class="column_RightBold">Department :</td>
                                    <td style="width:75%" class="column_Left">
                                        <asp:DropDownList ID="ddRC" runat="server" Width="50%" CssClass="drpdownCSS" AutoPostBack="true" OnSelectedIndexChanged="ddRC_SelectedIndexChanged"></asp:DropDownList>
                                    </td>
                                </tr>

                                <tr>
                                    <td style="width:25%" class="column_RightBold">Year :</td>
                                    <td style="width:75%" class="column_Left">
                                        <asp:DropDownList ID="drpYear" runat="server" Width="30%" CssClass="drpdownCSS" AutoPostBack="true" OnSelectedIndexChanged="drpYear_SelectedIndexChanged"></asp:DropDownList>
                                    </td>
                                </tr>

                                <tr>
                                    <td class="column_RightBold">Month From :</td>
                                    <td class="column_Left">
                                        <asp:DropDownList ID="drpMonthFrom" runat="server" Width="30%" CssClass="drpdownCSS" AutoPostBack="true" OnSelectedIndexChanged="drpMonthFrom_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                </tr>

                                <tr>
                                    <td class="column_RightBold">Month To :</td>
                                    <td class="column_Left">
                                        <asp:DropDownList ID="drpMonthTo" runat="server" Width="30%" CssClass="drpdownCSS" AutoPostBack="true" OnSelectedIndexChanged="drpMonthTo_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                </tr>

                                <tr style="height:15px;">
                                    <td class="column_RightBold"></td>
                                    <td class="column_Left"></td>
                                </tr>

                                <tr>
                                    <td class="column_RightBold">Form Number :</td>
                                    <td class="column_Left">
                                        <asp:TextBox ID="txtFormNumber" runat="server" Width="70%" CssClass="txtbox_Var">
                                        </asp:TextBox>
                                    </td>
                                </tr>

                                <tr>
                                    <td class="column_RightBold">Office :</td>
                                    <td class="column_Left">
                                        <asp:TextBox ID="txtOffice" runat="server" Width="70%" CssClass="txtbox_Var">
                                        </asp:TextBox>
                                    </td>
                                </tr>

                                <tr>
                                    <td class="column_RightBold">Purpose :</td>
                                    <td class="column_Left">
                                        <asp:TextBox ID="txtPurpose" runat="server" Width="70%" TextMode="MultiLine" Rows="3" CssClass="txtbox_Var">
                                        </asp:TextBox>
                                    </td>
                                </tr>

                                <tr>
                                    <td class="column_RightBold">Printed Name :</td>
                                    <td class="column_Left">
                                        <asp:TextBox ID="txtPrintedName" runat="server" Width="70%" CssClass="txtbox_Var">
                                        </asp:TextBox>
                                    </td>
                                </tr>

                                <tr>
                                    <td class="column_RightBold">Designation :</td>
                                    <td class="column_Left">
                                        <asp:TextBox ID="txtDesignation" runat="server" Width="70%" CssClass="txtbox_Var">
                                        </asp:TextBox>
                                    </td>
                                </tr>

                                <tr>
                                    <td class="column_RightBold">Date :</td>
                                    <td class="column_Left">
                                       <asp:TextBox ID="txtDate" runat="server" Width="30%" CssClass="txtbox_Date"></asp:TextBox>

                                        <cc1:CalendarExtender ID="CalendarExtender1"
                                            runat="server"
                                            TargetControlID="txtDate"
                                            Format="MM/dd/yyyy">
                                        </cc1:CalendarExtender>
                                    </td>
                                </tr>

                                <tr style="height:15px;">
                                    <td class="column_RightBold"></td>
                                    <td class="column_Left"></td>
                                </tr>


                             
                            </table>
                               <tr>
                                    <td></td>
                                    <td class="column_Center">
                                        <asp:Button ID="btnSave" runat="server" Text="SAVE AND PREVIEW" Width="150px" CssClass="CSButton">
                                        </asp:Button>
                                    </td>
                                </tr>
                        </td>
                        <td style="width:1%"></td>
                    </tr>

                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>