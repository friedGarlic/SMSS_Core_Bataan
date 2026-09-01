<%@ Page Language="VB" AutoEventWireup="false" CodeFile="rpt_purchase_request_pop_up.aspx.vb" Inherits="procurement_rpt_purchase_request_pop_up" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
    <style type="text/css">
        .text {}
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div title="Purchase Request Report">
            <table style="width: 1000px">
                <tr>
                    <td style="width: 100%" class="text5">
                        <asp:RadioButtonList ID="rdPRFormat" runat="server" AutoPostBack="True" CssClass="text"
                            RepeatDirection="Horizontal" Width="400px" Font-Bold="True" Font-Names="Calibri" Font-Size="11pt">
                            <asp:ListItem Value="1">PR Report (Long)</asp:ListItem>
                            <asp:ListItem Value="2" Selected="True">PR Report (Short)</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td style="width: 100%">
                        <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true"  Height="50px" SeparatePages="False" ShowAllPageIds="True" Width="350px" />
                        <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
                        </CR:CrystalReportSource>
                        <CR:CrystalReportViewer ID="CrystalReportViewer2" runat="server" AutoDataBind="true"
                             Height="50px" Width="350px" />
                        <CR:CrystalReportSource ID="CrystalReportSource2" runat="server">
                        </CR:CrystalReportSource>
                    </td>
                </tr>
                <tr>
                    <td style="width: 100%"></td>
                </tr>
            </table>




        </div>
    </form>
</body>
</html>
