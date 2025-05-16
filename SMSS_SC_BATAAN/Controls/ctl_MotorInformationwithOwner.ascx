<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctl_MotorInformationwithOwner.ascx.vb" Inherits="ctl_MotorInformationwithOwner" %>
<link href="../StyleSheet.css" rel="stylesheet" type="text/css" />
<fieldset  style="width: 789px; height:190px; font-style:italic" class="text"  >
<legend>Vehicle Information</legend>
<table style="width: 785px" class="text1">
    <tr>
        <td style="width: 133px; height: 12px;">
            Name:</td>
        <td style="width: 68px; height: 12px">
            <asp:Label ID="lblrevyear" runat="server" Width="188px" CssClass="text2"></asp:Label></td>
        <td style="width: 91px; height: 12px">
            Model:</td>
        <td style="width: 85px; height: 12px">
            <asp:Label ID="Label5" runat="server" Text="Label" Width="99px" CssClass="text2"></asp:Label></td>
        <td style="width: 116px; height: 12px">
            Wheels Quantity:</td>
        <td style="width: 71px; height: 12px">
            <asp:Label ID="lblbrgycode" runat="server" Width="75px" CssClass="text2"></asp:Label></td>
    </tr>
    <tr>
        <td style="width: 133px; height: 16px;">
            Plate No.:</td>
        <td style="width: 68px; height: 16px;">
            <asp:Label ID="lblstatus" runat="server" Width="188px" CssClass="text2"></asp:Label></td>
        <td style="width: 91px; height: 16px;">
            Chasis No:</td>
        <td style="width: 85px; height: 16px;">
            <asp:Label ID="Label2" runat="server" CssClass="text2" Text="Label" Width="99px"></asp:Label></td>
        <td style="width: 116px; height: 16px;">
            Gross Weight:</td>
        <td style="width: 71px; height: 16px;">
            <asp:Label ID="Label4" runat="server" CssClass="text2" Width="93px"></asp:Label></td>
    </tr>
    <tr>
        <td style="width: 133px; height: 12px;">
            Motor Name:</td>
        <td style="width: 68px; height: 12px" align="left">
            <asp:Label ID="Label1" runat="server" CssClass="text2" Width="188px"></asp:Label></td>
        <td style="width: 91px; height: 12px">
            Vehicle Color:</td>
        <td style="width: 85px; height: 12px" align="left">
            <asp:Label ID="Label3" runat="server" CssClass="text2" Text="Label" Width="98px"></asp:Label></td>
        <td style="width: 116px; height: 12px">
            Seat:</td>
        <td style="width: 71px; height: 12px" align="left">
            <asp:Label ID="Label6" runat="server" CssClass="text2"  Width="92px"></asp:Label></td>
    </tr>
       
    <tr>
        <td colspan="6" style="height: 16px; text-align: left">
        <hr />
            Vehicle Specification</td>
    </tr>
    <tr>
        <td colspan="3" rowspan="4">
            <asp:Label ID="Label7" runat="server" Height="65px" Width="350px"></asp:Label></td>
        <td colspan="3" rowspan="4">
            <asp:Label ID="Label8" runat="server" Height="65px" Width="350px"></asp:Label></td>
    </tr>
    <tr>
    </tr>
    <tr>
    </tr>
    <tr>
    </tr>
</table>


</fieldset>
<fieldset style="width:789px; font-style:italic" class="text">
<legend>Owner Information & Declaration</legend>
<table style="width: 786px; height: 83px" class="text1">
    <tr>
        <td style="width: 126px; height: 25px;">
            Vehicle Owner:</td>
        <td style="width: 311px; height: 25px">
            <asp:Label ID="lblvehicleowner" runat="server" CssClass="text2" Width="300px"></asp:Label></td>
        <td style="width: 119px; height: 25px">
            Benefecial User:</td>
        <td style="height: 25px">
            <asp:Label ID="lblbeneficialuser" runat="server" CssClass="text2" Width="200px"></asp:Label></td>
    </tr>
    <tr>
        <td style="width: 126px">
            &nbsp;Declared Name:</td>
        <td style="width: 311px">
            <asp:Label ID="lbldeclaredname" runat="server" CssClass="text2" Width="300px"></asp:Label></td>
        <td style="width: 119px">
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td style="width: 126px">
        </td>
        <td style="width: 311px">
        </td>
        <td style="width: 119px">
        </td>
        <td>
        </td>
    </tr>
</table>
</fieldset>
<br />
