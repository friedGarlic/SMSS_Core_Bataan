<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctl_Owner_Information.ascx.vb" Inherits="ctl_Owner_Information" %>
<link href="../StyleSheet.css" rel="stylesheet" type="text/css" />
<%--<fieldset  style="width: 792px; height:194px; font-style:italic" class="text"  >
<legend>
Land Information</legend>
<table style="width: 790px" class="text1">--%>
    <table style="width: 790px " cellpadding="0" cellspacing="0" >
        <tr>
        
            <td style=" width:383px">
            <fieldset style=" width:380px;height:133px;border-right:#2977dc ; border-left:#2977dc ; border-top:#2977dc ; border-bottom:#2977dc;">
                  <legend class="text" style="font-style:italic">Owner Information</legend>
                <table style=" width:379px;"class="text1">
                    <tr>
                        <td style="width: 142px; height: 16px">
                            Building information:</td>
                        <td colspan="2" style="height: 16px">
                            <asp:Label ID="lblbuildingInfo" runat="server" Width="218px" CssClass="text2"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="width: 142px">
                            Building&nbsp; Location:</td>
                        <td colspan="2" rowspan="2">
                            <asp:Label ID="lblbuildingLocation" runat="server" Height="28px" Width="218px" CssClass="text2"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="width: 142px; height: 16px;">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 142px">
                            RPTIN:</td>
                        <td colspan="2">
                            <asp:Label ID="lblrptin" runat="server" Width="218px" CssClass="text2"></asp:Label></td>
                    </tr>
                </table>
            </fieldset>
            </td>
            <td style="width:404px">
             <fieldset style=" width:403px;height:133px ;border-right:#2977dc ; border-left:#2977dc ; border-top:#2977dc ; border-bottom:#2977dc;">
             <legend class="text" style="font-style:italic">Owner Declaration</legend>
                 <table  style=" width:388px"class="text1">
                     <tr>
                         <td style="width: 202px">
                             Declared Name:</td>
                         <td colspan="2" style="width: 297px">
                             <asp:Label ID="lbldecalrename" runat="server" Width="264px" CssClass="text2"></asp:Label></td>
                     </tr>
                     <tr>
                         <td style="width: 202px; height: 15px">
                             Beneficial User:</td>
                         <td style="height: 15px; width: 297px;" colspan="2">
                             <asp:Label ID="lblbeneficiary" runat="server" Width="264px" CssClass="text2"></asp:Label></td>
                     </tr>
                     <tr>
                         <td style="width: 202px">
                             Administrator:</td>
                         <td colspan="2" style="width: 297px">
                             <asp:Label ID="lbladministrator" runat="server" Width="264px" CssClass="text2"></asp:Label></td>
                     </tr>
                     <tr>
                         <td style="width: 202px; height: 18px;">
                             Address:</td>
                         <td colspan="2" style="width: 297px; height: 18px">
                             <asp:Label ID="lbladminitratorAddress" runat="server" Width="264px" CssClass="text2"></asp:Label></td>
                     </tr>
                 </table>
            </fieldset>
            </td>
            
        </tr>
 
    </table>

