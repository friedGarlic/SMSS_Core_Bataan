<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctl_LandInformation_encode.ascx.vb" Inherits="ctl_LandInformation_encode" %>
<link href="../StyleSheet.css" rel="stylesheet" type="text/css" />
<fieldset  style="width: 793px; font-style:italic" class="text"  >
<legend>
Land Information</legend>
<table style="width: 786px; height:70px " class="text1">
    <tr><td style="width: 133px; height: 17px;">
            Rev Year:</td>
        <td style="width: 70px; height: 17px">
            <asp:TextBox ID="txtRevyer" runat="server" CausesValidation="True" CssClass="text2"
                Width="66px"></asp:TextBox></td>
        <td style="width: 87px; height: 17px">
            District code:</td>
        <td style="width: 78px; height: 17px">
            <asp:TextBox ID="txtDistrictcode" runat="server" CausesValidation="True" CssClass="text2"
                Width="100px"></asp:TextBox></td>
        <td style="width: 160px; height: 17px">
            Barangay Code:</td>
        <td style="width: 62px; height: 17px">
            <asp:TextBox ID="txtbrgycode" runat="server" CausesValidation="True" CssClass="text2"
                Width="66px"></asp:TextBox></td>
        <td style="height: 17px; width: 21px;">
            PIN:</td>
        <td style="height: 17px; width: 79px;">
            <asp:TextBox ID="txtPin" runat="server" CausesValidation="True" CssClass="text2"
                Width="183px"></asp:TextBox></td>
    </tr>
    <tr>
        <td style="width: 133px; height: 10px;">
            Status:</td>
        <td style="width: 70px; height: 10px;">
            <asp:TextBox ID="txtStat" runat="server" CausesValidation="True" CssClass="text2"
                Width="66px"></asp:TextBox></td>
        <td style="width: 87px; height: 10px;">
            Transaction:</td>
        <td style="width: 78px; height: 10px;">
            <asp:TextBox ID="txttransaction" runat="server" CausesValidation="True" CssClass="text2"
                Width="100px"></asp:TextBox></td>
        <td style="width: 160px; height: 10px;">
            Transaction Code:</td>
        <td style="width: 62px; height: 10px;">
            <asp:TextBox ID="txttransactioncode" runat="server" CausesValidation="True" CssClass="text2"
                Width="66px"></asp:TextBox></td>
        <td style="width: 21px; height: 10px;">
        </td>
        <td style="width: 79px; height: 10px">
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
        <td style="width: 82px; height: 7px;">
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
            <asp:TextBox ID="txtUnit" runat="server" CausesValidation="True" CssClass="text2"
                Width="159px"></asp:TextBox></td>
        <td colspan="2" style="height: 16px">
            Base Market Value:</td>
        <td style="width: 73px; height: 16px;">
            <asp:TextBox ID="txtbasemarketvalue" runat="server" CausesValidation="True" CssClass="text2"
                Width="155px"></asp:TextBox></td>
        <td style="width: 95px; height: 16px;">
            Kind:</td>
        <td style="width: 79px; height: 16px;">
            <asp:TextBox ID="txtkind" runat="server" CausesValidation="True" CssClass="text2"
                Width="109px"></asp:TextBox></td>
    </tr>
    <tr>
        <td style="width: 209px; height: 16px">
            Unit value:</td>
        <td colspan="2" style="height: 16px">
            <asp:TextBox ID="txtUnitvalue" runat="server" CausesValidation="True" CssClass="text2"
                Width="159px"></asp:TextBox></td>
        <td style="height: 16px" colspan="2">
            Taxable:</td>
        <td style="width: 73px; height: 16px">
            <asp:TextBox ID="txttaxable" runat="server" CausesValidation="True" CssClass="text2"
                Width="155px"></asp:TextBox></td>
        <td style="height: 16px; width: 95px;">
            Sort Order:</td>
        <td style="height: 16px; width: 79px;">
            <asp:TextBox ID="txtsortorder" runat="server" CausesValidation="True" CssClass="text2"
                Width="109px"></asp:TextBox></td>
    </tr>
    <tr>
        <td style="width: 209px; height: 16px;">
            </td>
        <td colspan="2" style="height: 16px">
            </td>
        <td colspan="2" style="height: 16px">
            Adjustments:</td>
        <td style="width: 73px; height: 16px;">
            <asp:TextBox ID="txtadjustment" runat="server" CausesValidation="True" CssClass="text2"
                Width="155px"></asp:TextBox></td>
        <td style="width: 95px; height: 16px;">
        </td>
        <td style="width: 79px; height: 16px;">
        </td>
    </tr>
</table>


</fieldset>
