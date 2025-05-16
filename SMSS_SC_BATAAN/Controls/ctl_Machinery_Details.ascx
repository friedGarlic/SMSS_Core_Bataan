<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctl_Machinery_Details.ascx.vb" Inherits="ctl_Machinery_Details" %>
<link href="../StyleSheet.css" rel="stylesheet" type="text/css" />
<%--<fieldset  style="width: 792px; height:194px; font-style:italic" class="text"  >
<legend>
Land Information</legend>
<table style="width: 790px" class="text1">--%>
    <table style="width: 784px " >
        <tr>
        
            <td style=" width:335px">
            <fieldset style=" width:330px; height:178px">
                  <legend class="text" style="font-style:italic">Description/Remarks</legend>
                <table style=" width:318px"class="text1">
                    <tr>
                        <td style="width: 142px;">
                        <asp:Label ID="lbldeascriptionRemarks" runat="server" Height="132px" Width="307px" CssClass="text2"></asp:Label>
                        </td>
                    </tr>
                </table>
            </fieldset>
        
            </td>
            <td style="width:433px; height:120px">
             <fieldset style=" width:431px;height:178px">
             <legend class="text" style="font-style:italic">Cerificate Details</legend>
                 <table  style=" width:410px"class="text1">
                     <tr>
                         <td style="width: 185px">
                             Mechanical Permit no.:</td>
                         <td colspan="2" style="height: 16px">
                             <asp:Label ID="lblpermitno" runat="server" Width="200px" CssClass="text2"></asp:Label></td>
                     </tr>
                     <tr>
                         <td style="width: 185px; height: 15px">
                             Certificate No.:</td>
                         <td style="height: 15px" colspan="2">
                             <asp:Label ID="lblcertificate" runat="server" Width="200px" CssClass="text2"></asp:Label></td>
                     </tr>
                     <tr>
                         <td style="width: 185px">
                             Date of Issuance:</td>
                         <td colspan="2">
                             <asp:Label ID="lblinsuannce" runat="server" Width="200px" CssClass="text2"></asp:Label></td>
                     </tr>
                     <tr>
                         <td style="width: 185px">
                             Expiration Date:</td>
                         <td colspan="2">
                             <asp:Label ID="lblexpirationdate" runat="server" Width="200px" CssClass="text2"></asp:Label></td>
                     </tr>
                     <tr>
                         <td style="width: 185px">
                             Date Inspected:</td>
                         <td colspan="2">
                             <asp:Label ID="lbldateinspected" runat="server" Width="200px" CssClass="text2"></asp:Label></td>
                     </tr>
                     <tr>
                         <td style="width: 185px">
                             Inspected By:</td>
                         <td colspan="2">
                             <asp:Label ID="lbinspected" runat="server" Width="200px" CssClass="text2"></asp:Label></td>
                     </tr>
                 </table>
            </fieldset>
            </td>
            
        </tr>
 
    </table>

