<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctl_LandInformation.ascx.vb" Inherits="ctl_LandInformation" %>
<link href="../StyleSheet.css" rel="stylesheet" type="text/css" />
<fieldset  style="width: 793px; font-style:italic" class="text"  >
<legend>
Land Information</legend>
<table style="width: 786px; height:70px " class="text1">
    <tr><td style="width: 133px; height: 18px;">
            Rev Year:</td>
        <td style="width: 70px; height: 18px">
            <asp:Label ID="lblrevyear" runat="server" Width="66px" CssClass="text2"></asp:Label></td>
        <td style="width: 87px; height: 18px">
            District code:</td>
        <td style="width: 78px; height: 18px">
            <asp:Label ID="lbldistrict" runat="server" Width="100px" CssClass="text2"></asp:Label></td>
        <td style="width: 160px; height: 18px">
            Barangay Code:</td>
        <td style="width: 62px; height: 18px">
            <asp:Label ID="lblbcd" runat="server" Width="66px" CssClass="text2"></asp:Label></td>
        <td style="height: 18px; width: 21px;">
            PIN:</td>
        <td style="height: 18px; width: 79px;">
            <asp:Label ID="lblpin" runat="server" Width="184px" CssClass="text2"></asp:Label></td>
    </tr>
    <tr>
        <td style="width: 133px; height: 12px;">
            Status:</td>
        <td style="width: 70px; height: 12px;">
            <asp:Label ID="lblstatus" runat="server" Width="66px" CssClass="text2"></asp:Label></td>
        <td style="width: 87px; height: 12px;">
            Transaction:</td>
        <td style="width: 78px; height: 12px;">
            <asp:Label ID="lbltransact" runat="server" Width="100px" CssClass="text2"></asp:Label></td>
        <td style="width: 160px; height: 12px;">
            Transaction Code:</td>
        <td style="width: 62px; height: 12px;">
            <asp:Label ID="lbltrcd" runat="server" Width="66px" CssClass="text2"></asp:Label></td>
        <td style="width: 21px; height: 12px;">
        </td>
        <td style="width: 79px; height: 12px">
        </td>
    </tr>
    </table>
    <table style="width: 786px; height:80px " class="text1">
       
    <tr>
        <td colspan="8" style="height: 16px; text-align: left">
        <hr />
            Land Valuation</td>
    </tr>
    <tr>
        <td style="width: 209px; height: 7px;">
        </td>
        <td style="width: 70px; height: 7px;">
        </td>
        <td style="width: 100px; height: 7px;">
        </td>
        <td style="width: 85px; height: 7px;">
        </td>
        <td style="width: 66px; height: 7px;">
        </td>
        <td style="width: 73px; height: 7px;">
        </td>
        <td style="width: 95px; height: 7px;">
        </td>
        <td style="width: 79px; height: 7px;">
        </td>
    </tr>
    <tr>
        <td style="width: 209px; height: 16px;">
            Unit:</td>
        <td colspan="2" style="height: 16px">
            <asp:Label ID="lblunit" runat="server" Width="157px" CssClass="text2"></asp:Label></td>
        <td colspan="2" style="height: 16px">
            Base Market Value:</td>
        <td style="width: 73px; height: 16px;">
            <asp:Label ID="lblBMV" runat="server" Width="158px" CssClass="text2"></asp:Label></td>
        <td style="width: 95px; height: 16px;">
            Kind:</td>
        <td style="width: 79px; height: 16px;">
            <asp:Label ID="lblkind" runat="server" Width="109px" CssClass="text2"></asp:Label></td>
    </tr>
    <tr>
        <td style="width: 209px; height: 16px">
            Unit value:</td>
        <td colspan="2" style="height: 16px">
            <asp:Label ID="lblunitvalue" runat="server" Width="157px" CssClass="text2"></asp:Label></td>
        <td style="height: 16px" colspan="2">
            Taxable:</td>
        <td style="width: 73px; height: 16px">
            <asp:Label ID="lbltaxable" runat="server" Width="158px" CssClass="text2"></asp:Label></td>
        <td style="height: 16px; width: 95px;">
            Sot Order:</td>
        <td style="height: 16px; width: 79px;">
            <asp:Label ID="lblSO" runat="server" Width="114px" CssClass="text2"></asp:Label></td>
    </tr>
    <tr>
        <td style="width: 209px; height: 16px;">
            </td>
        <td colspan="2" style="height: 16px">
            </td>
        <td colspan="2" style="height: 16px">
            Adjustments:</td>
        <td style="width: 73px; height: 16px;">
            <asp:Label ID="lbladjustment" runat="server" Width="154px" CssClass="text2"></asp:Label></td>
        <td style="width: 95px; height: 16px;">
        </td>
        <td style="width: 79px; height: 16px;">
        </td>
    </tr>
</table>


</fieldset>
