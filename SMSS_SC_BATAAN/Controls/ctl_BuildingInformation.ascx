<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctl_BuildingInformation.ascx.vb" Inherits="ctl_BuildingInformation" %>
<link href="../StyleSheet.css" rel="stylesheet" type="text/css" />
<fieldset  style="width: 793px; height:191px; font-style:italic;;border-right:#2977dc ; border-left:#2977dc ; border-top:#2977dc ; border-bottom:#2977dc;" class="text"  >
<legend>
Land Information</legend>
<table style="width: 780px" class="text1" cellpadding="0" cellspacing="0">
    <tr>
        <td style="width: 133px; height: 16px;">
            Rev Year:</td>
        <td style="width: 70px; height: 16px">
            <asp:Label ID="lblrevyear" runat="server" Width="66px" CssClass="text2"></asp:Label></td>
        <td style="width: 87px; height: 16px">
            District code:</td>
        <td style="width: 85px; height: 16px">
            <asp:Label ID="lbldistrict" runat="server" Width="80px" CssClass="text2"></asp:Label></td>
        <td style="width: 136px; height: 16px">
            Barangay Code:</td>
        <td style="width: 36px; height: 16px">
            <asp:Label ID="lblbcd"  runat="server" CssClass="text2"></asp:Label></td>
        <td style="height: 16px; width: 29px;">
            &nbsp;PIN:</td>
        <td style="height: 16px; width: 80px;">
            <asp:Label ID="lblpin" runat="server" Width="200px" CssClass="text2"></asp:Label></td>
    </tr>
    <tr>
        <td style="width: 133px; height: 16px;">
            Status:</td>
        <td style="width: 70px; height: 16px;">
            <asp:Label ID="lblstatus" runat="server" Width="66px" CssClass="text2"></asp:Label></td>
        <td style="width: 87px; height: 16px;">
            Transaction:</td>
        <td style="width: 85px; height: 16px;">
            <asp:Label ID="lbltransact" runat="server" Width="80px" CssClass="text2"></asp:Label></td>
        <td style="width: 136px; height: 16px;">
            Transaction Code:</td>
        <td style="width: 36px; height: 16px;">
            <asp:Label ID="lbltrcd" runat="server" CssClass="text2" EnableTheming="False"></asp:Label></td>
        <td style="width: 29px; height: 16px;">
        </td>
        <td style="height: 16px; width: 80px;">
        </td>
    </tr>
    <tr>
        <td style="width: 133px; height: 12px;">
        </td>
        <td style="width: 70px; height: 12px">
        </td>
        <td style="width: 87px; height: 12px">
        </td>
        <td style="width: 85px; height: 12px">
        </td>
        <td style="width: 136px; height: 12px">
        </td>
        <td style="width: 36px; height: 12px">
        </td>
        <td style="height: 12px; width: 29px;">
        </td>
        <td style="height: 12px; width: 80px;">
        </td>
    </tr>
    </table>
    <hr />
    <table style="width: 780px" class="text1">
       
    <tr>
        <td colspan="8" style="height: 16px; text-align: left">
                   Building Information</td>
    </tr>
    <tr>
        <td style="width: 133px">
        </td>
        <td style="width: 70px">
        </td>
        <td style="width: 87px">
        </td>
        <td style="width: 85px">
        </td>
        <td style="width: 119px">
        </td>
        <td style="width: 65px">
        </td>
        <td style="width: 79px">
        </td>
        <td style="width: 79px">
        </td>
    </tr>
    <tr>
        <td style="width: 133px; height: 16px;">
            Project:</td>
        <td colspan="2" style="height: 16px">
            <asp:Label ID="lblprojectcost" runat="server" Width="157px" CssClass="text2"></asp:Label></td>
        <td style="width: 85px; height: 16px;">
            Height:</td>
        <td style="width: 119px; height: 16px;">
            <asp:Label ID="lblheight" runat="server" Width="120px" CssClass="text2"></asp:Label></td>
        <td style="width: 65px; height: 16px;">
        </td>
        <td style="width: 79px; height: 16px;">
            Started:</td>
        <td style="width: 79px; height: 16px;">
            <asp:Label ID="lblstarted" runat="server" Width="85px" CssClass="text2"></asp:Label></td>
    </tr>
    <tr>
        <td style="width: 133px; height: 16px">
            Total flr Area:</td>
        <td colspan="2" style="height: 16px">
            <asp:Label ID="lbltotalflor" runat="server" Width="157px" CssClass="text2"></asp:Label></td>
        <td style="width: 85px; height: 16px">
            No. of floors:</td>
        <td style="width: 119px; height: 16px">
            <asp:Label ID="lblfloors" runat="server" Width="120px" CssClass="text2"></asp:Label></td>
        <td style="width: 65px; height: 16px">
        </td>
        <td style="height: 16px; width: 79px;">
            Completed:</td>
        <td style="height: 16px; width: 79px;">
            <asp:Label ID="lblcompleted" runat="server" Width="80px" CssClass="text2"></asp:Label></td>
    </tr>
    <tr>
        <td style="width: 133px">
            Ave Area per flr:</td>
        <td colspan="2">
            <asp:Label ID="lblavearea" runat="server" Width="157px" CssClass="text2"></asp:Label></td>
        <td style="width: 85px">
            Open Space:</td>
        <td style="width: 119px">
            <asp:Label ID="lblopenspace" runat="server" Width="120px" CssClass="text2"></asp:Label></td>
        <td style="width: 65px">
        </td>
        <td style="width: 79px">
        </td>
        <td style="width: 79px">
        </td>
    </tr>
    <tr>
        <td style="width: 133px">
            Cost Per Sq.M:</td>
        <td colspan="2">
            <asp:Label ID="lblcost" runat="server" Width="157px" CssClass="text2"></asp:Label></td>
        <td style="width: 85px">
        </td>
        <td style="width: 119px">
        </td>
        <td style="width: 65px">
        </td>
        <td style="width: 79px">
        </td>
        <td style="width: 79px">
        </td>
    </tr>
</table>


</fieldset>
