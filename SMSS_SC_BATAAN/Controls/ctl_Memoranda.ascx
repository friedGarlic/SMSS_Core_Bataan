<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctl_Memoranda.ascx.vb"  Inherits="ctl_Memoranda" %>
<link href="../StyleSheet.css" rel="stylesheet" type="text/css" />
<table style="width:960px ; height:205px" class="text1">
    <tr>
        <td style="width: 544px" colspan="2" rowspan="2">
        <fieldset style="width: 542px;  height:200px">
        <legend class="text">Memoranda</legend>
       
            <table style="width: 528px; height: 190px" class="text">
                <tr>
                    <td style="height: 24px;" colspan="3">
                        &nbsp;<table style="width: 509px">
                            <tr>
                                <td style="width: 82px">
                                </td>
                                <td style="width: 3px">
                        <asp:Label ID="lblMemoranda" runat="server" Height="61px" Width="417px"></asp:Label></td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td style="width: 1px; height: 20px; top:auto" >
                        Remarks: </td>
                    <td style="width: 459px; height: 20px">
                        <table style="width: 430px">
                            <tr>
                                <td style="height: 37px">
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 69px">
                        <asp:Label ID="lblremarks" runat="server" Height="35px" Width="427px"></asp:Label></td>
                            </tr>
                        </table>
                    </td>
                    <td style="width: 3px; height: 20px;">
                    </td>
                </tr>
              
            </table>
    
        </fieldset>
        </td>
        
        <td style="width: 390px; height: 94px;">
        <fieldset style="width: 380px ; height: 92px">
            <table  style="width: 380px" class="text">
                <tr>
                    <td colspan="3" style="height: 20px">
                        Date of Entry in the Records of Assessment</td>
                </tr>
                <tr>
                    <td colspan="2" style="height: 20px">
                        <asp:Label ID="lblpersonassesment" runat="server" Width="222px" CssClass="text2"></asp:Label></td>
                    <td style="height: 20px">
                        <asp:Label ID="lbldateassess" runat="server" Width="135px" CssClass="text2"></asp:Label></td>
                </tr>
                <tr>
                    <td style="height: 18px">
                    </td>
                    <td style="width: 95px; height: 18px">
                    </td>
                    <td style="height: 18px">
                    </td>
                </tr>
            </table>
            </fieldset>
        </td>
    </tr>
    <tr>
        <td style="width: 390px; height:95px">
        <fieldset  style="width: 380px; height: 93px">
            <table style="width: 380px" class="text">
                <tr>
                    <td style="width: 146px">
                        Date Encoded:</td>
                    <td style="width: 63px">
                        <asp:Label ID="lblencode" runat="server" Width="75px" CssClass="text2"></asp:Label></td>
                    <td style="width: 16px">
                        By:</td>
                    <td style="width: 79px">
                        <asp:Label ID="lblencodedby" runat="server" Width="153px" CssClass="text2"></asp:Label></td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td style="width: 146px; height: 20px">
                    </td>
                    <td style="width: 63px; height: 20px">
                    </td>
                    <td style="width: 16px; height: 20px">
                    </td>
                    <td style="height: 20px; width: 79px;">
                    </td>
                    <td style="height: 20px">
                    </td>
                </tr>
                <tr>
                    <td style="width: 146px">
                        Date Updated:</td>
                    <td style="width: 63px">
                        <asp:Label ID="lblupdated" runat="server" Width="75px" CssClass="text2"></asp:Label></td>
                    <td style="width: 16px">
                        By:</td>
                    <td style="width: 79px">
                        <asp:Label ID="lblupdateby" runat="server" Width="154px" CssClass="text2"></asp:Label></td>
                    <td>
                    </td>
                </tr>
            </table>
            </fieldset>
        </td>
    </tr>
</table>

