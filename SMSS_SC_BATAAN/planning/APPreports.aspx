<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" EnableEventValidation="false"
CodeFile="APPreports.aspx.vb" Inherits="Planning_APP_Reports" title="Annual Procurement Plan Report" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<script runat="server">

'Protected Sub ddDepartment_SelectedIndexChanged(sender As Object, e As EventArgs)

'End Sub
</script>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<asp:UpdatePanel id="UpdatePanel1" runat="server">   
<contenttemplate>
    <table style="width: 100%">
        <tbody>
            <tr>
                <td style="width: 10px"></td>
                <td style="width: 1000px" align="center"></td>
            </tr>
            <tr>
                <td style="width: 10px"></td>
                <td style="width: 1000px" class="PageTitle" align="center">ANNUAL PROCUREMENT PLAN</td>
            </tr>
            <tr>
                <td style="width: 10px"></td>
                <td style="width: 1000px" align="center"></td>
            </tr>
            <tr>
                <td style="width: 10px"></td>
                <td style="width: 1000px" class="text5" align="center">
                    <asp:RadioButtonList ID="rbChoice" runat="server" Width="300px" RepeatDirection="Horizontal" OnSelectedIndexChanged="rbChoice_SelectedIndexChanged" CssClass="text5" AutoPostBack="True">
                        <asp:ListItem Value="1">LGU - Consolidated</asp:ListItem>
                        <asp:ListItem Value="2" Selected="True">Per Department</asp:ListItem>
                    </asp:RadioButtonList></td>
            </tr>
            <tr>
                <td style="width: 10px"></td>
                <td style="width: 1000px" align="center">
                    <asp:MultiView ID="mvAPP" runat="server">
                        <asp:View ID="vwLGU" runat="server">
                            <table style="width: 100%">
                                <tbody>
                                    <tr>
                                        <td style="width: 20%" class="column_RightBold">Report Format :</td>
                                        <td style="width: 80%" class="text5">
                                            <asp:RadioButtonList ID="rbLGU" runat="server" Width="200px" RepeatDirection="Horizontal" CssClass="text5" AutoPostBack="True">
                                                <asp:ListItem Value="1">GPPB </asp:ListItem>
                                                <asp:ListItem Value="2">DILG</asp:ListItem>
                                            </asp:RadioButtonList></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 20%" class="column_RightBold">APP Year :</td>
                                        <td style="width: 80%" class="text5">
                                            <asp:DropDownList ID="ddYear" runat="server" Width="150px" CssClass="txtboxinspection" AutoPostBack="True" Enabled="False">
                                            </asp:DropDownList></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 20%" class="column_RightBold"></td>
                                        <td style="width: 80%" class="text5"></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 20%" class="column_RightBold"></td>
                                        <td style="width: 80%" class="text5">
                                            <asp:Button ID="btnPreview" runat="server" Width="200px" Enabled="False" Text="PREVIEW" CssClass="CSButton"></asp:Button>
                                            <asp:Label ID="lblNotification2" runat="server" Font-Bold="True" ForeColor="Red" Font-Size="11pt" Font-Names="Calibri" Text="**NOTE:  Complete Signatories." Visible="False" Font-Italic="True"></asp:Label></td>
                                    </tr>
                                </tbody>
                            </table>
                        </asp:View>
                        <asp:View ID="vwDepartment" runat="server">
                            <table style="width: 100%">
                                <tbody>
                                    <tr>
                                        <td style="width: 20%" class="column_RightBold">Report Format :</td>
                                        <td style="width: 80%" class="text5">
                                            <asp:RadioButtonList ID="rbPerDept" runat="server" Width="200px" RepeatDirection="Horizontal" CssClass="text5" AutoPostBack="True">
                                                <asp:ListItem Value="1">GPPB </asp:ListItem>
                                                <asp:ListItem Value="2">DILG</asp:ListItem>
                                            </asp:RadioButtonList></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 20%" class="column_RightBold">Year :</td>
                                        <td style="width: 80%" class="text5">
                                            <asp:DropDownList ID="ddDeptYear" runat="server" Width="150px" CssClass="txtboxinspection" AutoPostBack="True" Enabled="False">
                                            </asp:DropDownList></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 20%" class="column_RightBold">Department :</td>
                                        <td style="width: 80%" class="text5">
                                            <asp:DropDownList ID="ddDepartment" runat="server" Width="500px" AutoPostBack="True" Enabled="False" OnSelectedIndexChanged="ddDepartment_SelectedIndexChanged">
                                            </asp:DropDownList></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 20%" class="column_RightBold">Function :</td>
                                        <td style="width: 80%" class="text5">
                                            <asp:DropDownList ID="ddFunction" runat="server" Width="500px" AutoPostBack="True" Enabled="False">
                                            </asp:DropDownList></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 20%" class="column_RightBold"></td>
                                        <td style="width: 80%" class="text5">
                                            <asp:CheckBox ID="cbSupplemental" runat="server" Font-Bold="True" Font-Names="Arial" Text="Supplemental"></asp:CheckBox></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 20%" class="column_RightBold"></td>
                                        <td style="width: 80%" class="text5">
                                            <asp:Button ID="btnAPPDept" runat="server" Width="200px" Enabled="False" Text="PREVIEW" CssClass="CSButton"></asp:Button>
                                            <asp:Button ID="btnConti" runat="server" Width="200px" Font-Size="9pt" Enabled="False" Text="PREVIEW APP CONTINGENCY" Visible="False"></asp:Button>
                                            <asp:Label ID="lblNotification" runat="server" Font-Bold="True" ForeColor="Red" Font-Size="11pt" Font-Names="Calibri" Text="**NOTE:  Complete Signatories." Visible="False" Font-Italic="True"></asp:Label></td>
                                    </tr>
                                </tbody>
                            </table>
                        </asp:View>
                    </asp:MultiView></td>
            </tr>
            <tr>
                <td style="width: 10px"></td>
                <td style="width: 1000px" class="DivTitle" align="center">SIGNATORIES</td>
            </tr>
            <tr>
                <td style="width: 10px"></td>
                <td style="width: 1000px" align="center">
                    <table style="width: 100%">
                        <tbody>
                            <%-- REVISED CODE 02/21/2025 --%>
                                    <tr>
                                        <td style="width: 15%" class="column_RightBold">BAC Member 1 :</td>
                                        <td style="width: 35%" class="column_Left">
                                            <asp:DropDownList ID="ddBAC1" runat="server" Width="90%" CssClass="drpdownCSS" Enabled="False" AutoPostBack="True"></asp:DropDownList>
                                        </td>
                                        <td style="width: 15%" class="column_RightBold">BAC Vice Chairman :</td>
                                        <td style="width: 35%" class="column_Left">
                                            <asp:DropDownList ID="ddBACVC" runat="server" Width="90%" CssClass="drpdownCSS" Enabled="False" AutoPostBack="True"></asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 15%" class="column_RightBold">BAC Member 2 :</td>
                                        <td style="width: 35%" class="column_Left">
                                            <asp:DropDownList ID="ddBAC2" runat="server" Width="90%" CssClass="drpdownCSS" Enabled="False" AutoPostBack="True"></asp:DropDownList>
                                        </td>
                                        <td style="width: 15%" class="column_RightBold">BAC Chairman :</td>
                                        <td style="width: 35%" class="column_Left">
                                            <asp:DropDownList ID="ddBACC" runat="server" Width="90%" CssClass="drpdownCSS" Enabled="False" AutoPostBack="True"></asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 15%" class="column_RightBold">BAC Member 3 :</td>
                                        <td style="width: 35%" class="column_Left">
                                            <asp:DropDownList ID="ddBAC3" runat="server" Width="90%" CssClass="drpdownCSS" Enabled="False" AutoPostBack="True"></asp:DropDownList>
                                        </td>
                                        <td style="width: 15%" class="column_RightBold">Prepared By :</td>
                                        <td style="width: 35%" class="column_Left">
                                            <asp:DropDownList ID="ddPreparedBy" runat="server" Width="90%" CssClass="drpdownCSS" Enabled="False" AutoPostBack="True"></asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 15%" class="column_RightBold">BAC Member 4 :</td>
                                        <td style="width: 35%" class="column_Left">
                                            <asp:DropDownList ID="ddBAC4" runat="server" Width="90%" CssClass="drpdownCSS" Enabled="False" AutoPostBack="True"></asp:DropDownList>
                                        </td>
                                        <td style="width: 15%" class="column_RightBold">Approved By :</td>
                                        <td style="width: 35%" class="column_Left">
                                            <asp:DropDownList ID="ddApprovedBy" runat="server" Width="90%" CssClass="drpdownCSS" Enabled="False" AutoPostBack="True"></asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 15%" class="column_RightBold">BAC Member 5 :</td>
                                        <td style="width: 35%" class="column_Left">
                                            <asp:DropDownList ID="ddBAC5" runat="server" Width="90%" CssClass="drpdownCSS" Enabled="False" AutoPostBack="True"></asp:DropDownList>
                                        </td>
                                        <td style="width: 15%" class="column_RightBold"></td>
                                        <td style="width: 35%" class="column_Left"></td>
                                    </tr>
                            <%-- END HERE --%>
                        </tbody>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="width: 10px"></td>
                <td style="width: 1000px" align="center"></td>
            </tr>
            <tr>
                <td style="width: 10px"></td>
                <td style="width: 1000px" align="center"></td>
            </tr>
        </tbody>
    </table>
</contenttemplate>
</asp:UpdatePanel>
</asp:Content>

