<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctl_EquipmentInformation.ascx.vb" Inherits="ctl_EquipmentInformation" %>
<link href="../StyleSheet.css" rel="stylesheet" type="text/css" />
<fieldset  style="width: 782px;  font-style:italic" class="text"  >
<legend>Equipment Information</legend>
<table style="width: 780px;height: 320px" class="text1">
    <tr>
        <td style="width: 133px; height: 19px;">
            Name:</td>
        <td colspan="3" style="height: 19px; width: 272px;">
            <asp:Label ID="lblName" runat="server" CssClass="text2" Width="236px"></asp:Label></td>
        <td style="width: 128px; height: 19px">
            Dimesion:</td>
        <td style="height: 19px" colspan="3">
            <asp:Label ID="lblDimesion" runat="server" Width="236px" CssClass="text2"></asp:Label></td>
    </tr>
    <tr>
        <td style="width: 133px; height: 16px;">
            Description:</td>
        <td colspan="3" rowspan="2" style="width: 272px">
            <asp:Label ID="lblDescription" runat="server" Width="236px" CssClass="text2" Height="26px"></asp:Label></td>
        <td style="width: 128px; height: 16px;">
            Area Capacity:</td>
        <td colspan="3" style="height: 16px">
            <asp:Label ID="lblareacapacity" runat="server" CssClass="text2" Width="236px"></asp:Label></td>
    </tr>
    <tr>
        <td style="width: 133px; height: 10px;">
        </td>
        <td style="width: 128px; height: 10px">
            Model:</td>
        <td style="height: 10px" colspan="3">
            <asp:Label ID="lblmodel" runat="server" CssClass="text2" Width="236px"></asp:Label></td>
    </tr>
    <tr>
        <td style="width: 133px; height: 12px">
            Power input:</td>
        <td colspan="3" style="height: 12px; width: 272px;">
            <asp:Label ID="lblpowerinput" runat="server" CssClass="text2" Width="236px"></asp:Label></td>
        <td style="width: 128px; height: 12px">
        </td>
        <td style="width: 71px; height: 12px">
        </td>
        <td style="width: 72px; height: 12px">
        </td>
        <td style="width: 79px; height: 12px">
        </td>
    </tr>
       
    <tr>
        <td colspan="8" style="height: 16px; text-align: left">
        <hr />
            Equipment Specification</td>
    </tr>
    <tr>
        <td style="width: 133px; height: 6px;">
        </td>
        <td style="width: 272px;" colspan="3" rowspan="5">
            <asp:Label ID="lblequipmentscep1" runat="server" CssClass="text2" Height="148px"
                Width="257px"></asp:Label></td>
        <td style="width: 128px; height: 6px;">
        </td>
        <td colspan="3" rowspan="5">
            <asp:Label ID="lblequipmentscep2" runat="server" CssClass="text2" Height="146px"
                Width="257px"></asp:Label></td>
    </tr>
    <tr>
        <td style="width: 133px; height: 16px;">
            </td>
        <td style="width: 128px; height: 16px;">
            </td>
    </tr>
    <tr>
        <td style="width: 133px; height: 16px">
            </td>
        <td style="width: 128px; height: 16px">
            </td>
    </tr>
    <tr>
        <td style="width: 133px; height: 9px;">
            </td>
        <td style="width: 128px; height: 9px;">
            </td>
    </tr>
    <tr>
        <td style="width: 133px">
            </td>
        <td style="width: 128px">
        </td>
    </tr>
</table>


</fieldset>
