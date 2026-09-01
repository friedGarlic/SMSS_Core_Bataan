<%@ Page Language="VB" AutoEventWireup="false" CodeFile="index.aspx.vb" Inherits="index" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >

<head id="Head1" runat="server">

<title>SMSS Log In</title>

    <meta http-equiv="Page-Enter" content="revealtrans(duration=0.0)"/>
    <meta http-equiv="Page-Exit" content="revealtrans(duration=0.0)"/>
    <link rel ="shortcut icon" type="image/x-icon" href="images/Default2/favicon.ico" />
 

</head>

<body style="text-align: center"> 

<center>
    <form id="form1" runat="server">    
   <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table border="0" cellpadding="0" cellspacing="0" style="width: 1025px; height: 947px">
                <tr>
                    <td style="background-image: url(images/LOGIN_v2.PNG); vertical-align: top;
                        height: 654px">
                        <table cellpadding="0" cellspacing="0" style="width: 100%">
                            <tr>
                                <td style="width: 107px; height: 244px">
                                </td>
                                <td style="height: 244px">
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 107px; height: 315px">
                                </td>
                                <td style="vertical-align: top; height: 315px; text-align: left">
                                    <asp:Login ID="myLogin" runat="server" Height="250px" TitleText="" Width="352px">
                                        <LayoutTemplate>
                                            <table border="0" cellpadding="1" cellspacing="0" style="width: 336px; border-collapse: collapse">
                                                <tr>
                                                    <td style="width: 312px; height: 203px">
                                                        <table border="0" cellpadding="0" cellspacing="0" style="width: 327px">
                                                            <tr>
                                                                <td align="right" style="width: 36px; height: 35px">
                                                                    &nbsp;&nbsp;</td>
                                                                <td style="height: 35px; text-align: left">
                                                                </td>
                                                                <td style="width: 52px; height: 35px; text-align: left">
                                                                </td>
                                                                <td style="height: 35px; text-align: left; width: 263px;">
                                                                    </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right" style="width: 36px; height: 5px">
                                                                </td>
                                                                <td style="height: 5px; text-align: left">
                                                                </td>
                                                                <td style="width: 52px; height: 5px; text-align: left">
                                                                </td>
                                                                <td style="height: 5px; text-align: left; width: 263px;">
                                                                    <asp:TextBox ID="UserName" runat="server" BackColor="Transparent" BorderStyle="None"
                                                                        Font-Size="10pt" Width="180px"></asp:TextBox></td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right" style="width: 36px; height: 20px;">
                                                                    &nbsp;&nbsp;</td>
                                                                <td style="height: 20px; text-align: left">
                                                                </td>
                                                                <td style="width: 52px; height: 20px; text-align: left">
                                                                </td>
                                                                <td style="text-align: left; width: 263px; height: 20px;">
                                                                    </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right" style="width: 36px; height: 23px">
                                                                </td>
                                                                <td style="height: 23px; text-align: left">
                                                                </td>
                                                                <td style="width: 52px; height: 23px; text-align: left">
                                                                </td>
                                                                <td style="width: 263px; height: 23px; text-align: left">
                                                                    <asp:TextBox ID="Password" runat="server" BackColor="Transparent" BorderStyle="None"
                                                                        Font-Size="10pt" TextMode="Password" Width="177px" Height="16px" OnTextChanged="Password_TextChanged"></asp:TextBox></td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right" style="width: 36px; height: 47px">
                                                                </td>
                                                                <td style="height: 47px; text-align: left">
                                                                </td>
                                                                <td style="width: 52px; height: 47px; text-align: left">
                                                                </td>
                                                                <td style="width: 263px; height: 47px; text-align: left">
                                                                    <br />
                                                                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/Login_v1_01152014.jpg"
                                                                        OnClick="ImageButton1_Click" />
                                                                    <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/images/Cancel_v1_01152014.jpg" /></td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right" style="width: 36px; height: 2px">
                                                                </td>
                                                                <td style="vertical-align: bottom; height: 2px; text-align: right">
                                                                </td>
                                                                <td style="vertical-align: bottom; width: 52px; height: 2px; text-align: right">
                                                                </td>
                                                                <td style="vertical-align: bottom; height: 2px; text-align: Left; width: 263px;">
                                                                    &nbsp;&nbsp;&nbsp;
                                                                </td>
                                                                        <%--Cancel Button--%>
                                                                        
                                                                                                                                      <%--Cancel Button--%>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="4" style="height: 28px">
                                                                    </td>
                                                            </tr>
                                                            <tr style="font-size: 9pt">
                                                                <td align="right" colspan="4" style="text-align: left">
                                                                </td>
                                                            </tr>
                                                            <tr style="font-size: 9pt">
                                                                <td align="right" colspan="4" style="font-size: 10pt; width: 320px; color: red; height: 19px;
                                                                    text-align: center">
                                                                </td>
                                                            </tr>
                                                            <tr style="font-size: 9pt">
                                                                <td align="right" colspan="4" style="font-size: 10pt; width: 320px; color: red; height: 45px;
                                                                    text-align: center">
                                                                </td>
                                                            </tr>
                                                            <tr style="font-size: 9pt">
                                                                <td align="right" colspan="4">
                                                                    </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </LayoutTemplate>
                                    </asp:Login>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
    </center>
</body>

</html>
