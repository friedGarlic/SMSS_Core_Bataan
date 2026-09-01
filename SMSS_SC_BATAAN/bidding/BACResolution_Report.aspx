<%@ Page Title="BAC Resolution Report" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="BACResolution_Report.aspx.vb"
    Inherits="bidding_BACResolution_Report" StylesheetTheme="SkinFile" %>

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
                        <td style="width: 98%" class="PageTitle">BAC Resolution Report</td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%; height: 10px"></td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%; height: 907px;"></td>
                        <td style="width: 98%; height: 907px;" class="panel_border">

                            <table width="100%">
                                <tr>
                                    <td style="width: 1%"></td>
                                    <td style="width: 98%; height: 10px"></td>
                                    <td style="width: 1%"></td>
                                </tr>
                                <tr>
                                    <td style="width: 1%"></td>
                                    <td style="width: 98%" align="center">
                                        <div style="width: 90%">
                                            <span class="column_RightBold">Name of Project : </span>
                                            &nbsp;<asp:Label runat="server" ID="txtProjectName" CssClass="column_LeftBold"></asp:Label>
                                        </div>
                                        <%--&nbsp;<asp:TextBox runat="server" ID="txtProjectName" Width="70%" TextMode="MultiLine" CssClass="txtbox_Rpt1"></asp:TextBox>--%>
                                    </td>
                                    <td style="width: 1%"></td>
                                </tr>
                                <tr>
                                    <td style="width: 1%"></td>
                                    <td style="width: 98%; height: 10px"></td>
                                    <td style="width: 1%"></td>
                                </tr>
                                <tr>
                                    <td style="width: 1%"></td>
                                    <td style="width: 98%" align="center">
                                        <span class="column_CenterBold">BAC RESOLUTION DECLARING LCRB AND RECOMMENDING APPROVAL</span>
                                        <br />
                                        <span class="column_CenterBold">Resolution No. : </span>
                                        &nbsp;<asp:Label runat="server" ID="lblResoNumb" CssClass="column_LeftBold" Text="000-0000-00"></asp:Label>
                                    </td>
                                    <td style="width: 1%"></td>
                                </tr>
                                <tr>
                                    <td style="width: 1%"></td>
                                    <td style="width: 98%; height: 10px"></td>
                                    <td style="width: 1%"></td>
                                </tr>
                                <tr>
                                    <td style="width: 1%"></td>
                                    <td style="width: 98%" align="center">
                                        <asp:TextBox runat="server" ID="txtContent_P1" Width="90%" Height="90px" TextMode="MultiLine" CssClass="txtbox_Rpt2" ReadOnly="True"></asp:TextBox>
                                    </td>
                                    <td style="width: 1%"></td>
                                </tr>
                                <tr>
                                    <td style="width: 1%"></td>
                                    <td style="width: 98%" align="center">
                                        <asp:TextBox runat="server" ID="txtContent_P2" Width="90%" Height="70px" TextMode="MultiLine" CssClass="txtbox_Rpt2" ReadOnly="True"></asp:TextBox>

                                    </td>
                                    <td style="width: 1%"></td>
                                </tr>
                                <tr>
                                    <td style="width: 1%"></td>
                                    <td style="width: 98%" align="center">
                                        <asp:TextBox runat="server" ID="txtContent_P3" Width="90%" Height="50px" TextMode="MultiLine" CssClass="txtbox_Rpt2" ReadOnly="True"></asp:TextBox>

                                    </td>
                                    <td style="width: 1%"></td>
                                </tr>
                                <tr>
                                    <td style="width: 1%"></td>
                                    <td style="width: 98%" align="center">
                                        <asp:TextBox runat="server" ID="txtContent_P4" Width="90%" Height="50px" TextMode="MultiLine" CssClass="txtbox_Rpt2" ReadOnly="True"></asp:TextBox>

                                    </td>
                                    <td style="width: 1%"></td>
                                </tr>
                                <tr>
                                    <td style="width: 1%"></td>
                                    <td style="width: 98%" align="center">&nbsp;</td>
                                    <td style="width: 1%"></td>
                                </tr>
                                <tr>
                                    <td style="width: 1%"></td>
                                    <td style="width: 98%" align="center">&nbsp;</td>
                                    <td style="width: 1%"></td>
                                </tr>
                                <tr>
                                    <td style="width: 1%"></td>
                                    <td style="width: 98%" align="center">
                                        <asp:TextBox runat="server" ID="txtContent_P7" Width="90%" Height="50px" TextMode="MultiLine" CssClass="txtbox_Rpt2" ReadOnly="True"></asp:TextBox>

                                    </td>
                                    <td style="width: 1%"></td>
                                </tr>
                                <tr>
                                    <td style="width: 1%"></td>
                                    <td style="width: 98%" align="center" valign="top">
                                        <asp:TextBox runat="server" ID="txtContent_P8" Width="80%" Height="70px" TextMode="MultiLine" CssClass="txtbox_Rpt2" ReadOnly="True"></asp:TextBox>

                                    </td>
                                    <td style="width: 1%"></td>
                                </tr>
                                <tr>
                                    <td style="width: 1%"></td>
                                    <td style="width: 98%" align="center" valign="top">
                                        <div runat="server" id="div1">
                                        </div>

                                    </td>
                                    <td style="width: 1%"></td>
                                </tr>
                                <tr>
                                    <td style="width: 1%"></td>
                                    <td style="width: 98%" align="center" valign="top">
                                        <asp:TextBox runat="server" ID="txtContent_P10" Width="80%" Height="30px" TextMode="MultiLine" CssClass="txtbox_Rpt2" ReadOnly="True"></asp:TextBox>

                                    </td>
                                    <td style="width: 1%"></td>
                                </tr>
                                <tr>
                                    <td style="width: 1%"></td>
                                    <td style="width: 98%" align="center" valign="top">
                                        <asp:TextBox runat="server" ID="txtContent_P11" Width="80%" Height="30px" TextMode="MultiLine" CssClass="txtbox_Rpt2" ReadOnly="True"></asp:TextBox>

                                    </td>
                                    <td style="width: 1%"></td>
                                </tr>
                                <tr>
                                    <td style="width: 1%"></td>
                                    <td style="width: 98%" align="center"></td>
                                    <td style="width: 1%"></td>
                                </tr>
                                <tr>
                                    <td style="width: 1%"></td>
                                    <td style="width: 98%"></td>
                                    <td style="width: 1%"></td>
                                </tr>
                                <tr>
                                    <td style="width: 1%"></td>
                                    <td style="width: 98%" align="center">
                                        <table width="90%">
                                            <tr>
                                                <td style="width: 15%" class="column_RightBold">No. of BAC Signatories:</td>
                                                <td style="width: 35%" class="column_Left">
                                                    <asp:DropDownList AutoPostBack="True" runat="server" ID="selectionDD" Width="80%" CssClass="drpdownCSS">
                                                        <asp:ListItem Text="7" Value="7"></asp:ListItem>
                                                        <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 15%" class="column_RightBold">BAC Member :</td>
                                                <td style="width: 35%" class="column_Left">
                                                    <asp:DropDownList runat="server" ID="drpBAC4" Width="80%" CssClass="drpdownCSS"></asp:DropDownList>
                                                </td>
                                                <td style="width: 15%" class="column_RightBold">BAC Member :</td>
                                                <td style="width: 35%" class="column_Left">
                                                    <asp:DropDownList runat="server" ID="drpBAC5" Width="80%" CssClass="drpdownCSS"></asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 15%" class="column_RightBold">BAC Member :</td>
                                                <td style="width: 35%" class="column_Left">
                                                    <asp:DropDownList runat="server" ID="drpBAC1" Width="80%" CssClass="drpdownCSS"></asp:DropDownList>
                                                </td>
                                                <td style="width: 15%" class="column_RightBold">BAC Vice Chairman :</td>
                                                <td style="width: 35%" class="column_Left">
                                                    <asp:DropDownList runat="server" ID="drpBACVC" Width="80%" CssClass="drpdownCSS"></asp:DropDownList>
                                                </td>
                                            </tr>

                                            <tr>
                                                <td style="width: 15%" class="column_RightBold">BAC Member :</td>
                                                <td style="width: 35%" class="column_Left">
                                                    <asp:DropDownList runat="server" ID="drpBAC3" Width="80%" CssClass="drpdownCSS"></asp:DropDownList>
                                                </td>
                                                <td style="width: 15%" class="column_RightBold">BAC Chairman :</td>
                                                <td style="width: 35%" class="column_Left">
                                                    <asp:DropDownList runat="server" ID="drpBACC" Width="80%" CssClass="drpdownCSS"></asp:DropDownList>
                                                </td>
                                            </tr>

                                            <tr>
                                                <td style="width: 15%" class="column_RightBold">BAC Member :</td>
                                                <td style="width: 35%" class="column_Left">
                                                    <asp:DropDownList runat="server" ID="drpBAC2" Width="80%" CssClass="drpdownCSS"></asp:DropDownList>
                                                </td>

                                                <td style="width: 15%" class="column_RightBold">Approved By :</td>
                                                <td style="width: 35%" class="column_Left">
                                                    <asp:DropDownList runat="server" ID="drpApprovedBy" Width="80%" CssClass="drpdownCSS"></asp:DropDownList>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td style="width: 1%"></td>
                                </tr>
                            </table>

                        </td>
                        <td style="width: 1%; height: 907px;"></td>
                    </tr>

                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%; height: 10px"></td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%" align="center">
                            <asp:Button runat="server" ID="btnSaveBacReso" Width="150px" CssClass="CSButton" Text="Save / Preview" />
                            &nbsp;<asp:Button runat="server" ID="btnCancel" Width="150px" CssClass="CSButton" Text="Cancel" />
                        </td>
                        <td style="width: 1%"></td>
                    </tr>
                    <tr>
                        <td style="width: 1%"></td>
                        <td style="width: 98%; height: 10px"></td>
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



