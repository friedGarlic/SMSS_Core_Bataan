<%@ Control Language="VB" AutoEventWireup="false" CodeFile="clt_image.ascx.vb" Inherits="clt_image" %>
<link href="../StyleSheet.css" rel="stylesheet" type="text/css" />
<fieldset style="width: 202px;height: 330px">
<table style="width: 200px;height: 295px" >
    <tr>
        <td style="height: 180px; width: 196px;" rowspan="2">
            <br />
        </td>
    </tr>
    <tr>
    </tr>
    <tr>
        <td rowspan="1" style="height: 84px; width: 196px;">
        <fieldset style="height: 90px;width: 186px" >
            <table class="text1" style="width: 184px; height: 85px;">
                <tr>
                    <td style="height: 19px; width: 87px;">
                        Date Taken:</td>
                    <td style="height: 19px" colspan="2">
                        <asp:Label ID="lbldatetake" runat="server" Width="86px" CssClass="text2"></asp:Label></td>
                </tr>
                <tr>
                    <td style="width: 87px">
                        Uploadedby:</td>
                    <td colspan="2">
                        <asp:Label ID="lblupload" runat="server" Width="86px" CssClass="text2" Height="38px"></asp:Label></td>
                </tr>
                <tr>
                    <td style="width: 87px">
                        Position:</td>
                    <td colspan="2">
                        <asp:Label ID="lblposition" runat="server" Width="86px" CssClass="text2"></asp:Label></td>
                </tr>
            </table>
            </fieldset>
        </td>
    </tr>
    <tr>
        <td style="height: 6px; width: 196px;">
        </td>
    </tr>
</table>

</fieldset>