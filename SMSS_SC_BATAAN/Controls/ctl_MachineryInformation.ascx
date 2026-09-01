<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctl_MachineryInformation.ascx.vb" Inherits="ctl_MachineryInformation" %>
<link href="../StyleSheet.css" rel="stylesheet" type="text/css" />
<fieldset  style="width: 782px;height:144px; font-style:italic" class="text"  >
<legend>
Machinery Specification</legend>

    <table style="width: 785px" class="text1">
        <tr>
            <td style="width: 143px; height: 16px">
                Brand/Model:</td>
            <td style="width: 150px; height: 16px">
                <asp:Label ID="lblmodel" runat="server" Width="150px" CssClass="text2"></asp:Label></td>
            <td style="width: 158px; height: 16px">
                Unit:</td>
            <td style="width: 158px; height: 16px">
                <asp:Label ID="lblunit" runat="server" Width="180px" CssClass="text2"></asp:Label></td>
            <td style="height: 16px">
            </td>
        </tr>
        <tr>
            <td style="width: 143px; height: 18px">
                Type:</td>
            <td style="width: 150px; height: 18px">
                <asp:Label ID="lbltype" runat="server" Width="150px" CssClass="text2"></asp:Label></td>
            <td style="width: 158px; height: 18px">
                Working Load:</td>
            <td style="width: 158px; height: 18px">
                <asp:Label ID="lblworkingload" runat="server" Width="180px" CssClass="text2"></asp:Label></td>
            <td style="height: 18px">
            </td>
        </tr>
        <tr>
            <td style="width: 143px">
                Location:</td>
            <td style="width: 150px">
                <asp:Label ID="lbllocation" runat="server" Width="150px" CssClass="text2"></asp:Label></td>
            <td style="width: 158px">
                Rated Speed</td>
            <td style="width: 158px">
                <asp:Label ID="lblratedspeed" runat="server" Width="180px" CssClass="text2"></asp:Label></td>
            <td>
            </td>
        </tr>
        <tr>
            <td style="width: 143px; height: 16px">
                No. of Passenger:</td>
            <td style="width: 150px; height: 16px">
                <asp:Label ID="lblnopassenger" runat="server" Width="150px" CssClass="text2"></asp:Label></td>
            <td style="width: 158px; height: 16px">
                Car Dimension:</td>
            <td style="width: 158px; height: 16px">
                <asp:Label ID="lblcardimesion" runat="server" Width="180px" CssClass="text2"></asp:Label></td>
            <td style="height: 16px">
            </td>
        </tr>
        <tr>
            <td style="width: 143px; height: 16px">
                Service Floor:</td>
            <td style="width: 150px; height: 16px">
                <asp:Label ID="lblservicefloor" runat="server" Width="150px" CssClass="text2"></asp:Label></td>
            <td style="width: 158px; height: 16px">
            </td>
            <td style="width: 158px; height: 16px">
            </td>
            <td style="height: 16px">
            </td>
        </tr>
        <tr>
            <td style="width: 143px; height: 16px">
            </td>
            <td style="width: 150px; height: 16px">
            </td>
            <td style="width: 158px; height: 16px">
            </td>
            <td style="width: 158px; height: 16px">
            </td>
            <td style="height: 16px">
            </td>
        </tr>
    </table>


</fieldset>
