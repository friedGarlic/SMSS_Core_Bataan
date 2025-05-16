<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctl_Scanned_Documents.ascx.vb"  Inherits="ctl_Scanned_Documents" %>
<link href="../StyleSheet.css" rel="stylesheet" type="text/css" />
<table style="width:940px ; height:390px" class="text1">
    <tr>
       <td style="width:600px; height:380px">
       <fieldset style="width:595px; height:378px">
       <legend>Document/s Submitted</legend>
           <table style="width:590px; height:374px" class="text">
               <tr>
                   <td colspan="5" style="height: 49px" align="center">
                       <asp:Button ID="btnbrowse" runat="server" Height="29px" Text="Browse" Width="147px" /></td>
               </tr>
               <tr>
                   <td style="width: 117px; height: 51px">
                       Document name:</td>
                   <td colspan="2" style="height: 51px">
                       <asp:Label ID="Label1" runat="server" Text="Label" Width="188px"></asp:Label></td>
                   <td style="width: 104px; height: 51px">
                       Validated By:</td>
                   <td style="height: 51px">
                       <asp:Label ID="Label3" runat="server" Text="Label" Width="150px"></asp:Label></td>
               </tr>
               <tr>
                   <td style="width: 117px">
                       Property Name:</td>
                   <td colspan="2">
                       <asp:Label ID="Label2" runat="server" Text="Label" Width="188px"></asp:Label></td>
                   <td style="width: 104px">
                       Date Validated:</td>
                   <td>
                       <asp:Label ID="Label4" runat="server" Text="Label" Width="150px"></asp:Label></td>
               </tr>
               <tr>
                   <td style="width: 117px; height: 36px;">
                   </td>
                   <td style="width: 165px; height: 36px;">
                   </td>
                   <td style="height: 36px;" colspan="2"><asp:Button ID="btnAddDoc" runat="server" Height="29px" Text="Add Document" Width="147px" /></td>
                   <td style="height: 36px"><asp:Button ID="btncancel" runat="server" Height="29px" Text="Cancel" Width="147px" /></td>
               </tr>
               <tr>
                   <td style="height: 165px;" colspan="5">
                       <asp:GridView ID="GridView1" runat="server">
                       </asp:GridView>
                   </td>
               </tr>
               <tr>
                   <td colspan="5" rowspan="2">
                   </td>
               </tr>
               <tr>
               </tr>
           </table>
       
       </fieldset>
       
       </td >
       <td  style="width:340px; height:380px">
       <fieldset style="width:335px; height:378px">
       <legend>Document/s Submitted</legend>
       
       </fieldset>
       
       </td>
    </tr>
</table>

