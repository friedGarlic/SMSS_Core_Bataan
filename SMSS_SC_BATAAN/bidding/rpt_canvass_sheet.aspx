<%@ Page Language="VB" AutoEventWireup="false" CodeFile="rpt_canvass_sheet.aspx.vb" Inherits="bidding_rpt_canvass_sheet" StylesheetTheme="SkinFile" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>


<link href="~/Styles/SMSS_StyleSheet.css" rel="stylesheet" type="text/css" />

<head runat="server" id="RFQHead">
    <title class="column_LeftBold">REQUEST FOR QUOTATION</title>
</head>

<body style="background-color:#808080">
    <form runat="server" id="form_Reports">
        <table style="width: 900px">
            <tr>
                <td style="width: 100%; text-align: left"></td>
            </tr>
            <tr>
                <td style="width: 100%; text-align: center">
                    <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" 
                        SeparatePages="False" ShowAllPageIds="True" BestFitPage="True" BackColor="White" />
                    <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
                    </CR:CrystalReportSource>
                </td>
            </tr>
        </table>
    </form>

</body>






<%--<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Request for Quotation</title>
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
</head>

<body>

    <form id="form1" runat="server">

    <div title="Purchase Request Report">
        <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true"  Height="50px" 
            SeparatePages="False" ShowAllPageIds="True" Width="350px" />
        <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">           
        </CR:CrystalReportSource>
    
    </div>
    </form>
</body>
</html>--%>
